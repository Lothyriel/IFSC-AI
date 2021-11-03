from networkx import Graph

from Node import Node
from SearchAlgorithm import Algorithm, Direction
from Searches import Search


class TreeSearch(Search):  #  busca padrao em arvore
    def __init__(self, root: Node, destiny: Node, algorithm: Algorithm, graph: Graph):
        super().__init__(root, destiny, algorithm, graph)

    def search(self) -> [Direction]:
        self.border = [self.root]
        path = []
        while True:
            if not self.border:
                raise AttributeError
            current = self.remove_choice()
            path.append(current)
            if current == self.destiny:
                return path
            for adj in self.graph.adj[current]:
                self.border.append(adj)
