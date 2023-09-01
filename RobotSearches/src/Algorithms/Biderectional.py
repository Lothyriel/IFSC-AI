import copy
from typing import Type

from networkx import Graph

from src.Domain.Exceptions import DestinyFound
from src.Domain.Node import Node
from src.Domain.Search import Search, get_node_from


def collided(list_a: list[Node], list_b: list[Node]) -> bool:
    return any(n_a.x == n_b.x and n_a.y == n_b.y for n_a in list_a for n_b in list_b)


class Biderectional(Search):
    def __init__(self, root: Node, destiny: list[Node], graph: Graph, kwargs: dict):
        super().__init__(root, destiny, graph, kwargs)

        self.root_search: Type[Search] = self.kwargs["algorithm_a"]
        self.destiny_search: Type[Search] = self.kwargs["algorithm_b"]

    def search(self) -> list[Node]:
        root_search = self.root_search(self.root, self.destiny, self.graph, self.kwargs)
        destiny_searches = self.init_destiny_searches()

        try:
            while True:
                root_search.do_one_step()
                for search in destiny_searches:
                    search.do_one_step()
                    if collided(root_search.search_path, search.search_path):
                        shelf_to_best_robot_begin = root_search.back_tracking()
                        best_robot_to_shelf_end = search.back_tracking()
                        return shelf_to_best_robot_begin + best_robot_to_shelf_end[::-1]  # inverte a segunda metade para retornar na ordem certa
        except DestinyFound as d:
            return d.path

    def init_destiny_searches(self) -> list[Search]:
        return [self.create_search_from(destiny) for destiny in self.destiny]

    def create_search_from(self, destiny) -> Search:
        graph_copy = copy.deepcopy(self.graph)
        root_copy = get_node_from(graph_copy, self.root.x, self.root.y)
        destiny_copy = get_node_from(graph_copy, destiny.x, destiny.y)
        return self.root_search(destiny_copy, [root_copy], graph_copy, self.kwargs)

    def remove_choice(self) -> Node:
        raise Exception("Busca Biderecional não é uma busca por si só e não tem um método de remover próprio")


