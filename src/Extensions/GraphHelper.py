from networkx import Graph
from numpy import ndarray

from src.Algorithms.AStar import AStar
from src.Algorithms.BFS import BFS
from src.Algorithms.Biderectional import Biderectional
from src.Algorithms.DFS import DFS
from src.Algorithms.IDS import IDS
from src.Domain.Delivery import Delivery
from src.Domain.Node import Node
from src.Domain.Search import Search, Algorithm
from src.Extensions.GraphTransformer import get_matrix_data, GraphTransformer


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

    def get_path(self, algorithm: type(Search), x: int, y: int) -> [Node]:  # retorna o caminho correto a partir dos dados enviados pela request do front end
        delivery_shelf = next(node for node in self.graph.nodes if node.x == x and node.y == y)
        return Delivery(delivery_shelf, algorithm).get_delivery_path()

    def init_csv_graph(self, file_location: str) -> Graph:  # inicia o grafo a partir de um arquivo csv de uma matriz
        node_matrix = get_matrix_data(file_location)
        return GraphTransformer(node_matrix).create_graph()