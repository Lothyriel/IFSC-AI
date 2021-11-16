from src.Domain.Node import Node
from src.Domain.Search import Search, EmptyBorder


class AStar(Search):
    def search(self) -> [Node]:  #  busca padrao em grafo
        self.border = [self.root]
        self.explored = {(self.root.x, self.root.y): self.root}
        path = [self.root]
        while True:
            if not self.border:
                raise EmptyBorder
            self.current = self.heuristic_function()
            self.explored[(self.current.x, self.current.y)] = self.current
            path.append(self.current)
            if self.current in self.destiny:
                return path
            for adj in self.graph.adj[self.current]:
                if (adj.x, adj.y) not in self.explored or adj not in self.border:
                    self.border.append(adj)

    def heuristic_function(self) -> Node:
        priority_queue = set()
        [priority_queue.add(((abs(d.x - adj.x) + abs(d.y - adj.y)), adj)) for d in self.destiny for adj in self.graph.adj[self.current] if (adj.x, adj.y) not in self.explored]
        return sorted(priority_queue, key=lambda k: k[0]).pop(0)[1]
