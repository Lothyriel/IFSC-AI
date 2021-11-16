from networkx import Graph

from Node import Node
from Search import Search


class DFS(Search):
    def __init__(self, root: Node, destiny: [Node], graph: Graph):
        super().__init__(root, destiny, graph)

    def search(self) -> [Node]:  # busca padrao em grafo
        self.border = [self.root]
        path = []
        while True:
            if not self.border:
                raise AttributeError
            current = self.border.pop()
            self.explored[(current.x, current.y)] = current
            path.append(current)
            if current in self.destiny:
                return path
            for adj in self.graph.adj[current]:
                if (adj.x, adj.y) not in self.explored and (adj.x, adj.y) not in self.border:
                    self.border.append(adj)
