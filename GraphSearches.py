from networkx import Graph

from Node import Node
from SearchAlgorithm import Algorithm, Direction
from Searches import Search


class GraphSearch(Search):
    def __init__(self, root: Node, destiny: Node, algorithm: Algorithm, graph: Graph):
        super().__init__(root, destiny, algorithm, graph)

    def search(self) -> [Direction]:  #  busca padrao em grafo
        self.border = [self.root]
        explored = {}
        path = []
        while True:
            if not self.border:
                raise AttributeError
            current = self.remove_choice()
            explored[(current.x, current.y)] = current
            path.append(current)
            if current == self.destiny:
                return path
            for adj in self.graph.adj[current]:
                if (adj.x, adj.y) not in explored and (adj.x, adj.y) not in self.border:
                    if not self.get_node((adj.x, adj.y)).robot_number:
                        self.border.append(adj)

    def get_node(self, cord: [int, int]) -> Node:
        return next(n for n in self.graph.nodes if n.x == cord[0] and n.y == cord[1])
