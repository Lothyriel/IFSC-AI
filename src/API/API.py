from flask import Flask, request
from flask_restful import Api, Resource
from networkx import Graph

import APIHelper as Helper
from src.Domain.Search import Algorithm
from src.GraphFromMatrix import get_matrix_data, GraphFromMatrix


class API(Resource):
    graph: Graph = None

    def get(self):  # endpoint GET da api, retorna os dados
        x = request.args.get("shelf_x")
        y = request.args.get("shelf_y")
        algorithm = Helper.get_algorithm(Algorithm(request.args.get("algorithm")))
        if not x or not y:
            return {'nodes': Helper.get_nodes_data()}, 200
        return {'path': Helper.get_path(algorithm, int(x), int(y))}, 200


def init_api() -> None:   # inicia a api localmente
    app = Flask(__name__)
    api = Api(app)
    api.add_resource(API, '/api')
    app.run(debug=True)


def init_csv_graph() -> None:  # inicia o grafo com o arquivo csv da matriz do armazém
    node_matrix = get_matrix_data('../Armazem.csv')
    API.graph = GraphFromMatrix(node_matrix).create_graph()

