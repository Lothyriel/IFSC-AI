from src.Algorithms.AStar import AStar
from src.Algorithms.BFS import BFS
from src.Algorithms.DFS import DFS
from src.Domain.Cell import Cell
from src.Extensions.GraphTransformer import GraphTransformer, get_matrix_data
import testsHelper as Helper


def test_csv():  # apenas um teste com o arquivo do armazem.csv
    node_matrix = get_matrix_data('../Armazem.csv')
    graph = GraphTransformer(node_matrix).create_graph()
    root = next(n for n in graph.nodes if n.robot_number == 1)
    destiny = [next(n for n in graph.nodes if n.x == 1 and n.y == 3)]
    path = DFS(root, destiny, graph).search()
    print(path)


def test_():  # apenas um teste com um grafo qualquer
    graph = Helper.create_graph()

    root = next(n for n in graph.nodes if n.robot_number == 1)
    destiny = [next(n for n in graph.nodes if n.cell_type is Cell.SHELF)]

    path = DFS(root, destiny, graph).search()
    print(path)


def test_largura_robo_ate_prateleira():  # apenas um teste com um grafo qualquer
    graph = Helper.create_graph()

    root = next(n for n in graph.nodes if n.robot_number == 1)
    destiny = [next(n for n in graph.nodes if n.cell_type is Cell.SHELF)]

    path = BFS(root, destiny, graph).search()
    print(path)


def test_largura_achar_melhor_robo():  # apenas um teste com um grafo qualquer
    graph = Helper.create_graph()
    root = next(n for n in graph.nodes if n.cell_type is Cell.SHELF)
    destiny = [n for n in graph.nodes if n.robot_number]

    path = BFS(root, destiny, graph).search()
    print(path)


def test_a_star():
    graph = Helper.create_graph()

    destiny = [next(n for n in graph.nodes if n.robot_number == 1)]
    root = next(n for n in graph.nodes if n.cell_type is Cell.SHELF)

    path = AStar(root, destiny, graph).search()
    print(path)
