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


def init_parser():  # inicia a api localmente
    parser = reqparse.RequestParser()
    parser.add_argument('shelf_x', type=int, required=True)
    parser.add_argument('shelf_y', type=int, required=True)
    parser.add_argument('algorithm', type=int, required=True)
    return parser


class API(Resource):  # classe da restul API
    def __init__(self, graph_helper: GraphHelper):
        self.graph_helper: GraphHelper = graph_helper
        self.graph: Graph = graph_helper.graph
        self.parser = init_parser()

    def get(self):  # endpoint GET da api, retorna os dados do grafo
        data = {"nodes": self.graph_helper.serialize_graph(),
                "x_limit": self.graph_helper.node_matrix.shape[0],
                "y_limit": self.graph_helper.node_matrix.shape[1],
                "search_instructions": {
                    "request_headers": '{"shelf_x": int, "shelf_y": int, "algorithm": Enum}',
                    "algorithm_enum_values": {"AStar": 0, "BFS": 1, "Biderectional": 2, "DFS": 3, "IDS": 4}
                    }
                }

        return data, 200

    def post(self):  # retorna caminho das buscas conforme o header da request
        args = self.parser.parse_args()

        x: int = args['shelf_x']
        y: int = args['shelf_y']
        algorithm: Algorithm = get_algorithm(Algorithm(args['algorithm']))
        return {'path': self.graph_helper.get_path(algorithm, int(x), int(y))}, 200
