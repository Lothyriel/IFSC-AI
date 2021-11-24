import unittest

from src.Algorithms.AStar import AStar
from src.Algorithms.BFS import BFS
from src.Algorithms.DFS import DFS
from src.Domain.Cell import Cell
from src.Extensions.GraphTransformer import GraphTransformer, get_matrix_data
from tests.TestHelper import TestHelper


class GraphTests(unittest.TestCase):
    def __init__(self, *args, **kwargs):
        super(GraphTests, self).__init__(*args, **kwargs)
        self.helper = TestHelper()

    def test_dfs_armazem_(self):
        node_matrix = get_matrix_data('../armazem.csv')
        self.helper.graph = GraphTransformer(node_matrix).create_graph()
        root = next(n for n in self.helper.graph.nodes if n.robot_number == 1)
        destiny = self.helper.get_node(1, 3)
        path = DFS(root, destiny, self.helper.graph).search()

        h = self.helper.get_node
        expected_path = [h(12, 0), h(11, 0), h(11, 1), h(11, 2), h(11, 3), h(11, 4), h(11, 5), h(11, 6), h(11, 7),
                         h(11, 8), h(11, 9), h(11, 10), h(11, 11), h(11, 12), h(11, 13), h(10, 13), h(9, 13), h(8, 13),
                         h(7, 13), h(6, 13), h(5, 13), h(4, 13), h(3, 13), h(2, 13), h(1, 13), h(1, 12), h(0, 12),
                         h(0, 11), h(1, 11), h(1, 10), h(1, 9), h(0, 9), h(0, 8), h(1, 8), h(1, 7), h(1, 6), h(0, 6),
                         h(0, 5), h(1, 5), h(1, 4), h(1, 3)]
        self.assertListEqual(path, expected_path)

    def test_dfs_robo_prateleira(self):
        graph = self.helper.graph

        root = next(n for n in graph.nodes if n.robot_number)
        destiny = [next(n for n in graph.nodes if n.cell_type is Cell.SHELF)]

        path = DFS(root, destiny, graph).search()

        h = self.helper.get_node
        expected_path = [h(0, 0), h(1, 0), h(2, 1)]
        self.assertListEqual(path, expected_path)

    def test_bfs_robo_prateleira(self):
        graph = self.helper.graph

        root = next(n for n in graph.nodes if n.robot_number)
        destiny = [next(n for n in graph.nodes if n.cell_type is Cell.SHELF)]

        path = BFS(root, destiny, graph).search()

        h = self.helper.get_node
        expected_path = [h(0, 0), h(1, 0), h(2, 1)]
        self.assertListEqual(path, expected_path)

    def test_bfs_prateleira_robo(self):  # apenas um teste com um grafo qualquer
        graph = self.helper.graph
        root = next(n for n in graph.nodes if n.cell_type is Cell.SHELF)
        destiny = [n for n in graph.nodes if n.robot_number]

        path = BFS(root, destiny, graph).search()

        h = self.helper.get_node
        expected_path = [h(2, 1), h(1, 0), h(0, 0)]
        self.assertListEqual(path, expected_path)

    def test_a_star_prateleira_robo(self):
        graph = self.helper.graph

        destiny = [next(n for n in graph.nodes if n.robot_number)]
        root = next(n for n in graph.nodes if n.cell_type is Cell.SHELF)

        path = AStar(root, destiny, graph).search()

        h = self.helper.get_node
        expected_path = [h(2, 1), h(1, 0), h(0, 0)]
        self.assertListEqual(path, expected_path)

    def test_a_star_robo_prateleira(self):
        graph = self.helper.graph
        destiny = [next(n for n in graph.nodes if n.cell_type is Cell.SHELF)]
        root = next(n for n in graph.nodes if n.robot_number)

        path = AStar(root, destiny, graph).search()

        h = self.helper.get_node
        expected_path = [h(0, 0), h(1, 0), h(2, 1)]
        self.assertListEqual(path, expected_path)
