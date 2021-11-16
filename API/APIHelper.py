from typing import Dict

from API.API import API
from Algorithms.AStar import AStar
from Algorithms.BFS import BFS
from Algorithms.Biderectional import Biderectional
from Algorithms.DFS import DFS
from Algorithms.IDS import IDS
from Delivery import Delivery
from Node import Node
from Search import Search, Algorithm


def get_path(algorithm: type(Search), x: int, y: int) -> [Node]:  # retorna o caminho correto a partir dos dados enviados pela request do front end
    delivery_shelf = next(node for node in API.graph.nodes if node.x == x and node.y == y)
    return Delivery(delivery_shelf, algorithm).get_delivery_path()


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
