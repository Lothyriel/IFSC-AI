from src.Domain.Node import Node
from src.Domain.Search import Search


class BFS(Search):
    def remove_choice(self) -> Node:
        return self.border.pop(0)

