from networkx import Graph

from Cell import Cell
from GraphFromMatrix import get_matrix_data, GraphFromMatrix
from GraphSearches import GraphSearch
from Node import Node
from SearchAlgorithm import Algorithm


def test_csv():  # apenas um teste com o arquivo do armazem.csv
    node_matrix = get_matrix_data('armazem.csv')
    graph = GraphFromMatrix(node_matrix).create_graph()
    root = next(n for n in graph.nodes if n.robot_number == 1)
    destiny = next(n for n in graph.nodes if n.x == 1 and n.y == 3)
    path = GraphSearch(root, destiny, Algorithm.BFS, graph).search()
    print(path)


def test():  # apenas um teste com um grafo qualquer
    graph = Graph()
    root = Node(Cell.INITIAL_POS, 0, 0)
    n1 = Node(Cell.HALL, 1, 0)
    n2 = Node(Cell.HALL, 1, 1)
    n3 = Node(Cell.HALL, 2, 0)
    n4 = Node(Cell.SHELF, 2, 1)
    n5 = Node(Cell.HALL, 0, 0)
    n6 = Node(Cell.DELIVER_POS, 0, 0)

    graph.add_edge(root, n1)
    graph.add_edge(root, n2)
    graph.add_edge(n1, n3)
    graph.add_edge(n1, n4)
    graph.add_edge(n2, n5)
    graph.add_edge(n2, n6)

    destiny = n4

    path = GraphSearch(root, destiny, Algorithm.IDS, graph).search()
    print(path)


if __name__ == '__main__':
    test()
    test_csv()
