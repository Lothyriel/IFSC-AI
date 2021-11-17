from typing import Tuple

from flask import Flask
from flask_restful import Api, Resource, reqparse
from networkx import Graph

from src.Domain.Search import Algorithm
from src.Extensions.GraphHelper import GraphHelper, get_algorithm


def init_api(helper: GraphHelper) -> None:  # inicia a api localmente
    app = Flask(__name__)
    api = Api(app)
    api.add_resource(API, '/api', resource_class_kwargs={'graph_helper': helper})
    app.run(debug=True)


def init_parser():  # inicia o parser dos headers do POST
    parser = reqparse.RequestParser()
    parser.add_argument('shelf_x', type=int, required=True)
    parser.add_argument('shelf_y', type=int, required=True)
    parser.add_argument('search_algorithm', type=int, required=True)
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

        delivery = self.graph_helper.get_delivery(algorithm, int(x), int(y))
        path = delivery.get_path()
        data = {'search_path': [node.serialize() for node in path],
                'robot': delivery.selected_robot.robot_number,
                'shelf': delivery.shelf.serialize(),
                'path_length': len(path),
                'search_algorithm': algorithm.value
                }
        return data, 200
