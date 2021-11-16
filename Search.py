import abc
from enum import Enum

from networkx import Graph
from Node import Node


class Search(metaclass=abc.ABCMeta):
    def __init__(self, root: Node, destiny: [Node], graph: Graph):
        self.destiny = destiny
        self.root = root
        self.graph = graph
        self.border: [Node] = []
        self.explored = {}
        self.current = root

    @abc.abstractmethod
    def search(self) -> [Node]:
        pass


class Algorithm(Enum):
    AStar = 0
    BFS = 1
    Biderectional = 2
    DFS = 3
    IDS = 4


class EmptyBorder(Exception):
    pass


