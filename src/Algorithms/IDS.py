from typing import Optional
from networkx import Graph

from src.Domain.Exceptions import IDSMaxDepth, IDSHitCurrentMaxDepth
from src.Domain.Node import Node
from src.Domain.Search import Search


class IDS(Search):
    def __init__(self, root: Node, destiny: list[Node], graph: Graph, kwargs: Optional[dict] = None):
        super().__init__(root, destiny, graph, kwargs)
        self.max_depth: int = self.kwargs["max_depth"]
        self.depth: int = 0
        self.current_max_depth: int = 0

    def remove_choice(self):
        return self.border.pop()

    def do_one_step(self) -> None:
        try:
            self.explore_current_node()
        except IDSHitCurrentMaxDepth:
            self.search_path = []
            self.current_max_depth += 1

    def explore_current_node(self) -> None:
        if self.depth > self.max_depth:
            raise IDSMaxDepth

        if self.depth > self.current_max_depth:
            raise IDSHitCurrentMaxDepth

        super().explore_current_node()
        self.explore_border()
        self.depth += 1

