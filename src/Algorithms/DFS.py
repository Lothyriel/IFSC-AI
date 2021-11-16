from src.Domain.Node import Node
from src.Domain.Search import Search, EmptyBorder


class DFS(Search):
    def search(self) -> [Node]:  # busca padrao em grafo
        self.border = [self.root]
        path = []
        while True:
            if not self.border:
                raise EmptyBorder
            current = self.border.pop()
            self.explored[(current.x, current.y)] = current
            path.append(current)
            if current in self.destiny:
                return path
            for adj in self.graph.adj[current]:
                if (adj.x, adj.y) not in self.explored or adj not in self.border:
                    self.border.append(adj)
