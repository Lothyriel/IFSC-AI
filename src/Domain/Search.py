import abc
from enum import Enum
from typing import Dict, Tuple

from networkx import Graph
from src.Domain.Node import Node


class Search(metaclass=abc.ABCMeta):  # classe base para a implementacao das buscas
    def __init__(self, root: Node, destiny: [Node], graph: Graph):
        self.destiny: [Node] = destiny
        self.root: Node = root
        self.graph: Graph = graph
        self.border: [Node] = []
        self.explored: Dict[Tuple[int, int]: Node] = {}
        self.current: Node = root
        self.path: [Node] = []

    @abc.abstractmethod
    def search(self) -> [Node]:
        pass


class Algorithm(Enum):
    AStar = 0
    BFS = 1
    Biderectional = 2
    DFS = 3
    IDS = 4
