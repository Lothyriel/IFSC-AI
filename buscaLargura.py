def Largura(self, s, r1,r2,r3):
       #marca todos os vértices como não visitados.
 visited = [False] * (len(self.grafo)) 
 queue = [] 
       #pega o nó de origem, marca como visitado e insere ele na fila
 queue.append(s) 
 visited[s] = True
  while queue:
    #retira o último vértice inserido
    s = queue.pop(0) 
    #print(s, " ") 
    caminho.append(s)
    #Verificando vertice adjacentes. Se um adjacente não foi visitado, marca como true e adiciona a fila para visitar
    for i in self.grafo[s]:
      #print(visited[i])
      if visited[i] == False:
        queue.append(i) 
        visited[i] = True
      if(s ==robo):
        return caminho
  else:
    break


g.Largura(lista,prateleira) 
