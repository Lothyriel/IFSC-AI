from typing import Tuple

import numpy as np
from networkx import Graph
from numpy import ndarray

from src.Domain.Cell import Cell
from src.Domain.Node import Node


def get_matrix_data(file_location: str) -> ndarray:  # transforma a matriz de formato csv uma matriz de Cell
    Node.initial_position_counter = 0

    str_matrix = np.genfromtxt(file_location, delimiter=',', dtype=str)

    matrix = ndarray(shape=str_matrix.shape, dtype=Node)
    for cords, cell in np.ndenumerate(str_matrix):
        x, y = cords
        cell = transform_in_cell(cell)
        matrix[cords] = Node(cell, x, y)
    return matrix


def transform_in_cell(cell: str) -> Cell:  # transforma a representacao de string para um enum
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


class GraphTransformer:  # classe para transformar o arquivo csv em grafo
    def __init__(self, matrix: ndarray):
        self.node_matrix = matrix
        self.graph = Graph()

    def create_graph(self) -> Graph:  #  transforma a matriz de Cell em um grafo nao direcional
        for cord, node in np.ndenumerate(self.node_matrix):
            if is_not_wall(node):
                self.find_vertices(node, cord)
        return self.graph

    def find_vertices(self, root: Node, coordinates: Tuple[int, int]) -> None:  #  tenta adicionar um vertice a partir de cada direcao partindo do nodo atual
        row, col = coordinates

        up = (row + 1, col)
        down = (row - 1, col)
        left = (row, col - 1)
        right = (row, col + 1)

        for cord in [up, down, left, right]:
            if not self.is_out_of_bounds(cord):
                self.add_vertice(root, self.node_matrix[cord])

    def add_vertice(self, root: Node, neighbor: Node) -> None:
        if is_not_wall(neighbor):  # nao adiciona paredes nas conexoes dos grafos
            if not (root.cell_type == Cell.SHELF and neighbor.cell_type == Cell.SHELF) and not neighbor.robot_number:  # nao adiciona caminhos de estantes para outras estantes
                self.graph.add_edge(root, neighbor)                                                                    # e em nodos iniciais (contendo robos)

    def is_out_of_bounds(self, cord: tuple[int, int]) -> bool:  # metodo para garantir que só adicionaremos vertices no grafo que realmente existem dentro da matriz
        x, y = cord
        rows, cols = self.node_matrix.shape
        return (x >= rows or x < 0) or (y >= cols or y < 0)
