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


def is_shelf(node: Node) -> bool:  #  Usado para nao conectar vertices a partir das prateleiras, e sim deixar os caminhos descobrir como chegar nelas
    return node.cell_type is Cell.SHELF


def is_wall(node: Node) -> bool:  #  Nao adiciona paredes no grafo
    return node.cell_type is Cell.WALL


def have_robot(node: Node) -> bool:  #  Usado para nao conectar vertices em nodos de posicao inicial
    return node.robot_number


def is_perpendicular_shelf_connection(neighbor, root):  #  Usado para nao conectar vertices em prateleiras vindo de cima ou de baixo
    if neighbor.cell_type is not Cell.SHELF:
        return False

    return not is_sideways_connection(neighbor, root)


def is_shelf_with_shelf_connection(neighbor: Node, root: Node) -> bool:  #  Usado para nao conectar vertices a partir das prateleiras em direcao a outras prateleiras
    return root.cell_type is Cell.SHELF and neighbor.cell_type is Cell.SHELF


def is_sideways_connection(neighbor: Node, root: Node) -> bool:  #  Usado para conectar prateleiras a corredores apenas na horizontal
    return root.x == neighbor.x


class GraphTransformer:  # classe para transformar o arquivo csv em grafo
    def __init__(self, matrix: ndarray):
        self.node_matrix = matrix
        self.graph = Graph()

    def create_graph(self) -> Graph:  #  transforma a matriz de Cell em um grafo nao direcional
        for cord, node in np.ndenumerate(self.node_matrix):
            if not is_wall(node):
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
        if not is_wall(neighbor) and not is_shelf(root) and not have_robot(neighbor) and not is_shelf_with_shelf_connection(neighbor, root) and not is_perpendicular_shelf_connection(neighbor, root):  # nao adiciona paredes nas conexoes dos grafos
            self.graph.add_edge(root, neighbor)    # nao adiciona caminhos de estantes para outras estantes     # e para outros nodos iniciais (contendo robos)

    def is_out_of_bounds(self, cord: tuple[int, int]) -> bool:  # metodo para garantir que só adicionaremos vertices no grafo que realmente existem dentro da matriz
        x, y = cord
        rows, cols = self.node_matrix.shape
        return (x >= rows or x < 0) or (y >= cols or y < 0)
