import socket
from student import Student

studenti = {}
studenti["PR1/2020"] = Student("Petar", "Petrović", "PR1/2020", 10.0)
studenti["PR2/2020"] = Student("Marko", "Marković", "PR2/2020", 9.0)
studenti["PR3/2020"] = Student("Jovan", "Jovanović", "PR3/2020", 8.0)
studenti["PR4/2020"] = Student("Milan", "Milanović", "PR4/2020", 7.0)
studenti["PR5/2020"] = Student("Mirko", "Mirković", "PR5/2020", 6.0)

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.bind(('localhost', 6000))
server.listen()
print("Server je pokrenut.")

kanal, adresa = server.accept()
print(f"Prihvacena je konekcija sa adrese: {adresa}")

while True: 
    broj_indeksa = kanal.recv(1024).decode()
    if not broj_indeksa: break
    print(f"Traži se student sa brojem indeksa: {broj_indeksa}")
    student = studenti[broj_indeksa].__str__()		# Interesting
    print(f"Student: {student}")
    kanal.send(student.encode())
    
print("Server se gasi.")
server.close()
