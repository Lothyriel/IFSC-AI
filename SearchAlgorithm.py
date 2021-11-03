from enum import Enum


class Algorithm(Enum):  #  enum para classificar os tipos de busca
    IDS = 1  # Iterative deepening depth-first search
    BFS = 2  # Breadth-first search


class Direction(Enum):  #  enum para classificar a direcao em que o robo se moveu
    UP = 1
    DOWN = 2
    LEFT = 3
    RIGHT = 4
