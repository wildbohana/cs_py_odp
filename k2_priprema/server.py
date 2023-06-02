import socket
from student import Student

studenti = {}

def server():
    server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server.bind(('localhost', 6000))
    server.listen()
    print("Server je pokrenut i ceka klijente.")
    
    klijent, adresa = server.accept()
    print(f"Klijent {adresa} se povezao na server.")
    
    while True:
        poruka = klijent.recv(1024).decode()
        if not poruka: break
        print(f"Primljena poruka: {poruka}")
        
        parts = poruka.strip().split(":")
        action = parts[0]
        student = parts[1] if len(parts) > 1 else ""
        
        if action == "add":
            student = student.split("|")
            student = Student(student[0], student[1], student[2], student[3])
            poruka = add_student(student)
        elif action == "delete":
            poruka = delete_student(student)
        elif action == "edit":
            student = student.split("|")
            student = Student(student[0], student[1], student[2], student[3])
            poruka = edit_student(student)
        elif action == "print":
            poruka = print_students()
            
        klijent.send(poruka.encode())
        
    print(f"Klijent {adresa} se diskonektovao.")
    klijent.close()

def add_student(student:Student) -> str:
    if student.broj_indeksa in studenti:
        return "Student sa tim brojem indeksa vec postoji."
    studenti[student.broj_indeksa] = student
    return "Student je uspesno dodat."

def delete_student(indeks:str) -> str:
    if indeks not in studenti:
        return "Student sa tim brojem indeksa ne postoji."
    del studenti[indeks]
    return "Student je uspesno obrisan."

def edit_student(student:Student) -> str:
    if student.broj_indeksa not in studenti:
        return "Student sa tim brojem indeksa ne postoji."
    studenti[student.broj_indeksa] = student
    return "Student je uspesno azuriran."

def print_students() -> str:
    if len(studenti) == 0:
        return "Nema studenata."
    return "\n".join(["\n=======================\n"+str(studenti[indeks]) for indeks in studenti])

if __name__ == "__main__":
    server()
    studenti.clear()
