import os
from typing import Tuple, Optional

from flask import Flask
from flask_cors import CORS
from flask_restful import Api, Resource, reqparse
from networkx import Graph

from src.Domain.Cell import Cell
from src.Domain.Exceptions import InvalidNode
from src.Domain.Search import Algorithm
from src.Extensions.GraphHelper import GraphHelper, get_algorithm


def init_api(helper: GraphHelper) -> None:  # inicia a api localmente
    port = int(os.environ.get("PORT", 5000))
    app = Flask(__name__)
    api = Api(app)
    api.add_resource(API, '/api', resource_class_kwargs={'graph_helper': helper})
    CORS(app, resources={r"/api/*": {"origins": "*"}})
    app.run(host='0.0.0.0', port=port)

    @app.after_request
    def after_request(response):
        response.headers.add('Access-Control-Allow-Origin', '*')
        return response


def init_parser():  # inicia o parser dos headers do POST
    parser = reqparse.RequestParser()
    parser.add_argument('shelf_x', type=int, required=True)
    parser.add_argument('shelf_y', type=int, required=True)
    parser.add_argument('search_algorithm', type=int, required=True)
    parser.add_argument('algorithm_a', type=int, required=False)
    parser.add_argument('algorithm_b', type=int, required=False)
    return parser


class API(Resource):  # classe da restul API
    def __init__(self, graph_helper: GraphHelper):
        self.graph_helper: GraphHelper = graph_helper
        self.graph: Graph = graph_helper.graph
        self.parser = init_parser()

    def get(self) -> Tuple[dict, int]:  # endpoint GET da api, retorna os dados do grafo
        data = {"nodes": self.graph_helper.serialize_graph(),
                "x_limit": self.graph_helper.node_matrix.shape[0],
                "y_limit": self.graph_helper.node_matrix.shape[1],
                "robots": [n.serialize() for n in self.graph.nodes if n.robot_number],
                "search_instructions": {
                    "request_headers": '{shelf_x: int, shelf_y: int, search_algorithm: Enum}',
                    "algorithm_enum_values": {e.value: e.name for e in Algorithm}
                    }
                }

        return data, 200

    def post(self) -> Tuple[dict, int]:  # retorna caminho das buscas conforme o header da request
        args = self.parser.parse_args()

        x: int = args['shelf_x']
        y: int = args['shelf_y']
        algorithm: Algorithm = Algorithm(args['search_algorithm'])

        aa = args['algorithm_a']
        ab = args['algorithm_b']

        algorithm_a: Optional[Algorithm] = Algorithm(aa) if aa else None
        algorithm_b: Optional[Algorithm] = Algorithm(ab) if ab else None

        ensured = self.ensure_valid_delivery(x, y, algorithm)
        if not ensured[0]:
            return {"error_message": ensured[1]}, 400

        delivery = self.graph_helper.get_delivery(algorithm, int(x), int(y))

        path = delivery.get_path()
        data = {'search_path': [node.serialize() for node in path],
                'robot': delivery.shelf.robot_number,
                'shelf': delivery.shelf.serialize(),
                'path_length': len(path),
                'search_algorithm': algorithm.value
                }
        return data, 200

    def ensure_valid_delivery(self, x: int, y: int, algorithm: Algorithm) -> Tuple[bool, str]:
        shelf = next(n for n in self.graph.nodes if n.x == x and n.y == y)
        if shelf.cell_type is not Cell.SHELF:  # lança uma excessão se as coordenadas enviadas não forem de uma prateleira
            return False, f"{x},{y} are not coordinates of a shelf"
        if algorithm == Algorithm.Biderectional and False:
            return False, "Cant do a bidirectional search with biderectional search"

        return True, ""
