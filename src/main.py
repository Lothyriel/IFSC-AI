from src.API import init_api
from src.Extensions.GraphFromMatrix import init_csv_graph

if __name__ == '__main__':  # inicializando o grafo com uma matriz guardada no arquivo csv local
    graph = init_csv_graph('../Armazem.csv')
    init_api(graph)
