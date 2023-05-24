# pdf 16 strana (od polovine)

# Primer 27
lista = ["jabuke", "banane", "kivi"]
print(lista)

# Primer 28
duzina = len(lista)
print(duzina)

# Primer 29
# Svuda ispisuje <class 'list'>
lista1 = ["jabuke", "banane", "kivi"]
lista2 = [1, 5, 7, 9, 3]
lista3 = [True, False, False]
lista4 = ["abc", 34, True, 40]
print(type(lista1))
print(type(lista2))
print(type(lista3))
print(type(lista4))

# Primer 30
lista = list((1, 2, 3))
print(lista) # Ispisuje [1, 2, 3]

# Primer 31
lista = ["jabuke", "banane", "kivi", "mandarine", "grozdje", "mango"]
print(lista[2]) 		# Ispisuje 'kivi'
print(lista[2:5]) 		# Ispisuje ['kivi', 'mandarine', 'grozdje']
print(lista[:3]) 		# Ispisuje ['jabuke', 'banane', 'kivi']
print(lista[3:]) 		# Ispisuje ['mandarine', 'grozdje', 'mango']

print(lista[-1]) 		# Ispisuje 'mango'
print(lista[-4:-1]) 	# Ispisuje ['kivi', 'mandarine', 'grozdje']
print(lista[:-2]) 		# Ispisuje ['jabuke', 'banane', 'kivi', 'mandarine']
print(lista[-4:]) 		# Ispisuje ['kivi', 'mandarine', 'grozdje', 'mango']

# Primer 32
lista = ["jabuke", "banane", "kivi"]
lista.append("mango")
print(lista)
lista.insert(1, "kruska")
print(lista)
lista2 = ["maline", "kupine", "jagode"]
lista.extend(lista2)
print(lista)

# Primer 33
lista = ["jabuke", "banane", "kivi", "mandarine", "grozdje", "mango"]
lista[0] = "kruske"
print(lista)
lista[2:4] = ["jagode", "maline"]
print(lista)
lista[2:4] = ["kupine"]
print(lista)
lista[2:4] = ["borovnice", "ribizle", "narandza"]
print(lista)

# Primer 34
lista = ["jabuke", "banane", "kivi", "mandarine", "grozdje", "mango"]
lista.remove("kivi")
print(lista)
lista.pop()
print(lista)
lista.pop(0)
print(lista)
lista.clear()
print(lista)

lista = ["jabuke", "banane", "kivi", "mandarine", "grozdje", "mango"]
del lista[0]
print(lista)
del lista[1:3]
print(lista)
del lista
print(lista) 		# Greska! NameError: name 'lista' is not defined.

# Primer 35
lista1 = ["jabuke", "banane", "kivi", "mandarine", "grozdje", "mango"]
lista2 = [1, 5, 7, 9, 3]
lista1.sort()		# alfabetski sortira
lista2.sort()		# sortira po vrednostima rastuće
print(lista1)
print(lista2)

lista1.sort(reverse=True)
lista2.sort(reverse=True)
print(lista1) 
print(lista2)

# Primer 36
lista1 = ["jabuke", "banane", "kivi", "mandarine", "grozdje", "mango"]
lista2 = [1, 5, 7, 9, 3]
lista1.reverse()
lista2.reverse()
print(lista1)
print(lista2)

# Primer 37
torka = ("jabuke", "banane", "kivi") 
print(torka)

# Primer 38
duzina = len(torka) 
print(duzina)

# Primer 39
# Svuda ispisuje <class 'tuple'>
torka1 = ("jabuke", "banane", "kivi") 
torka2 = (1, 5, 7, 9, 3)
torka3 = (True, False, False) 
torka4 = ("abc", 34, True, 40) 
print(type(torka1)) 
print(type(torka2))  
print(type(torka3))  
print(type(torka4))

# Primer 40
torka = tuple((1, 2, 3)) 
print(torka)

# Primer 41
torka = ("jabuke", "banane", "kivi", "mandarine", "grozdje", "mango") 
print(torka[2])			# Ispisuje 'kivi' 
print(torka[2:5]) 		# Ispisuje ('kivi', 'mandarine', 'grozdje') 
print(torka[:3]) 		# Ispisuje ('jabuke', 'banane', 'kivi')
print(torka[3:]) 		# Ispisuje ('mandarine', 'grozdje', 'mango') 
print(torka[-1]) 		# Ispisuje 'mango' 
print(torka[-4:-1]) 	# Ispisuje ('kivi', 'mandarine', 'grozdje') 
print(torka[:-2]) 		# Ispisuje ('jabuke', 'banane', 'kivi', 'mandarine') 
print(torka[-4:]) 		# Ispisuje ('kivi', 'mandarine', 'grozdje', 'mango') 

# Primer 42
torka = ("jabuke", "banane", "kivi", "mandarine", "grozdje", "mango")
lista = list(torka)
lista.append("kruske")
torka = tuple(lista)
print(torka)

# Primer 43
torka1 = ("jabuke", "banane", "kivi")
torka2 = ("mandarine", "grozdje")
torka3 = ("mango",)
torka1 += torka2
print(torka1) 		# Ispisuje ('jabuke', 'banane', 'kivi', 'mandarine', 'grozdje')
torka1 += torka3
print(torka1) 		# Ispisuje ('jabuke', 'banane', 'kivi', 'mandarine', 'grozdje', 'mango')

# Primer 44
torka = ("jabuke", "banane", "kivi")
(crveno, zuto, zeleno) = torka
print(crveno) 		# Ispisuje 'jabuke'
print(zuto) 		# Ispisuje 'banane'
print(zeleno) 		# Ispisuje 'kivi'

