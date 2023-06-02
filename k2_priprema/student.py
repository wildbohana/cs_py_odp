class Student:
	ime:str = ""
	prezime:str = ""
	broj_indeksa:str = ""
	ocene:list = []

	def __init__(self, ime:str, prezime:str, broj_indeksa:str, ocene:str):
		self.ime = ime
		self.prezime = prezime
		self.broj_indeksa = broj_indeksa
		self.ocene = [float(x) for x in ocene.split(" ")]
        
	def __str__(self) -> str:
		return f"Broj indeksa: {self.broj_indeksa}\nIme: {self.ime}\nPrezime: {self.prezime}\nProsek: {str(self.izracunaj_prosek())}"
    
	def izracunaj_prosek(self) -> float:
		return sum(self.ocene) / len(self.ocene)
