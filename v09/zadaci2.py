# Zadaci za klase

# Zadatak 1
# Napisati klasu za studente FTNa. 
# Neka atribut fakultet bude zajednički za sve instance ove klase, 
# a neka se kroz konstruktor inicijalizuju ime, prezime i broj indeksa. 
# Definisati metodu koja će prilikom ispisa objekta ispisivati vrednosti ova četiri atributa. 
# Instancirati barem dva studenta i ispisati ih.
class Student:
	fakultet = "FTN"
	def __init__(self, ime, prezime, br_indeksa):
		self.ime = ime
		self.prezime = prezime
		self.br_indeksa = br_indeksa
    
	def __str__(self):
		return f"{self.fakultet} {self.br_indeksa} {self.ime} {self.prezime}"

student1 = Student("Marko", "Markovic", "PR1/2020")
student2 = Student(ime ="Jovan", prezime = "Jovanovic", br_indeksa ="PR2/2020")
student3 = Student(prezime = "Petrovic", ime ="Petra", br_indeksa="PR3/2020")
student4 = Student(br_indeksa="PR4/2020", prezime = "Ivanovic", ime ="Ivana")

print("Studenti:")
print(student1)
print(student2)
print(student3)
print(student4)

# Zadatak 2
# Napisati klasu koja opisuje merenja visine po gradovima u Srbiji. 
# Potrebni atributi su: grad, drzava i kolekcija izmerenih vrednosti. 
# Pored metoda za inicijalizaciju i tekstualni prikaz objekata, 
# dodati i metodu koja računa prosečnu visinu za svaki grad. 
# Instancirati barem tri grada i za svaki ispisati prosečnu visinu. 
class Merenje:
	def __init__(self, grad, merenja):
		self.drzava = "Srbija"
		self.grad = grad
		self.merenja = merenja

	def __str__(self):
		return f"{self.drzava}, {self.grad}, {self.merenja}"

	def prosek(self):
		return sum(self.merenja)/len(self.merenja)

novi_sad = Merenje("Novi Sad", [1.75, 1.80, 1.65, 2.02, 1.90, 1.68, 1.73])
sombor = Merenje("Sombor", [1.85, 1.80, 1.75, 2.02, 1.95, 1.78, 1.83])
zrenjanin = Merenje("Zrenjanin", [1.75, 1.70, 1.67, 2.00, 1.80, 1.78, 1.73])

print("Prosecna visina po gradu:")
print(f"{novi_sad.grad}, prosečna visina: {novi_sad.prosek()}")
print(f"{sombor.grad}, prosečna visina: {sombor.prosek()}")
print(f"{zrenjanin.grad}, prosečna visina: {zrenjanin.prosek()}")

# Zadatak 3
# Napisati klasu Ucenik sa poljima: ime, prezime, ocene. 
# Ocene su rečnik, pri čemu je ključ naziv predmeta, a vrednost lista ocena iz tog predmeta. 
# Konstruktor kao parametre prihvata samo ime i prezime, dok se rečnik popunjava metodom 
# za upis ocena, kojoj se prosleđuje predmet i ocena koja se upisuje. 
# Pored ove metode, potrebno je definisati metodu koja spram prosleđenog naziva predmeta
# računa zaključnu ocenu za taj predmet i smešta je u novi recnik – zakljucene_ocene. 
# Treća metoda računa prosek učenika spram svih zaključenih ocena.
class Ucenik:
	ocene = {}
	zakljucene_ocene = {}

	def __init__(self, ime, prezime):
		self.ime = ime
		self.prezime = prezime

	def upisi_ocenu(self, predmet, ocena):
		if predmet in self.ocene.keys():
			self.ocene[predmet].append(ocena)
		else:
			self.ocene[predmet] = [ocena]

	def zakljuci_ocenu(self, predmet):
		if predmet in self.ocene.keys() :
			zakljucna = round(sum(self.ocene[predmet])/len(self.ocene[predmet]))
			self.zakljucene_ocene[predmet] = zakljucna
			return zakljucna
		return None

	def prosek(self):
		return sum(self.zakljucene_ocene.values())/len(self.zakljucene_ocene.values())

	def __str__(self):
		return f"{self.ime} {self.prezime} ocene : {self.ocene}"
    
ucenik1 = Ucenik("Marko", "Markovic")
ucenik1.upisi_ocenu("matematika", 5)
ucenik1.upisi_ocenu("matematika", 4)
ucenik1.upisi_ocenu("matematika", 5)
ucenik1.upisi_ocenu("matematika", 5)

print(ucenik1)
print("Ocene: ", ucenik1.ocene)
print("Zakljucna ocena iz matematike: ",ucenik1.zakljuci_ocenu("matematika"))
print("Zakljucna ocena iz srpskog: ", ucenik1.zakljuci_ocenu("srpski"))

ucenik1.upisi_ocenu("srpski", 5)
ucenik1.upisi_ocenu("srpski", 4)
ucenik1.upisi_ocenu("srpski", 3)
ucenik1.upisi_ocenu("srpski", 5)

print("Ocene: ", ucenik1.ocene)
print("Zakljucna ocena iz srpskog: ", ucenik1.zakljuci_ocenu("srpski"))
print("Prosek ucenika", ucenik1.prosek())
