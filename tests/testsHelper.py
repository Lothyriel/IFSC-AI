from networkx import Graph

from src.Domain.Cell import Cell
from src.Domain.Node import Node


def create_graph():
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
