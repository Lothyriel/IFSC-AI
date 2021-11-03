from SearchAlgorithm import SearchAlgorithm


class Search:
    def __init__(self, algorithm: SearchAlgorithm):
        self.algorithm = algorithm


class TreeSearch(Search):
    def __init__(self, algorithm: SearchAlgorithm):
        super().__init__(algorithm)


class GraphSearch(Search):
    def __init__(self, algorithm: SearchAlgorithm):
        super().__init__(algorithm)
