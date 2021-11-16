from typing import Type

from networkx import Graph

from src.Domain.Cell import Cell
from src.Domain.Exceptions import InvalidNode
from src.Domain.Node import Node
from src.Domain.Search import Search


class Delivery:  # classe que trata cada entrega
    def __init__(self, shelf: Node, search: Type[Search], graph: Graph):
        self.robots: [Node] = [n for n in graph.nodes if n.robot_number]
        self.search_algorithm: Type[Search] = search
        self.shelf: Node = shelf
        self.graph: Graph = graph

        self.ensure_is_shelf()

    def get_delivery_path(self) -> [Node]:
        shelf_to_best_robot = self.search_algorithm(self.shelf, self.robots, self.graph).search()  # procura o caminho da prateleira até o melhor robô
        best_robot_to_shelf = shelf_to_best_robot[::-1]  # inverte o caminho para pegar do melhor robô até a prateleira

        best_robot = shelf_to_best_robot[-1]   # nodo onde está o melhor robô
        robot_to_destiny = self.search_algorithm(best_robot, self.shelf, self.graph).search()  # procura o caminho da prateleira até o destino de entrega

        reverse_path_to_shelf = robot_to_destiny[::-1]  # inverte o caminho para obter o caminho de volta para o lugar original da prateleira

        return best_robot_to_shelf + robot_to_destiny + reverse_path_to_shelf  # soma os caminhos para obter o caminho final

    def ensure_is_shelf(self):  # lança uma excessão se as coordenadas enviadas não forem de uma prateleira
        if self.shelf.cell_type is not Cell.SHELF:
            raise InvalidNode("Selected node is not a shelf")
