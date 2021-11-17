from typing import Type

from networkx import Graph

from src.Domain.Node import Node
from src.Domain.Search import Search
from src.Extensions.GraphHelper import get_algorithm


class Biderectional(Search):
    def __init__(self, root: Node, destiny: list[Node], graph: Graph, kwargs: dict):
        super().__init__(root, destiny, graph, kwargs)

        self.search_a: Type[Search] = get_algorithm(self.kwargs["algorithm_a"])
        self.search_b: Type[Search] = get_algorithm(self.kwargs["algorithm_b"])
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


