import abc
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


