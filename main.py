from GraphResolver import get_matrix_data, GraphResolver
from GraphSearches import GraphSearch
from SearchAlgorithm import Algorithm
from TreeSearch import TreeSearch


def main():  #  apenas um teste
    node_matrix = get_matrix_data('armazem.csv')
    graph = GraphResolver(node_matrix).create_graph()
    root = next(n for n in graph.nodes if n.number == 1)
    destiny = next(n for n in graph.nodes if n.x == 1 and n.y == 3)
    path = GraphSearch(root, destiny, Algorithm.IDS, graph).search()
    print(path)


if __name__ == '__main__':
    main()
