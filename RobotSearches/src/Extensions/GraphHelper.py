from typing import Type

from networkx import Graph
from numpy import ndarray

import src.Algorithms
from src.Domain.Delivery import Delivery
from src.Domain.Node import Node
from src.Domain.Search import Algorithm, Search


def get_algorithm(algorithm_enum: Algorithm) -> Type[Search]:  # converte um enum para a classe de busca a ser utilizada
    return getattr(src.Algorithms, algorithm_enum.name)


class GraphHelper:  # classe para agrupar metodos de extensao do grafo
    def __init__(self, graph: Graph, node_matrix: ndarray):
        self.graph: Graph = graph
        self.node_matrix = node_matrix

    def serialize_graph(self) -> list:  # retorna os dados do grafo em um dicionario para ser transformado em json pela api
        return [self.get_adj_list(node) for node in self.graph.nodes]

    def get_adj_list(self, node: Node) -> dict:  # cria um dicionario do nodo e adiciona uma lista de adjacencias ao dicionario
        s_n = node.serialize()
        s_n["adjacent_nodes"] = [adj.serialize() for adj in self.graph.adj[node]]
        return s_n

    def get_delivery(self, algorithm: Algorithm, x: int, y: int, kwargs: dict) -> Delivery:  # retorna a encomenda a partir dos dados enviados pela request do front end
        delivery_shelf = self.get_node(x, y)
        search_algorithm = get_algorithm(algorithm)
        return Delivery(delivery_shelf, search_algorithm, self.graph, kwargs)

    def get_node(self, x: int, y: int):
        return next(n for n in self.graph.nodes if n.x == x and n.y == y)
