from Node import Node
from Search import Search


class Deliver:
    deliver_pos: Node = None

    def __init__(self, search: Search):
        self.search = search
        self.robots = filter(n for n in search.graph.nodes if n.robot_number)
        self.algorithm = type(search)
        self.initial_pos = search.root
        Deliver.deliver_pos = search.destiny

    def get_deliver_path(self) -> [Node]:
        shelf_to_closest_robot = self.algorithm(self.deliver_pos, self.robots, self.search.algorithm, self.search.graph).search()
        best_robot = shelf_to_closest_robot[-1]
        robot_to_destiny = self.algorithm(best_robot, Deliver.deliver_pos, self.search.algorithm, self.search.graph).search()
        reverse_path = robot_to_destiny[::-1]
