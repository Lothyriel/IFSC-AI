from src.Domain.Node import Node
from src.Domain.Search import Search


class AStar(Search):
    def remove_choice(self) -> Node:
        priority_list = [((abs(d.x - adj.x) + abs(d.y - adj.y)), adj) for d in self.destiny for adj in self.border]  # gera uma tupla de (distancia, nodo) para todos os
        _, best_node = min(priority_list, key=lambda k: k[0])                                                     # possiveis destinos a partir dos nodos na fronteira
        self.border.remove(best_node)
        return best_node              #  retorna o nodo com a menor distancia do destino mais proximo

