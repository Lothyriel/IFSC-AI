# BackEnd-BuscasRobo

route -> /api

Post JSON Body Params:
required -> {"shelf_x": 1, "shelf_y": 0, "search_algorithm": 2}
IDS -> {"max_depth": 10} 
Bidirectional -> {"algorithm_a": 0, "algorithm_b": 0}


Algorithms Enum
    AStar = 0
    BFS = 1
    Biderectional = 2
    DFS = 3
    IDS = 4
