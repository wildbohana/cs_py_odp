import socket
from constants import akcije, PORT, ADDRESS

klijent = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
klijent.connect((ADDRESS, PORT))
print("Klijent je spojen na server.")

def create_message(akcija, broj_indeksa, ime="", prezime="", prosek=0):
    lista_vrednosti = [akcija, broj_indeksa]
    if akcija == akcije[1] or akcija == akcije[2]:
        lista_vrednosti.append(ime)
        lista_vrednosti.append(prezime)
        lista_vrednosti.append(prosek)
    poruka = ",".join(lista_vrednosti)   
    return poruka.encode()

while True: 
	akcija = int(input("Izaberi operaciju \n1. Dodaj studenta \n2. Izmeni studenta \n3. Pročitaj informacije o studentu \n4. Obriši studenta \n ")) 
	if not akcija: break
		
	if akcija == 1:		# CREATE        
		broj_indeksa = input("Broj indeksa -> ")
		ime = input("Ime -> ")
		prezime = input("Prezime -> ")
		prosek = input("Prosek -> ")
		klijent.send(create_message(akcije[akcija], broj_indeksa, ime, prezime, prosek))
		print(klijent.recv(1024).decode())

	elif akcija == 2:	# UPDATE        
		broj_indeksa = input("Broj indeksa -> ")
		ime = input("Ime -> ")
		prezime = input("Prezime -> ")
		prosek = input("Prosek -> ")
		klijent.send(create_message(akcije[akcija], broj_indeksa, ime, prezime, prosek))
		print(klijent.recv(1024).decode())

	elif akcija == 3:	# READ
		broj_indeksa = input("Broj indeksa -> ")
		klijent.send(create_message(akcija= akcije[akcija], broj_indeksa=broj_indeksa))
		print(klijent.recv(1024).decode())   
		     
	elif akcija == 4:	# DELETE
		broj_indeksa = input("Broj indeksa -> ")
		klijent.send(create_message(akcija = akcije[akcija], broj_indeksa=broj_indeksa))
		print(klijent.recv(1024).decode())
		
	else:
		print("Nevalidna operacija, pokušaj ponovo.")
		continue

klijent.close() 
print("Zatvorena veza sa serverom.")
