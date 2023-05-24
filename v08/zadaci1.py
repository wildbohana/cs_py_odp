# Zadatak za liste
lista = ["jabuke", "banane", "kivi", "mandarine", "grozdje", "mango"]

# 1. Ispiši drugi element.
print(lista[1])

# 2. Promeni treći element na “kupine”.
lista[2] = "kupine"
print(lista[2])
print(lista)

# 3. Dodaj vrednost “narandže” na kraj liste.
lista.append("narandze")
print(lista)

# 4. Ubaci vrednost “limun” na indeks 2.
lista.insert(2,"limun")
print(lista)

# 5. Ukloni vrednost “mandarine” iz liste.
lista.remove("mandarine")
print(lista)

# 6. Ispiši elemente od drugog zaključno sa petim.
print(lista[1:5])

# 7. Ispiši poslednji element liste.
print("Poslednji element", lista[-1])

# 8. Ispiši dužinu liste.
print(len(lista))

# 9. Sortiraj listu.
lista.sort()
print(lista)

# 10. Obriši promenljivu lista.
del lista

# Zadatak za torke
torka = ("jabuke", "banane", "kivi", "mandarine", "grozdje", "mango")

# 1. Ispiši prva četiri elementa.
print(torka[:4])

# 2. Ispiši poslednja dva elementa.
print(torka[-2:])

# 3. Kreiraj promenljivu za vrednost “mango” 
# i promenljivu koja će sadržati sve ostale vrednosti torke.
(*sveOstalo, mango) = torka
print(sveOstalo)
print(mango)

# Zadatak za skupove
skup = {"jabuke", "banane", "kivi", "mandarine", "grozdje", "mango"}

# 1. Dodaj vrednost “narandze”.
skup.add("narandze")
print(skup)

# 2. Dodaj skupu sledeću listu: [“visnje”, “jagode”, “maline”, “kupine”].
lista = ["visnje", "jagode", "maline", "kupine"] 
skup.update(lista)
print(skup)

# 3. Tražiti od korisnika da unese vrednost koju želi da ukloni iz skupa. 
# Brisanje izvršiti tako da program ne izbaci grešku ukoliko je korisnik 
# uneo nepostojeću vrednost.
rec = input("Unesite vrednost koju zelite da obrisete iz skupa koji je gore naveden: ")
skup.discard(rec)
print(skup) 

# Zadatak za rečnike
recnik = {
	"marka": "Ford",
	"model": "Mustang",
	"godina": 1964
}
print(recnik)

# 1. Ispiši vrednost pod ključem “model” na oba načina.
print(recnik["marka"])
print(recnik.get("marka"))

# 2. Promeni vrednost pod ključem “godina” na 2003.
recnik["godina"] = 2003
recnik.update({"godina": 2003})
print(recnik)

# 3. Dodaj novi par ključ- vrednost koji će definisati da je boja žuta.
recnik["boja"] = "zuta"
print(recnik)

# 4. Obrisati ključ “marka” iz rečnika.
# recnik.pop("marka")
del recnik["marka"]
print(recnik)

# 5. Obrisati sve parove ključ-vrednost iz rečnika.
recnik.clear()
print(recnik)

