# BackEnd-BuscasRobo

route -> /api

Post JSON Body Params:
Required -> {"shelf_x": int, "shelf_y": int, "search_algorithm": Enum}
Bidirectional -> {"algorithm_a": Enum, "algorithm_b": Enum}


Algorithms Enum
    AStar = 0
    BFS = 1
    Biderectional = 2
    DFS = 3
    IDS = 4
