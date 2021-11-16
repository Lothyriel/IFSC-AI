from Node import Node
from Search import Search


class Delivery:
    deliver_pos: Node = None

    def __init__(self, destiny_shelf: Node, search: type(Search)):
        self.search = search
        self.robots = filter(n for n in search.graph.nodes if n.robot_number)
        self.algorithm = type(search)
        Delivery.deliver_pos = destiny_shelf

    def get_delivery_path(self) -> [Node]:
        shelf_to_best_robot = self.algorithm(self.deliver_pos, self.robots, self.search.graph).search()
        best_robot_to_shelf = shelf_to_best_robot[::-1]

        best_robot = shelf_to_best_robot[-1]
        robot_to_destiny = self.algorithm(best_robot, Delivery.deliver_pos, self.search.graph).search()

        reverse_path_to_shelf = robot_to_destiny[::-1]

        return best_robot_to_shelf + robot_to_destiny + reverse_path_to_shelf

