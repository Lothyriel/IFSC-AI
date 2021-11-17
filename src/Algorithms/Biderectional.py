from src.Domain.Node import Node
from src.Domain.Search import Search


class Biderectional(Search):
    def __init__(self, search_a: Search, search_b: Search):
        self.searc_a: Search = search_a
        self.searc_b: Search = search_b
        self.border1: list[Node] = self.destiny

    def search(self) -> list[Node]:
        visited = {node: False for node in self.graph.nodes}
        visited[self.root] = True
        visited[self.destiny] = True
        while self.border:
            # retira o último vértice inserido
            s = self.border.pop(0)
            self.search_path.append(s)

            # Verificando vertice adjacentes. Se um adjacente não foi visitado, marca como true e adiciona a fila para visitar
            for adj in self.graph.adj[s]:
                if not visited[adj]:
                    self.border.append(adj)
                    visited[adj] = True
                if s in self.destiny:
                    return self.search_path
            # retira o último vértice inserido
            dest = self.border1.pop(0)
            self.search_path.append(dest)
            for adj in self.graph.adj[dest]:
                if not visited[adj]:
                    self.border1.append(adj)
                    visited[adj] = True
                if dest in self.search_path:
                    return self.search_path


