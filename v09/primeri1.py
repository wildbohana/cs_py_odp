# Pdf 33

# Primer 74
# Definicija
def funkcija():
   print("Ovo je funkcija.")

# Poziv
funkcija()


# Primer 75a
def predstavi_se(ime, prezime):
	print("Ja sam {} {}".format(ime, prezime))
	#print("Ja sam " + ime + " " + prezime)

predstavi_se("Petar", "Petrović") 		# Ispisuje 'Ja sam Petar Petrović'
predstavi_se("Marko", "Marković") 		# Ispisuje 'Ja sam Marko Marković'
predstavi_se("Jovan", "Jovanović") 		# Ispisuje 'Ja sam Jovan Jovanović'

predstavi_se(ime = "Milan", prezime = "Milanović") 	# Ispisuje 'Ja sam Milan Milanović'
predstavi_se(prezime = "Milošević", ime = "Miloš") 	# Ispisuje 'Ja sam Miloš Milošević'

# Primer 75b
def funkcija_parametri(*args):
    for arg in args:
        print(arg)

funkcija_parametri("Prvi parametar", "Drugi parametar")
funkcija_parametri("Prvi parametar", "Drugi parametar", "Treći parametar")
funkcija_parametri("Prvi parametar")

# Primer 75c
def funkcija_imenovani_parametri(**kwargs):
    for key, value in kwargs.items():
        print("%s -> %s" % (key, value))
 
funkcija_imenovani_parametri(prvi='Prvi parametar', drugi='Drugi parametar', treći='Treći parametar')
funkcija_imenovani_parametri(prvi='Prvi parametar', drugi='Drugi parametar')
funkcija_imenovani_parametri(prvi='Prvi parametar', drugi='Drugi parametar', treći='Treći parametar', četvrti="Četvrti parametar")

# Primer 75d
def stepenovanje(x, y = 2):
   print(x**y)

stepenovanje(2, 3) 			# Ispisuje 8
stepenovanje(2) 			# Ispisuje 4

# Primer 76a
def stepenovanje(x: int, y: int):
    print(x**y)

stepenovanje(2, 3) 			# Ispisuje 8
stepenovanje("tekst", 4) 	# Greska!

# Primer 76b
def izmena(x):
   x[0] = 5

x = [1, 4, 3, 2, 1]
izmena(x)
# Ispisuje [5, 4, 3, 2, 1]
print(x)

# Primer 76c
def dodela(x):
   x = [1, 2, 3, 4, 5]

x = [5, 4, 3, 2, 1]
dodela(x)
# Ispisuje [5, 4, 3, 2, 1]
print(x) 

# Primer 77
def stepenovanje(x: int, y: int) -> x:
    return x**y

z = stepenovanje(2, 3) 
print(z) 		# Ispisuje 8

def veci_broj(x, y):
    if x > y:
       return x
    elif y > x:
       return y
    return None

print(veci_broj(2, 5))		# Ispisuje 5
print(veci_broj(20, 5)) 	# Ispisuje 20
print(veci_broj(2, 2)) 		# Ispisuje None

# Primer 78
mnozenje = lambda a, b, c : a * b * c
print(mnozenje(5, 6, 2))

par_nepar = lambda broj: "Paran broj" if broj % 2 == 0 else "Neparan broj"
print(par_nepar(20))

lista = ["1", "2", "9", "0", "-1", "-2"]
# Ispisuje 'Pozitivni parni brojevi: ['2']'
print("Pozitivni parni brojevi:",
      list(filter(lambda x: (int(x) % 2 == 0 and int(x) > 0), lista))) 
