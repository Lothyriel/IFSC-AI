#Algoritmo para Busca em Largura
 
#importa a bibliotecas
from collections import defaultdict
from typing import final 
#varicavel inicial até não ser integrado (depois ira receber por parametro)
inicial=0
#lista que ira retornar o caminho que será percorrido
caminho=[]
caminho1=[]
#classe para criação do grafo direcionado e que usa representação de lista de adjacência
class Grafo: 
    #função que ira criar a lista 
   def __init__(self): 
 
        #Quando você cria um defaultdict, fornece uma função usada para criar valores, nesse caso criou-se a lista
        self.grafo = defaultdict(list) 

    #função que adiciona os vértices no grafo
   def addEdge(self,u,v): 
        self.grafo[u].append(v) 
 
    #recebe o primeiro nó a ser visitado 
   def Largura(self, s, r1,r2,r3):
 
        #marca todos os vértices como não visitados.
    visited = [False] * (len(self.grafo)) 
      
        #cria uma fila vazia
    queue = [] 
 
        #pega o nó de origem, marca como visitado e insere ele na fila
    queue.append(s) 
    visited[s] = True
 
      #enquanto existe elemento na fila executa
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
      def caminho_separacao(s,caminho,queue,caminho1,visited):
        s=caminho[0]
        visited = [False] * (len(self.grafo)) 
        queue.clear()
        queue.append(s) 
        visited[s] = True
        while queue:
          if(s != separacao):
            s = queue.pop(0) 
            caminho1.append(s)
            for i in self.grafo[s]: 
              #print(visited[i])
              if visited[i] == False: 
                queue.append(i)
                visited[i] = True
          else:
            break
      if(s ==r1):
        print("Robo 1 encontrado na posicao ",s)
        caminho_separacao(s,caminho,queue,caminho1,visited)
        break
      elif(s ==r2):
        print("Robo 2 encontrado na posicao ",s)
        caminho_separacao(s,caminho,queue,caminho1,visited)
        break
      elif(s ==r3):
        print("Robo 3 encontrado na posicao ",s)
        caminho_separacao(s,caminho,queue,caminho1,visited)
        break
      
      #apresenta retorna caminho (no momento apensas apresentando na saida)
    if (caminho[-1]!= r1 and caminho[-1] !=r2 and caminho[-1] !=r3):
      print("Robo nao encontrado")
    else:
      print("Caminho do robo ate a parteleira ",caminho[::-1])
      print("caminho ate a separacao",caminho1)
      print("caminho voltando ate a prateleira",caminho1[::-1])
      caminho.pop(0)
      caminhovolta=caminho1[::-1]
      caminhovolta.pop(0)
      caminhopercorrido=caminho[::-1]+caminho1+caminhovolta
      print("caminho percorrido pelo robo ",caminhopercorrido)
 
g = Grafo() 
g.addEdge(0, 2) 
g.addEdge(0, 3) 
g.addEdge(0, 4) 
g.addEdge(1, 2) 
g.addEdge(1, 4) 
g.addEdge(2, 4)
g.addEdge(3, 4) 
g.addEdge(3, 5) 
g.addEdge(4, 5) 
g.addEdge(5, 1)  

r1=3
r2=5
r3=0
prateleira=2
separacao=5
g.Largura(prateleira, r1,r2,r3) 
