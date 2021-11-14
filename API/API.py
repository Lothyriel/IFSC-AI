import json
import sys
from typing import Dict

from flask import Flask
from flask_restful import Api, Resource
from networkx import Graph
from GraphFromMatrix import get_matrix_data, GraphFromMatrix
from Node import Node


class API(Resource):
    graph: Graph = None

    def get(self, root_cordinates: [int, int] = (0, 0)):
        if root_cordinates == (0, 0):
            return {'nodes': get_nodes_data()}, 200
        return {'path': "path"}, 200


def get_nodes_data() -> Dict[Node, list[Node]]:
    return {f'{k.x},{k.y}': [adj.serialize() for adj in API.graph.adj[k]] for k in API.graph.nodes}


def init_api():
    app = Flask(__name__)
    api = Api(app)
    api.add_resource(API, '/api')
    app.run(debug=True)  # roda a aplicacao localmente


def init_graph():
    node_matrix = get_matrix_data('../armazem.csv')
    API.graph = GraphFromMatrix(node_matrix).create_graph()


if __name__ == '__main__':
    init_graph()
    init_api()
