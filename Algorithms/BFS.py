from Node import Node
from Search import Search


class BFS(Search):
    def search(self) -> [Node]:
        s = self.root
        # marca todos os vértices como não visitados.
        visited = {}
        for n in self.graph.nodes:
            visited[n] = False
        caminho = []
        queue = [s]
        # pega o nó de origem, marca como visitado e insere ele na fila
        visited[s] = True
        while queue:
            # retira o último vértice inserido
            s = queue.pop(0)
            # print(s, " ")
            caminho.append(s)
            # Verificando vertice adjacentes. Se um adjacente não foi visitado, marca como true e adiciona a fila para visitar
            for i in self.graph.adj[s]:
                # print(visited[i])
                if not visited[i]:
                    queue.append(i)
                    visited[i] = True
                if s in self.destiny:
                    return caminho

