import numpy as np
from networkx import Graph
from numpy import ndarray
from Cell import Cell

class GraphResolver:
    def __init__(self, matrix: ndarray):
        self.matrix = matrix
        self.graph = Graph()

    def encontrar_ligacoes(self, cell: Cell, coordinates):
        r = -1
        c = -1
        row = coordinates[0]
        col = coordinates[1]
        while r <= 1:
            while c <= 1:
                if self.out_of_bounds(row, col):
                    actual_node = self.matrix[row+r][col+c]
                    if is_node(actual_node):
                        self.graph.add_edge(cell, actual_node)
                c += 1
            r += 1

    def to_graph(self):
        for cord, cell in np.ndenumerate(self.matrix):
            if is_node(cell):
                self.encontrar_ligacoes(cell, cord)

    def out_of_bounds(self, row, col):
        rows = self.matrix.shape[0]
        cols = self.matrix.shape[1]
        return (row > rows or row < 0) or (col > cols or col < 0)


def get_matrix_data(file_location: str) -> ndarray:
    str_matrix = np.genfromtxt(file_location, delimiter=',', dtype=str)

    matrix = ndarray(shape=str_matrix.shape, dtype=Cell)
    for i, cell in np.ndenumerate(str_matrix):
        matrix[i] = transform_in_cell(cell)
    return matrix


def transform_in_cell(cell: str) -> Cell:
    if cell.isnumeric():
        return Cell.ESTANTE
    if "R" in cell:
        return Cell.POSICAO_INICIAL
    if "X" in cell:
        return Cell.POSICAO_ENTREGA
    if "-" in cell:
        return Cell.PAREDE

    return Cell.CORREDOR


def is_node(cell: Cell) -> bool:
    return cell is not Cell.PAREDE and cell is not Cell.ESTANTE
