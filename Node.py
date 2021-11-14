from Cell import Cell


class Node:   #  clase que representa cada nodo do grafo
    initial_position_counter = 0

    def __init__(self, cell_type: Cell, x: int, y: int):
        self.cell_type = cell_type
        self.x = x
        self.y = y
        self.robot_number = None
        if cell_type is Cell.INITIAL_POS:
            Node.initial_position_counter += 1
            self.robot_number = Node.initial_position_counter

    def __str__(self) -> str:
        return f"{self.cell_type} {'' if not self.robot_number else self.robot_number} ({self.x}, {self.y})"

    def serialize(self):
        return {"x": self.x, "y": self.y, "cell_type": self.cell_type.value, "robot_number:": self.robot_number}
