import abc
from networkx import Graph
from Node import Node
from SearchAlgorithm import Algorithm, Direction


class Search(metaclass=abc.ABCMeta):
    def __init__(self, root: Node, destiny: Node, algorithm: Algorithm, graph: Graph):
        self.destiny = destiny
        self.root = root
        self.algorithm = algorithm
        self.graph = graph
        self.border = []

    @abc.abstractmethod
    def search(self) -> [Direction]:
        pass

    def remove_choice(self) -> Node:  #  metodo para alterar como é removido os nodos da fronteira com base no algoritmo escolhido
        if self.algorithm == Algorithm.IDS:
            return self.border.pop(0)  # ta incompleto precisa arrumar a iteratividade
        if self.algorithm == Algorithm.BFS:
            return self.border.pop()
