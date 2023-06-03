import socket
from student import Student

# Potrebne funkcije
def dodaj_studenta(student:Student) -> str:
    if student.broj_indeksa in studenti:
        return "Student sa tim brojem indeksa vec postoji."
    studenti[student.broj_indeksa] = student
    return "Student je uspesno dodat."

def obrisi_studenta(indeks:str) -> str:
    if indeks not in studenti:
        return "Student sa tim brojem indeksa ne postoji."
    del studenti[indeks]
    return "Student je uspesno obrisan."

def izmeni_studenta(student:Student) -> str:
    if student.broj_indeksa not in studenti:
        return "Student sa tim brojem indeksa ne postoji."
    studenti[student.broj_indeksa] = student
    return "Student je uspesno azuriran."

def ispisi_studente() -> str:
	if len(studenti) == 0:
		return "Nema studenata."
	ispis = ""
	for indeks in studenti:
		ispis += str(studenti[indeks])
	return ispis

# main - sort of
server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.bind(('localhost', 6000))
server.listen()
print("Server je pokrenut i ceka klijente.")

# Rečnik
studenti = {}

kanal, adresa = server.accept()
print(f"Klijent {adresa} se povezao na server.")

while True:
	poruka = kanal.recv(1024).decode()
	if not poruka: break
	print(f"Primljena poruka: {poruka}")
	
	delovi = poruka.strip().split(":")
	akcija = delovi[0]
	student = delovi[1] if len(delovi) > 1 else ""
	
	if akcija == "dodaj":
		student = student.split("|")
		student = Student(student[0], student[1], student[2], student[3])
		poruka = dodaj_studenta(student)
	elif akcija == "obrisi":
		poruka = obrisi_studenta(student)
	elif akcija == "izmeni":
		student = student.split("|")
		student = Student(student[0], student[1], student[2], student[3])
		poruka = izmeni_studenta(student)
	elif akcija == "ispis":
		poruka = ispisi_studente()
		
	kanal.send(poruka.encode())
	
print(f"Klijent {adresa} se odvezao.")
kanal.close()	# kanal ili server ???
