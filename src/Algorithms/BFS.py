from src.Domain.Node import Node
from src.Domain.Search import Search


class BFS(Search):
    def search(self) -> [Node]:
        s = self.root
        # marca todos os vértices como não visitados.
        visited = {node: False for node in self.graph.nodes}
        self.border.append(s)
        # pega o nó de origem, marca como visitado e insere ele na fila
        visited[s] = True

        while self.border:
            # retira o último vértice inserido
            s = self.border.pop(0)
            self.path.append(s)
            # Verificando vertice adjacentes. Se um adjacente não foi visitado, marca como true e adiciona a fila para visitar
            for i in self.graph.adj[s]:
                if not visited[i]:
                    self.border.append(i)
                    visited[i] = True
                if s in self.destiny:
                    return self.path

