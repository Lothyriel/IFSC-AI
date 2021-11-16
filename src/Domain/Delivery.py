from src.Domain.Node import Node
from src.Domain.Search import Search


class Delivery:  # classe que trata cada entrega
    def __init__(self, destiny_shelf: Node, search: type(Search)):
        self.search = search
        self.robots = filter(n for n in search.graph.nodes if n.robot_number)
        self.algorithm = type(search)
        self.deliver_pos = destiny_shelf

    def get_delivery_path(self) -> [Node]:
        shelf_to_best_robot = self.algorithm(self.deliver_pos, self.robots, self.search.graph).search()  # procura o caminho da prateleira até o melhor robô
        best_robot_to_shelf = shelf_to_best_robot[::-1]  # inverte o caminho para pegar do melhor robô até a prateleira

        best_robot = shelf_to_best_robot[-1]   # nodo onde está o melhor robô
        robot_to_destiny = self.algorithm(best_robot, self.deliver_pos, self.search.graph).search()   # procura o caminho da prateleira até o destino de entrega

        reverse_path_to_shelf = robot_to_destiny[::-1]  # inverte o caminho para obter o caminho de volta para o lugar original da prateleira

        return best_robot_to_shelf + robot_to_destiny + reverse_path_to_shelf  # soma os caminhos para obter o caminho final
