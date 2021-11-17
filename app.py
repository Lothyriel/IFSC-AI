import os

from dotenv import load_dotenv
from src.API import init_api
from src.Extensions.GraphHelper import GraphHelper
from src.Extensions.GraphTransformer import get_matrix_data, GraphTransformer

if __name__ == '__main__':  # inicializando o grafo com uma matriz guardada no arquivo csv local
    load_dotenv()
    node_matrix = get_matrix_data("../armazem.csv" if os.getenv("LOCAL") else "armazem.csv")
    graph = GraphTransformer(node_matrix).create_graph()
    helper = GraphHelper(graph, node_matrix)
    init_api(helper)
