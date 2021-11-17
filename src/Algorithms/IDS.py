from src.Domain.Exceptions import IDSMaxDepth, EmptyBorder
from src.Domain.Node import Node
from src.Domain.Search import Search


class IDS(Search):
    def search(self) -> list[Node]:  # busca padrao em grafo
        if not self.iddfs(self.root, self.destiny, 100):
            raise IDSMaxDepth
        return self.back_tracking()

    def dls(self, src, target, max_depth):
        self.search_path.append(src)
        if src in target:
            return True

        if max_depth <= 0:
            self.search_path = []
            return False

        for i in self.graph[src]:
            i.parent = src
            if self.dls(i, target, max_depth - 1):
                return True
        return False

    def iddfs(self, src, target, max_depth):
        for i in range(max_depth):
            if self.dls(src, target, i):
                return True
        return False
