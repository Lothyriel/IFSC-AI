from flask import Flask
from flask_restful import Api, Resource, reqparse
from networkx import Graph

from src.Domain.Search import Algorithm
from src.Extensions.GraphHelper import GraphHelper, get_algorithm


def init_parser():
    parser = reqparse.RequestParser()
    parser.add_argument('shelf_x', type=int, required=True)
    parser.add_argument('shelf_y', type=int, required=True)
    parser.add_argument('algorithm', type=int, required=True)
    return parser


class API(Resource):  # classe da restul API
    def __init__(self, graph: Graph):
        self.graph: Graph = graph
        self.graph_helper = GraphHelper(self.graph)
        self.parser = init_parser()

    def get(self):  # endpoint GET da api, retorna os dados do grafo
        return {'nodes': self.graph_helper.serialize()}, 200

    def post(self):  # retorna caminho das buscas conforme o header da request
        args = self.parser.parse_args()

        x: int = args['shelf_x']
        y: int = args['shelf_y']
        algorithm: Algorithm = get_algorithm(Algorithm(args['algorithm']))
        return {'path': self.graph_helper.get_path(algorithm, int(x), int(y))}, 200


def init_api(graph: Graph) -> None:   # inicia a api localmente
    app = Flask(__name__)
    api = Api(app)
    api.add_resource(API, '/api', resource_class_kwargs={'graph': graph})
    app.run(debug=True)

