import socket 

def main():
    klijent = socket.socket(socket.AF_INET, socket.SOCK_STREAM) 
    klijent.connect(('localhost', 6000)) 
    print("Veza sa serverom je uspostavljena.") 
    
    while True:
        poruka = input("Unesite akciju:") 
        student:str = ""
        match poruka:
            case "add":
                student = add_student()
                poruka = poruka + ":" + student
            case "delete":
                student = delete_student()
                poruka = poruka + ":" + student
            case "edit":
                student = edit_student()              
                poruka = poruka + ":" + student
            case "print":
                poruka
                
        klijent.send(poruka.encode())
        if not poruka: break
        
        poruka = klijent.recv(1024).decode()
        if not poruka: break
        print(f"Rezultat je:\n{poruka}")
        
    print("Konekcija se zatvara.") 
    klijent.close()

def add_student():
    ime = input("Unesite ime studenta: ")
    prezime = input("Unesite prezime studenta: ")
    indeks = input("Unesite broj indeksa studenta: ")
    ocene = input("Unesite ocene studenta odvojene razmakom: ").strip()
    return f'{ime}|{prezime}|{indeks}|{ocene}'

def delete_student():
    indeks= input("Unesite indeks studenta za brisanje: ")
    return indeks

def edit_student():
    indeks = input("Unesite indeks studenta za azuriranje: ")
    ime = input("Unesite novo ime studenta: ")
    prezime = input("Unesite novo prezime studenta: ")
    ocene = input("Unesite nove ocene studenta odvojene razmakom: ").strip()
    return f"{ime}|{prezime}|{indeks}|{ocene}"

if __name__ == "__main__":
    main()
