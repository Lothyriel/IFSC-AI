from networkx import Graph
from Node import Node
from Search import Search


class AStar(Search):
    def __init__(self, root: Node, destiny: [Node], graph: Graph):
        super().__init__(root, destiny, graph)

    def search(self) -> [Node]:  #  busca padrao em grafo
        self.border = [self.root]
        self.explored = {(self.root.x, self.root.y): self.root}
        path = [self.root]
        while True:
            if not self.border:
                raise AttributeError
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
        priority_queue = list(priority_queue)
        priority_queue.sort(key=lambda k: k[0])
        return priority_queue.pop(0)[1]
