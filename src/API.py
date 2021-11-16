from flask import Flask, request
from flask_restful import Api, Resource
from networkx import Graph

from src.Domain.Search import Algorithm
from src.Extensions.GraphHelper import GraphHelper, get_algorithm


class API(Resource):  # classe da restul API
    def __init__(self, graph: Graph):
        self.graph: Graph = graph
        self.helper = GraphHelper(self.graph)

    def get(self):  # endpoint GET da api, retorna os dados do grafo e o caminho das buscas conforme o header da request
        x = request.args.get("shelf_x")
        y = request.args.get("shelf_y")
        algorithm_header = request.args.get("algorithm")

        if not (x and y and algorithm_header):
            return {'nodes': self.helper.get_nodes_data()}, 200

        algorithm = get_algorithm(Algorithm(algorithm_header))
        return {'path': self.helper.get_path(algorithm, int(x), int(y))}, 200


def init_api(graph: Graph) -> None:   # inicia a api localmente
    app = Flask(__name__)
    api = Api(app)
    api.add_resource(API, '/api', resource_class_kwargs={'graph': graph})
    app.run(debug=True)

