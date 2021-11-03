import numpy as np
from networkx import Graph
from numpy import ndarray
from Cell import Cell
from Node import Node


class GraphResolver:
    def __init__(self, matrix: ndarray):
        self.node_matrix = matrix
        self.graph = Graph()

    def create_graph(self) -> Graph:  #  transforma a matriz de Cell em um grafo nao direcional
        for cord, node in np.ndenumerate(self.node_matrix):
            if is_not_wall(node):
                self.find_paths(node, cord)
        return self.graph

    def find_paths(self, root: Node, coordinates: tuple[int, int]) -> None:  #  tenta adicionar um vertice a partir de cada direcao partindo do nodo atual
        row = coordinates[0]
        col = coordinates[1]

        up = (row + 1, col)
        down = (row - 1, col)
        left = (row, col - 1)
        right = (row, col + 1)

        for cord in [up, down, left, right]:
            if not self.is_out_of_bounds(cord):
                self.add_vertice(root, self.node_matrix[cord])

    def add_vertice(self, root: Node, neighbor: Node) -> None:  #  nao adiciona paredes nas conexoes dos grafos
        if is_not_wall(neighbor):
            self.graph.add_edge(root, neighbor)

    def is_out_of_bounds(self, cord: tuple[int, int]):  #  metodo para garantir que só adicionaremos vertices no grafo que realmente existem dentro da matriz
        rows = self.node_matrix.shape[0]
        cols = self.node_matrix.shape[1]
        return (cord[0] >= rows or cord[0] < 0) or (cord[1] >= cols or cord[1] < 0)


def get_matrix_data(file_location: str) -> ndarray:  #  pega os dados de um arquivo csv e os transforma em uma matriz de Cell
    str_matrix = np.genfromtxt(file_location, delimiter=',', dtype=str)

    matrix = ndarray(shape=str_matrix.shape, dtype=Node)
    for cord, cell in np.ndenumerate(str_matrix):
        cell = transform_in_cell(cell)
        matrix[cord] = Node(cell, cord[0], cord[1])
    return matrix


def transform_in_cell(cell: str) -> Cell:  #  transforma a representacao de string para um enum de Cell
    if cell.isnumeric():
        return Cell.SHELF
    if "R" in cell:
        return Cell.INITIAL_POS
    if "X" in cell:
        return Cell.DELIVER_POS
    if "-" in cell:
        return Cell.WALL

    return Cell.HALL


def is_not_wall(node: Node) -> bool:
    return node.cell_type is not Cell.WALL
