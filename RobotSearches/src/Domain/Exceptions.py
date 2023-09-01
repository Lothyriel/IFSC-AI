from src.Domain.Node import Node


class EmptyBorder(Exception):
    pass


class DestinyFound(Exception):
    def __init__(self, path: list[Node]):
        self.path: list[Node] = path


class AbstractSearch(Exception):
    pass


class IDSHitCurrentMaxDepth(Exception):
    pass
