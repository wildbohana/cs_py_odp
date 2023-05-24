# Zadaci za funkcije

# Zadatak 1
# Napisati funkciju koja prihvata listu kao parametar i menja je tako što
# na prvo mesto smešta najveći element, a na poslednje najmanji
lista = [2, 15, 5, 28, 9, 30, 4]
def funkcija(lista):
	maksi = max(lista)
	lista.remove(maksi)
	mini = min(lista) 
	lista.remove(mini)
	lista.insert(0, maksi)
	lista.append(mini)

print("Vrednosti pre zamene => ", lista)
funkcija(lista)
print("Vrednosti nakon zamene => ", lista)

# Zadatak 2
# Napisati funkciju koja može da prima promenljiv broj parametara.
# Ukoliko je prosleđeno više od tri parametra, iz funkcije vratiti njihovu sumu,
# a u suprotnom vratiti njihov proizvod. Pozvati funkciju sa 2 i sa 4 parametra.
def funkcija_za_racunanje(*args):
	if len(args) > 3:
		return sum(args)
	else:
		prod = 1
		for arg in args:
			prod *=arg
		return prod

print("Proizvod (2,3) => ", funkcija_za_racunanje(2, 3))
print("Suma (2, 3, 7, 13) => ",funkcija_za_racunanje(2, 3, 7, 13))

# Zadatak 3
# Sortirati datu listu numerički:
lista = ["10", "2", "19", "0", "-1", "-20", "5"]
print("Sortirana lista => ", sorted(lista, key=lambda x: int(x)))

# Zadatak 4
# Napisati sopstvenu funkciju za filtriranje, koja kao parametre prihvata listu 
# i anonimnu funkciju, kojom je određen uslov po kome se filtrira.
# Pomoću ove funkcije iz date liste izdvojiti sve parne brojeve, a zatim i sve negativne.
def filter_funkcija(lista, uslov):
	rezultat = []
	for element in lista:
		if uslov(element):
			rezultat.append(element)
	return rezultat

lista = [2, 15, -5, 28, 9, -30, 4, -1]
print("Parni brojevi => ", filter_funkcija(lista, lambda x: x%2==0))
print("Negativni brojevi => ",filter_funkcija(lista, lambda x: x < 0))

# Rešenje preko ugrađene funkcije filter
list(filter(lambda x: x<0, lista))
print("Negativni brojevi(ugradjeni filter) => ", lista)

# Zadatak 5
# Uvećati svaki element date liste za 10, ali tako da sve vrednosti ostanu stringovi.
# Koristiti ugrađenu funkciju map i lambda funkciju.
lista = ["10", "2", "19", "0", "-1", "-20", "5"]
print(lista, " <= Pocetne vrednosti")
print(list(map(lambda x: str(int(x) + 10), lista)), " <= Vrednosti uvecane za 10", )
