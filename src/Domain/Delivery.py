from typing import Type, Optional
from networkx import Graph

from src.Domain.Cell import Cell
from src.Domain.Node import Node
from src.Domain.Search import Search


class Delivery:  # classe que trata cada entrega
    def __init__(self, shelf: Node, search: Type[Search], graph: Graph, kwargs: dict):
        self.robots: list[Node] = [n for n in graph.nodes if n.robot_number]
        self.search_algorithm: Type[Search] = search
        self.shelf: Node = shelf
        self.delivery_pos: Node = next(n for n in graph.nodes if n.cell_type is Cell.DELIVER_POS)
        self.graph: Graph = graph
        self.kwargs: dict = kwargs
        self.path: list[Node] = []

        self.selected_robot: Optional[Node] = None

    def get_path(self) -> None:
        best_robot_to_shelf = self.get_best_robot_path()  # procura o caminho do melhor robô até a prateleira
        self.path += best_robot_to_shelf

        shelf_to_delivery_pos = self.search_algorithm(self.shelf, [self.delivery_pos], self.graph, self.kwargs).search()  # procura o caminho da prateleira até o destino de entrega
        back_to_shelf = shelf_to_delivery_pos[::-1]  # inverte o caminho para obter o caminho de volta para o lugar original da prateleira
        self.path += shelf_to_delivery_pos[1:]

        self.path += back_to_shelf[1:]  # soma os caminhos para obter o caminho final

        self.move_robot()  # move a localizacao do robo no sistema apos terminar uma entrega

    def move_robot(self):
        robot_number = self.selected_robot.robot_number
        self.selected_robot.robot_number = None
        self.shelf.robot_number = robot_number

    def get_best_robot_path(self) -> list[Node]:
        shelf_to_best_robot = self.search_algorithm(self.shelf, self.robots, self.graph, self.kwargs).search()  # procura o caminho da prateleira até o melhor robô
        self.selected_robot = shelf_to_best_robot[-1]  # nodo onde está o melhor robô
        return shelf_to_best_robot[::-1]  # inverte o caminho para pegar do melhor robô até a prateleira