# Primer 45
torka = ("jabuke", "banane", "kivi", "mandarine", "grozdje", "mango")
(jabuke, *ostalo, mango) = torka
print(jabuke) 		# Ispisuje 'jabuke'
print(ostalo) 		# Ispisuje ['banane', 'kivi', 'mandarine', 'grozdje']
print(mango) 		# Ispisuje 'mango'

# Primer 46
skup = {"jabuke", "banane", "kivi"}
print(skup) 		# Ispisuje random redosledom

skup = {"jabuke", "banane", "kivi", "kivi"}
print(skup) 		# Ispisuje random redosledom

# Primer 47
duzina = len(skup) 
print(duzina)

# Primer 48
# Svuda ispisuje <class 'set'>
skup1 = {"jabuke", "banane", "kivi"} 
skup2 = {1, 5, 7, 9, 3}
skup3 = {True, False, False} 
skup4 = {"abc", 34, True, 40} 
print(type(skup1))
print(type(skup2))
print(type(skup3))
print(type(skup4)) 

# Primer 49
skup = set((1, 2, 3)) 
print(skup)

# Primer 50
skup1 = {"jabuke", "banane", "kivi"} 
skup1.add("kruske")
print(skup1) 		# Ispisuje {'kivi', 'banane', 'kruske', 'jabuke'}

skup2 = {"mandarine", "grozdje", "mango"} 
skup1.update(skup2)
print(skup1) 		# Ispisuje {'mandarine', 'mango', 'jabuke', 'kivi', 'banane', 'kruske', 'grozdje'}

# Primer 51
skup1 = {"jabuke", "banane", "kivi"} 
skup1.remove("kivi")
print(skup1)
skup1.remove("jabuka") 		# Greska!

skup2 = {"mandarine", "grozdje", "mango"}
skup2.discard("grozdje")
print(skup2) 				# Ispisuje {'mandarine', 'mango'}
skup2.discard("mandarina") 	# Nema efekta.
print(skup2) 				# Ispisuje {'mandarine', 'mango'}

# Primer 52
skup1 = {"jabuke", "banane", "kivi", "mandarine", "grozdje"} 
x = skup1.pop()
# Ispisuje 'Obrisani element: mandarine'
print("Obrisani element:", x)

# Primer 53
skup1 = {"jabuke", "banane", "kivi", "mandarine", "grozdje"}
skup1.clear()
print(skup1) 				# Ispisuje 'set()'
del skup1
print(skup1) 				# Greska! NameError: name 'skup1' is not defined.

# Primer 54
recnik = {
    "marka": "Ford",
    "model": "Mustang",
    "godina": 1964 
}
print(recnik)

# Primer 55
duzina = len(recnik)
print(duzina)

# Primer 56
# Ispisuje <class 'dict'>
recnik = {
    "marka": "Ford",
    "model": "Mustang",
    "godina": 1964,
    "boje": ["crvena", "crna", "zuta"] 
}
print(type(recnik))

# Primer 57
# Isti ispis kao i za prvi primer
recnik = dict(marka = "Ford", model = "Mustang", godina = 1964)
print(recnik)

# Primer 58
recnik = {
    "marka": "Ford",
    "model": "Mustang",
    "godina": 1964,
    "boje": ["crvena", "crna", "zuta"] 
}
print(recnik["godina"]) 		# Ispisuje 1964
print(recnik.get("model")) 		# Ispisuje 'Mustang'

# Primer 59
recnik = {
    "marka": "Ford",
    "model": "Mustang",
    "godina": 1964,
    "boje": ["crvena", "crna", "zuta"] 
}

# Ispisuje dict_keys(['marka', 'model', 'godina', 'boje'])
kljucevi = recnik.keys()
print(kljucevi) 

# Ispisuje dict_values(['Ford', 'Mustang', 1964, ['crvena', 'crna', 'zuta']])
vrednosti = recnik.values()
print(vrednosti) 

# Ispisuje dict_items([('marka', 'Ford'), ('model', 'Mustang'), ('godina', 1964), ('boje', ['crvena', 'crna', 'zuta'])])
elementi = recnik.items()
print(elementi) 

# Primer 60
recnik = {
    "marka": "Ford",
    "model": "Mustang",
    "godina": 1964 
}

# Ispisuje {'marka': 'Ford', 'model': 'Mustang', 'godina': 2000}
recnik["godina"] = 2000
print(recnik) 
# Ispisuje {'marka': 'Ford', 'model': 'Mustang', 'godina': 2000, 'boja': 'crvena'}
recnik["boja"] = "crvena"
print(recnik) 

# Ispisuje {'marka': 'Ford', 'model': 'Mustang', 'godina': 2020, 'boja': 'crvena'}
recnik.update({"godina": 2020})
print(recnik) 
# Ispisuje {'marka': 'Ford', 'model': 'Mustang', 'godina': 2020, 'boja': 'crvena', 'cena': 100000}
recnik.update({"cena": 100000})
print(recnik) 

# Primer 61
recnik = {
    "marka": "Ford",
    "model": "Mustang",
    "godina": 1964,
    "boje": ["crvena", "crna", "zuta"] 
}

# Ispisuje {'model': 'Mustang', 'godina': 1964, 'boje': ['crvena', 'crna', 'zuta']}
recnik.pop("marka")
print(recnik)
# Ispisuje {'godina': 1964, 'boje': ['crvena', 'crna', 'zuta']}
del recnik["model"]
print(recnik) 
# Ispisuje {'godina': 1964}
recnik.popitem()
print(recnik)
# Ispisuje {}
recnik.clear()
print(recnik) 
# Greska! NameError: name 'recnik' is not defined.
del recnik
print(recnik) 

