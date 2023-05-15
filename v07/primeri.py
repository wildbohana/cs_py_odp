# Primer 1
jezik = 'python'
if jezik == 'python':
	print('Radimo python!')
else:
	print('Nepoznat jezik.')
print('Gotovo!')

# Primer 2
j = 1
while(j <= 5):
	print(j)
	j = j + 1

# Primer 3
# Ovo je komentar
print("Komentar")

# Primer 4
a, b = 1, 3 	# Deklarisanje dve promenljive
zbir = a + b 	# Sabiranje dve promenljive
print(zbir) 	# Ispis rezultata

# Primer 5
print("Zdravo, prijatelju!")

# Primer 6
# Ovo je primer
# viselinijskog
# komentara

"""
Ovo je primer
viselinijskog
komentara
"""

# Primer 7
x=5
y=5
x is y 	# Vraća True

list1 = []
list2 = []
list1 is list2 	# Vraća False

list1 = list2
list1 is list2 	# Vraća True

# Primer 8
"a" in "Ana" 		# Vraća True
"b" in "Ana" 		# Vraća False
"b" not in "Ana" 	# Vraća True
1 in [1, 2, 3] 		# Vraća True
4 not in [1, 2, 3] 	# Vraća True

# Primer 9
a = 2 		# 00000010
b = 3 		# 00000011
a&b 		# 00000010 - Vraca 2
a|b 		# 00000011 - Vraca 3
a^b 		# 00000001 - Vraca 1
~a 			# 11111101 - Vraca –3
a << 2 		# 00010000 - Vraca 8
a >> 2 		# 00000000 - Vraca 0

# Primer 10
x = 5
print(type(x)) 	# Ispisuje <class 'int'>

# Primer 12
x = str("Zdravo")
x = int(20)
x = list(("jabuka", "banana", "limun"))
x = dict(name="Marko", age=23)

# Primer 13
x = int(1) 			# x ce biti 1
y = int(2.8) 		# y ce biti 2
z = int("3") 		# z ce biti 3
w = int("3.2") 		# Greska!
x = float(1) 		# x ce biti 1.0
y = float(2.8) 		# y ce biti 2.8
z = float("3") 		# z ce biti 3.0
w = float("4.2") 	# w ce biti 4.2
v = float("3,2") 	# Greska!
x = str("s1") 		# x ce biti 's1'
y = str(2) 			# y ce biti '2'
z = str(3.0) 		# z ce biti '3.0'

# Primer 14
tekst = input("Unesite neki tekst: ")

# Primer 15
broj = int(input("Unesite neki broj: "))

# Primer 16
x, y = input("Unesite dve vrednosti: ").split()
print("Prva vrednost: ", x)
print("Druga vrednost: ", y)

x, y = input("Unesite dve vrednosti: ").split(',')
print("Prva vrednost: ", x)
print("Druga vrednost: ", y)

# Primer 17
print("Neki tekst") 	# Ispisuje 'Neki tekst'
print(5) 				# Ispisuje '5'
x = 2.4
print(x) 				# Ispisuje '2.4'
print("x = ", x)		# Ispisuje 'x = 2.4'
a = 2
b = 3
print("a + b =", a+b) 	# Ispisuje 'a + b = 5'

# Primer 18
a=12
b=12
c=2022

# Ispisuje '12-12-2022'
print(a,b,c,sep="-") 
# Ispisuje jabuke, narandze, banane
print('jabuke', 'narandze', 'banane', sep=', ') 
# Ispisuje jabuke i narandze i banane
print('jabuke', 'narandze', 'banane', sep=' i ')
# Ispisuje 'ABC' (bez sep: A B C)
print('A', 'B', 'C', sep='') 

# Primer 19
tekst = 'Neki tekst'
slovo = "A"

# Primer 20
dugacakTekst = """Važno je, možda, i to da znamo
Čovek je željan tek ako želi
I ako sebe celoga damo
Tek tada i možemo biti celi.
Saznaćemo tek ako kažemo
Reči iskrene, istovetne
I samo onda kad i mi tražimo
Moći će neko i nas da sretne"""

# Primer 21
a = "Zdravo!"
print(len(a)) # Ispisuje 7

# Primer 22
tekst = "Najbolje stvari u životu su besplatne!"
print("besplatne" in tekst) 	# Ispisuje True
tekst = "Najbolje stvari u životu su besplatne!"
print("skupe" not in tekst) 	# Ispisuje True

# Primer 23
pozdrav = "Zdravo svima!"
print(pozdrav[0]) 		# Ispisuje 'Z'
print(pozdrav[7:10]) 	# Ispisuje 'svi'
print(pozdrav[:6]) 		# Ispisuje 'Zdravo'
print(pozdrav[7:]) 		# Ispisuje 'svima!

# Primer 24
a = "Zdravo!"
print(a.upper()) 		# Ispisuje 'ZDRAVO!'

a = "Zdravo, Marko!"
print(a.lower()) 		# Ispisuje 'zdravo, marko!

a = " Zdravo! "
print(a.strip()) 		# Ispisuje 'Zdravo!

a = "Cao svima!"
print(a.replace("Cao", "Zdravo")) 	# Ispisuje 'Zdravo svima!'

a = "Zdravo, Marko"
print(a.split(",")) 	# Ispisuje ['Zdravo', ' Marko']

# Primer 25
a = "Zdravo"
b = "Marko"
c = a + b
print(c) 	# Ispisuje 'ZdravoMarko'

c = a + ", " + b
print(c) 	# Ispisuje 'Zdravo, Marko'

# Primer 26
godine = 23
tekst = "Moje ime je Marko i ja imam {} godine."
print(tekst.format(godine)) 
# Ispisuje 'Moje ime je Marko i ja imam 23 godine.'

kolicina = 3
idProizvoda = 567
cena = 50
porudzbina = "Želim {} komada proizvoda {} za {} dinara."
print(porudzbina.format(kolicina, idProizvoda, cena)) 
# Ispisuje 'Želim 3 komada proizvoda 567 za 50 dinara.'

# Primer 27
tekst = "Ovo je \"citat\""
print(tekst) 		# Ispisuje 'Ovo je "citat"'

# Primer 28
tekst = "Ispis obrnute kose crte: \\"
print(tekst) 		# Ispisuje 'Ispis obrnute kose crte: \
