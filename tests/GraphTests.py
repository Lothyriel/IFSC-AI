import unittest

from src.Algorithms.AStar import AStar
from src.Algorithms.BFS import BFS
from src.Algorithms.DFS import DFS
from src.Algorithms.IDS import IDS
from src.Algorithms.Biderectional import Biderectional
from src.Domain.Cell import Cell
from src.Extensions.GraphTransformer import GraphTransformer, get_matrix_data
from tests.TestHelper import TestHelper, is_equal


class GraphTests(unittest.TestCase):
    def __init__(self, *args, **kwargs):
        super(GraphTests, self).__init__(*args, **kwargs)
        self.helper = TestHelper()

    def test_dfs_armazem_(self):
        node_matrix = get_matrix_data('../armazem.csv')
        graph = GraphTransformer(node_matrix).create_graph()
        root = next(n for n in graph.nodes if n.robot_number == 1)
        destiny = [next(n for n in graph.nodes if n.x == 1 and n.y == 3)]
        path = DFS(root, destiny, graph).search()

        self.assert_(root in path)
        self.assert_(all(d in path for d in destiny))  # TESTE NÃO ESTÁ COMPLETO

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
        destiny = next(n for n in graph.nodes if n.cell_type is Cell.SHELF)
        root = [n for n in graph.nodes if n.robot_number]

        path = AStar(root, destiny, graph).search()

        h = self.helper.get_node
        expected_path = [h(0, 0), h(1, 0), h(2, 1)]
        self.assertListEqual(path, expected_path)
