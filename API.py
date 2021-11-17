import os
from typing import Tuple, Optional

from flask import Flask
from flask_restful import Api, reqparse
from flask_restful.utils.cors import crossdomain

from src.Domain.Cell import Cell
from src.Domain.Search import Algorithm
from src.Extensions.GraphHelper import GraphHelper
from src.Extensions.GraphTransformer import GraphTransformer, get_matrix_data

app = Flask(__name__)


def init_parser():  # inicia o new_parser dos headers do POST
    new_parser = reqparse.RequestParser()
    new_parser.add_argument('shelf_x', type=int, required=True)
    new_parser.add_argument('shelf_y', type=int, required=True)
    new_parser.add_argument('search_algorithm', type=int, required=True)
    new_parser.add_argument('algorithm_a', type=int, required=False)
    new_parser.add_argument('algorithm_b', type=int, required=False)
    return new_parser


@crossdomain(origin='http://192.168.1.30:5000/', headers='Content-Type')
def get_kwargs(args: dict) -> dict:
    aa = args['algorithm_a']
    ab = args['algorithm_b']
    algorithm_a: Optional[Algorithm] = Algorithm(aa) if aa else None
    algorithm_b: Optional[Algorithm] = Algorithm(ab) if ab else None
    return {"algorithm_a": algorithm_a, "algorithm_b": algorithm_b}


@crossdomain(origin='http://192.168.1.30:5000/', headers='Content-Type')
@app.route('/api', methods=['GET'])
def get() -> Tuple[dict, int]:  # endpoint GET da api, retorna os dados do grafo
    data = {"nodes": helper.serialize_graph(),
            "x_limit": helper.node_matrix.shape[0],
            "y_limit": helper.node_matrix.shape[1],
            "robots": [n.serialize() for n in graph.nodes if n.robot_number],
            "search_instructions": {
                "request_headers": '{shelf_x: int, shelf_y: int, search_algorithm: Enum}',
                "algorithm_enum_values": {e.value: e.name for e in Algorithm}
            }
            }

    return data, 200


@app.route('/api', methods=['POST'])
def post() -> Tuple[dict, int]:  # retorna caminho das buscas conforme o header da request
    args = parser.parse_args()

    x: int = args['shelf_x']
    y: int = args['shelf_y']
    algorithm: Algorithm = Algorithm(args['search_algorithm'])

    kwargs = get_kwargs(args)

    ensured = ensure_valid_delivery(x, y, algorithm, kwargs)
    if not ensured[0]:
        return {"error_message": ensured[1]}, 400

    delivery = helper.get_delivery(algorithm, int(x), int(y), kwargs)

    path = delivery.get_path()
    data = {'search_path': [node.serialize() for node in path],
            'robot': delivery.shelf.robot_number,
            'shelf': delivery.shelf.serialize(),
            'path_length': len(path),
            'search_algorithm': algorithm.value
            }
    return data, 200


def ensure_valid_delivery(x: int, y: int, algorithm: Algorithm, kwargs: dict) -> Tuple[bool, str]:
    shelf = next(n for n in graph.nodes if n.x == x and n.y == y)
    if shelf.cell_type is not Cell.SHELF:
        return False, f"{x},{y} are not coordinates of a shelf"  # lança um bad request se as coordenadas enviadas não forem de uma prateleira
    if algorithm == Algorithm.Biderectional:
        if kwargs["algorithm_a"] == Algorithm.Biderectional or kwargs["algorithm_b"] == Algorithm.Biderectional:
            return False, "Cant do a bidirectional search with biderectional search"  # lança um bad request se for selecionado busca bidirecional com busca direcional
        elif not (kwargs["algorithm_a"] and kwargs["algorithm_b"]):
            return False, "Cant do a bidirectional search without two algorithms"
    return True, ""


if __name__ == '__main__':  # inicializando o grafo com uma matriz guardada no arquivo csv local
    port = int(os.environ.get("PORT", 5000))
    api = Api(app)
    parser = init_parser()

    node_matrix = get_matrix_data("armazem.csv")
    graph = GraphTransformer(node_matrix).create_graph()
    helper = GraphHelper(graph, node_matrix)

    app.run(host='0.0.0.0', port=port)
