from GraphResolver import get_matrix_data, GraphResolver


def main():
    matrix = get_matrix_data('armazem.csv')
    graph = GraphResolver(matrix)
    graph.to_graph()


if __name__ == '__main__':
    main()
