# Pdf 37

# Primer 79
class Trougao:
   boja = "plava"

trougao = Trougao()
print(trougao.boja) 	# Ispisuje 'plava'

# Primer 80
class Trougao:
   boja = "plava"
   a = b = 1

   def __init__(self, a, b, c):
      self.a = a
      self.b = b
      self.c = c

# Ispisuje 'plava 3 4 5'
trougao = Trougao(3, 4, 5)
print(trougao.boja, trougao.a, trougao.b, trougao.c)

# Primer 81
class Trougao:
    boja = "plava"
    a = b = 1

    def __init__(self, a, b, c):
      self.a = a
      self.b = b
      self.c = c

    def __str__(self):
       return f"Trougao, boja: {self.boja}, stranice: {self.a}, {self.b}, {self.c}"
    
    def obim(self):
       return self.a+self.b+self.c
            
trougao = Trougao(3, 4, 5)
# Ispisuje 'plava 3 4 5'
print(trougao.boja, trougao.a, trougao.b, trougao.c) 
# Ispisuje 'Trougao, boja: plava, stranice: 3, 4, 5'
print(trougao) 
# Ispisuje 12
print(trougao.obim()) 
