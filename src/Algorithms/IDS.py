from src.Domain.Exceptions import IDSMaxDepth, EmptyBorder
from src.Domain.Node import Node
from src.Domain.Search import Search


class IDS(Search):
    def search(self) -> list[Node]:  # busca padrao em grafo
        max_depth: int = self.kwargs["max_depth"]
        for i in range(max_depth):
            self.search_path = []
            depth = 0
            while True:
                if not self.border:
                    raise EmptyBorder
                self.current = self.border.pop()  # removendo os nodos da fronteira em forma de stack (LIFO)
                self.explored[(self.current.x, self.current.y)] = self.current
                self.search_path.append(self.current)
                if self.current in self.destiny:
                    return self.back_tracking()

                for adj in self.graph.adj[self.current]:
                    if (adj.x, adj.y) not in self.explored and adj not in self.border:
                        self.border.append(adj)
                        adj.parent = self.current

                depth += 1
                if depth > i:
                    break

        raise IDSMaxDepth()
