import socket 

# Potrebne funkcije
def dodaj_studenta():
    ime = input("Unesite ime studenta: ")
    prezime = input("Unesite prezime studenta: ")
    indeks = input("Unesite broj indeksa studenta: ")
    ocene = input("Unesite ocene studenta odvojene razmakom: ").strip()
    return f'{ime}|{prezime}|{indeks}|{ocene}'

def obrisi_studenta():
    indeks = input("Unesite indeks studenta za brisanje: ")
    return indeks

def izmeni_studenta():
    indeks = input("Unesite indeks studenta za azuriranje: ")
    ime = input("Unesite novo ime studenta: ")
    prezime = input("Unesite novo prezime studenta: ")
    ocene = input("Unesite nove ocene studenta odvojene razmakom: ").strip()
    return f"{ime}|{prezime}|{indeks}|{ocene}"

# main - sort of lol
klijent = socket.socket(socket.AF_INET, socket.SOCK_STREAM) 
klijent.connect(('localhost', 6000)) 
print("Veza sa serverom je uspostavljena.") 

while True:
	poruka = input("Unesite akciju (dodaj / obrisi / izmeni / ispis): ") 
	student:str = ""
	match poruka:
		case "dodaj":
			student = dodaj_studenta()
			poruka = poruka + ":" + student
		case "obrisi":
			student = obrisi_studenta()
			poruka = poruka + ":" + student
		case "izmeni":
			student = izmeni_studenta()              
			poruka = poruka + ":" + student
		case "ispis":
			poruka
			
	klijent.send(poruka.encode())
	if not poruka: break
	
	poruka = klijent.recv(1024).decode()
	if not poruka: break
	print("Rezultat je:\n" + poruka)
	
print("Veza se zatvara.") 
klijent.close()
