import abc
from enum import Enum
from typing import Dict, Tuple
from networkx import Graph

from src.Domain.Node import Node


class Search(metaclass=abc.ABCMeta):  # classe base para a implementacao das buscas
    def __init__(self, root: Node, destiny: list[Node], graph: Graph, kwargs: dict):
        self.kwargs: dict = kwargs

        self.destiny: list[Node] = destiny
        self.root: Node = root
        self.graph: Graph = graph
        self.search_path: list[Node] = []
        self.border: list[Node] = [self.root]
        self.explored: Dict[Tuple[int, int]: Node] = {(self.root.x, self.root.y): self.root}
        self.current: Node = root

    @abc.abstractmethod
    def search(self) -> list[Node]:
        pass

    def back_tracking(self) -> list[Node]:
        current = self.search_path[-1]
        best_path = []

        while current:
            best_path.append(current)
            current = current.parent

        return best_path[::-1]


class Algorithm(Enum):
    AStar = 0
    BFS = 1
    Biderectional = 2
    DFS = 3
    IDS = 4
