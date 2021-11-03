from GraphResolver import get_matrix_data, GraphResolver


def main():
    node_matrix = get_matrix_data('armazem.csv')
    graph = GraphResolver(node_matrix).create_graph()
    root = next(n for n in graph.nodes if n.number == 1)
    print(root)


if __name__ == '__main__':
    main()
