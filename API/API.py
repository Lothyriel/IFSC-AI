from typing import Dict
from flask import Flask, request
from flask_restful import Api, Resource
from networkx import Graph

from Algorithms.AStar import AStar
from Algorithms.BFS import BFS
from Algorithms.Biderectional import Biderectional
from Algorithms.DFS import DFS
from Algorithms.IDS import IDS
from Delivery import Delivery
from GraphFromMatrix import get_matrix_data, GraphFromMatrix
from Node import Node
from Search import Algorithm, Search


class API(Resource):
    graph: Graph = None

    def get(self):  # endpoint GET da api, retorna os dados
        if not request.args.get("shelf_x") or not request.args.get("shelf_y"):
            return {'nodes': get_nodes_data()}, 200
        return {'path': get_path()}, 200


def get_path() -> [Node]:  # retorna o caminho correto a partir dos dados enviados pela request do front end
    algorithm = get_algorithm(Algorithm(request.args.get("algorithm")))
    x = request.args.get("shelf_x")
    y = request.args.get("shelf_y")
    delivery_shelf = next(node for node in API.graph.nodes if node.x == x and node.y == y)
    Delivery(delivery_shelf, algorithm).get_delivery_path()


def get_algorithm(algorithm_enum: Algorithm) -> type(Search):  # converte um enum para a classe de busca a ser utilizada
    if algorithm_enum == Algorithm.AStar:
        return type(AStar)
    if algorithm_enum == Algorithm.BFS:
        return type(BFS)
    if algorithm_enum == Algorithm.Biderectional:
        return type(Biderectional)
    if algorithm_enum == Algorithm.IDS:
        return type(IDS)
    if algorithm_enum == Algorithm.DFS:
        return type(DFS)


def get_nodes_data() -> Dict[str, list[Node]]:  # retorna os dados do grafo em um dicionario para ser transformado em json pela api
    return {f'{node.x},{node.y}': [adj.serialize() for adj in API.graph.adj[node]] for node in API.graph.nodes}


def init_api() -> None:   # inicia a api localmente
    app = Flask(__name__)
    api = Api(app)
    api.add_resource(API, '/api')
    app.run(debug=True)


def init_graph() -> None:  # inicia o grafo com o arquivo csv da matriz do armazém
    node_matrix = get_matrix_data('../armazem.csv')
    API.graph = GraphFromMatrix(node_matrix).create_graph()


if __name__ == '__main__':
    init_graph()
    init_api()
