import socket
from student import Student
from constants import akcije, PORT, ADDRESS

studenti = {}
studenti["PR1/2020"] = Student("Petar", "Petrović", "PR1/2020", 10.0)
studenti["PR2/2020"] = Student("Marko", "Marković", "PR2/2020", 9.0)
studenti["PR3/2020"] = Student("Jovan", "Jovanović", "PR3/2020", 8.0)
studenti["PR4/2020"] = Student("Milan", "Milanović", "PR4/2020", 7.0)
studenti["PR5/2020"] = Student("Mirko", "Mirković", "PR5/2020", 6.0)

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.bind((ADDRESS, PORT))
server.listen()
print("Server je otovren.")

kanal, adresa = server.accept()
print(f"Server accepted connection from adress: {adresa}")

def izvrsi_akciju(poruka):
    delovi = poruka.split(",")
    akcija = delovi[0]
    indeks = delovi[1]
    
    if akcija == akcije[1]: # CREATE
        if indeks in studenti:
            poruka = f"Student sa brojem indeksa {indeks} već postoji u bazi!"
            kanal.send(poruka.encode())
            print(poruka)
            return
        studenti[indeks] = Student(delovi[2], delovi[3], indeks, delovi[4])
        poruka = f"Student sa brojem indeksa {indeks} je uspešno dodat u bazu."
        kanal.send(poruka.encode())
        print(poruka)
        
    elif akcija == akcije[2]: # UPDATE
        if indeks not in studenti:
            poruka = f"Student sa brojem indeksa {indeks} ne postoji u bazi!"
            kanal.send(poruka.encode())
            print(poruka)
            return
        studenti[indeks] = Student(delovi[2], delovi[3], indeks, delovi[4])
        poruka = f"Student sa brojem indeksa {indeks} je uspešno izmenjen."
        kanal.send(poruka.encode())
        print(poruka)
        
    elif akcija == akcije[3]: # READ
        if indeks not in studenti:
            poruka = f"Student sa brojem indeksa {indeks} ne postoji u bazi!"
            kanal.send(poruka.encode())
            print(poruka)
            return
        kanal.send(studenti[indeks].__str__().encode())
        print(f"Student sa brojem indeksa {indeks} je uspešno pročitan!")
        
    elif akcija == akcije[4]: # DELETE
        if indeks not in studenti:
            poruka = f"Student sa brojem indeksa {indeks} ne postoji u bazi!"
            kanal.send(poruka.encode())
            print(poruka)
            return
        del studenti[indeks]
        poruka = f"Student sa brojem indeksa {indeks} je uspešno izbrisan."
        kanal.send(poruka.encode())
        print(poruka)

while True: 
    poruka = kanal.recv(1024).decode()    
    if not poruka: break
    izvrsi_akciju(poruka)
    
print("Server se gasi.")
server.close()
