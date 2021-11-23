from typing import Type

from networkx import Graph

from src.Domain.Exceptions import DestinyFound
from src.Domain.Node import Node
from src.Domain.Search import Search


class Biderectional(Search):
    def __init__(self, root: Node, destiny: list[Node], graph: Graph, kwargs: dict):
        super().__init__(root, destiny, graph, kwargs)

        self.search_a: Type[Search] = self.kwargs["algorithm_a"]
        self.search_b: Type[Search] = self.kwargs["algorithm_b"]

        self.count = 0

    def search(self) -> list[Node]:
        alg_a = self.search_a(self.root, self.destiny, self.graph, self.kwargs)

        if len(self.destiny) > 1:
            destiny = self.get_shorter_path_when_multiple_destinies()
            alg_b = self.search_b(destiny, [self.root], self.graph, self.kwargs)
        else:
            alg_b = self.search_b(self.destiny[0], [self.root], self.graph, self.kwargs)

        while not any(node in alg_a.search_path for node in alg_b.search_path):
            if self.count % 2 == 0:
                try:
                    alg_a.do_one_step()
                except DestinyFound:
                    return alg_a.back_tracking()
            else:
                try:
                    alg_b.do_one_step()
                except DestinyFound:
                    return alg_b.back_tracking()
            self.count += 1

        return []

    def get_shorter_path_when_multiple_destinies(self) -> Node:
        destiny_node, _ = min([(destiny, self.search_b(self.root, [destiny], self.graph, self.kwargs).search()) for destiny in self.destiny], key=lambda tupla: len(tupla[1]))
        return destiny_node

    def remove_choice(self) -> Node:
        raise Exception("Busca Biderecional não é uma busca por si só e não tem um método de remover próprio")
