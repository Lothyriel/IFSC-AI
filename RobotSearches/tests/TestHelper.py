from networkx import Graph
from src.Domain.Cell import Cell
from src.Domain.Node import Node


def create_test_graph() -> Graph:
    graph = Graph()
    root = Node(Cell.INITIAL_POS, 0, 0)
    n1 = Node(Cell.HALL, 1, 0)
    n2 = Node(Cell.HALL, 1, 1)
    n3 = Node(Cell.HALL, 2, 0)
    n4 = Node(Cell.SHELF, 2, 1)
    n5 = Node(Cell.HALL, 2, 2)
    n6 = Node(Cell.DELIVER_POS, 2, 3)

    graph.add_edge(root, n1)
    graph.add_edge(root, n2)
    graph.add_edge(n1, n3)
    graph.add_edge(n1, n4)
    graph.add_edge(n2, n5)
    graph.add_edge(n2, n6)

    return graph


def is_equal(expected_path: list[Node], path: list[Node]):
    return all(n in path for n in expected_path)


class TestHelper:
    def __init__(self):
        self.graph: Graph = create_test_graph()

    def get_node(self, x: int, y: int):
        return next(n for n in self.graph.nodes if n.x == x and n.y == y)
