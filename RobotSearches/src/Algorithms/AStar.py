from src.Domain.Node import Node
from src.Domain.Search import Search


def get_estimated_cost(adj, destiny) -> int:
    return abs(destiny.x - adj.x) + abs(destiny.y - adj.y)  #  estima um custo com base na distancia do ponto atual e do destino


class AStar(Search):
    def remove_choice(self) -> Node:
        priority_list = [(self.get_current_cost(node) + get_estimated_cost(node, destiny), node) for destiny in self.destiny for node in self.border]  # gera uma tupla de (distancia percorrida + distancia estimada, nodo) para todos os
        _, best_node = min(priority_list, key=lambda k: k[0])  # retorna o de menor custo para ser expandido                                           # possiveis destinos a partir dos nodos na fronteira
        self.border.remove(best_node)
        return best_node              #  retorna o nodo com a menor distancia do destino mais proximo

    def get_current_cost(self, node: Node) -> int:
        return len(self.back_tracking(node))  #  calcula a distancia com base em quantos nodos foram percorridos para chegar a este nodo

