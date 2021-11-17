from src.Domain.Exceptions import EmptyBorder
from src.Domain.Node import Node
from src.Domain.Search import Search


class AStar(Search):
    def search(self) -> list[Node]:  #  busca padrao em grafo
        while True:
            if not self.border:
                raise EmptyBorder
            self.current = self.heuristic_function()
            self.explored[(self.current.x, self.current.y)] = self.current
            self.search_path.append(self.current)
            if self.current in self.destiny:
                return self.back_tracking()
            for adj in self.graph.adj[self.current]:
                if (adj.x, adj.y) not in self.explored and adj not in self.border:
                    self.border.append(adj)
                    adj.parent = self.current

    def heuristic_function(self) -> Node:
        priority_list = [((abs(d.x - adj.x) + abs(d.y - adj.y)), adj) for d in self.destiny for adj in self.border]  # gera uma tupla de (distancia, nodo) para todos os
        best_option = min(priority_list, key=lambda k: k[0])[1]                                                      # possiveis destinos a partir dos nodos na fronteira
        self.border.remove(best_option)
        return best_option              #  retorna a opcao com a menor distancia do destino mais proximo no plano cartesiano
