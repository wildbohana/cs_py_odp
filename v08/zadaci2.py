# Zadaci za grananje

# 1. Tražiti od korisnika da unese neki broj. 
# Ukoliko je taj broj manji od 0, ispiši “Uneli ste negativni broj.”
broj = float(input("Unesite neki broj: "))
if broj<0 : print("Uneli ste negativan broj")

# 2. Tražiti od korisnika da unese dva broja i sačuvati ih u promenljive a i b. 
# Skraćenim zapisom ifelse strukture ispisati onaj broj koji je veći, 
# odnosno poruku da su jednaki ukoliko je to slučaj.
a = int(input("Unesite prvi broj: "))
b = int(input("Unesite drugi broj: "))

# Prvi način
if a == b : print("Brojevi su jednaki")
elif a>b : print("Prvi broj je veci od drugog")
elif b>a : print("Drugi broj je veci od prvog")

# Drugi način
print("A") if a>b else print ("=") if a == b else print("B") 

# 3. Kreirati listu povrća, a zatim proveriti da li se “krompir” nalazi u listi. 
# Ukoliko se nalazi, ispisati odgovarajuću poruku, a ukoliko se ne nalazi, 
# proveriti da li se “grasak” nalazi u listu.
# Opet, ukoliko se nalazi, ispisati odgovarajuću poruku, a ukoliko se ne nalazi ispisati “Vreme je za nabavku.”
listaPovrca = ["paradajz", "grasak", "boranija", "luk"]
if "krompir" not in listaPovrca : 
    print("Krompir se ne nalazi u listi")
    if "grasak" in listaPovrca :
        print("Grasak se nalazi u listi")
    else : 
        print("Vreme je za nabavku")
else :
    print("Krompir se nalazi u listi")


# Zadaci za petlje

# 1. Kreirati listu brojeva i pomoću for petlje ispisati svaki od njih.
brojevi = [1,3,4,6,7,9,7,8,12,43]
for broj in brojevi : print(broj)

# 2. Kreirati torku logičkih vrednosti i pomoću for petlje ispisati svaku od njih.
torka = (True, False, True, False)
for clanTorke in torka: print(clanTorke)

# 3. Kreirati skup stringova i pomoću for petlje ispisati svaki od njih.
skup = {"nije", "tesko", "biti", "fin"}
for rec in skup : print(rec)

# 4. Kreirati proizvoljni rečnik i pomoću for petlje ispisati sve ključeve.
recnik = dict(ime = "Petar", prezime ="Mitic", nadimak="Pero", zanimanje ="glumac")
for kljuc in recnik.keys(): 
    print(kljuc)

# 5. Data je lista: lista = ["jabuke", "banane", "kivi", "mandarine", "grozdje", "mango"]. 
# Pomoću for petlje ispisivati element po element. Ukoliko se „kivi“ nalazi u listi, 
# preskočiti ga i nastaviti ispis od sledećeg elementa, 
# a ukoliko se „grozdje“ nalazi u listi prekinuti izvršavanje petlje.
lista = ["jabuke", "banane", "kivi", "mandarine", "grozdje", "mango"]
for voce in lista :
    if voce == "kivi" : continue
    if voce == "grozdje" : break
    print(voce)

# 6. Data je promenljiva i = 5. Ispisivati njenu vrednost u while petlji dokle god je ona manja ili jednaka 10.
i=5
while i<=10 :
    print(i)
    i+=1
    
# 7. Data je promenljiva i = 1. 
# Ispisivati njenu vrednost u while petlji dokle god je ona manja od 6,
# a kada prestane da bude manja, ispisati „Vrednost promenljive i više nije manja od 6“.
i=1
while i<6 :
    print(i)
    i+=1
else : 
    print (("Vrednost promenljive je {}, više nije manja od 6").format(i))
