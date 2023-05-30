import socket
from student import Student
from constants import actions, PORT, ADDRESS

students = {}
students["PR1/2020"] = Student("Petar", "Petrović", "PR1/2020", 10.0)
students["PR2/2020"] = Student("Marko", "Marković", "PR2/2020", 9.0)
students["PR3/2020"] = Student("Jovan", "Jovanović", "PR3/2020", 8.0)
students["PR4/2020"] = Student("Milan", "Milanović", "PR4/2020", 7.0)
students["PR5/2020"] = Student("Mirko", "Mirković", "PR5/2020", 6.0)

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.bind((ADDRESS, PORT))
server.listen()
print("Server opened.")

channel, address = server.accept()
print(f"Server accepted connection from adress: {address}")

def execute_action(message):
    student = message.split(",")
    action = student[0]
    index = student[1]
    if action == actions[1]: # CREATE
        if index in students:
            message = f"Student with index number {index} already exists in the database!"
            channel.send(message.encode())
            print(message)
            return
        students[index] = Student(student[2], student[3], index, student[4])
        message = f"Student with index number {index} successfully added in the database."
        channel.send(message.encode())
        print(message)
    elif action == actions[2]: # UPDATE
        if index not in students:
            message = f"Student with index number {index} does not exist in the database!"
            channel.send(message.encode())
            print(message)
            return
        students[index] = Student(student[2], student[3], index, student[4])
        message = f"Student with index number {index} successfully modified."
        channel.send(message.encode())
        print(message)
    elif action == actions[3]: # READ
        if index not in students:
            message = f"Student with index number {index} does not exist in the database!"
            channel.send(message.encode())
            print(message)
            return
        channel.send(students[index].__str__().encode())
        print(f"Student with index number {index} read successfully!")
    elif action == actions[4]: # DELETE
        if index not in students:
            message = f"Student with index number {index} does not exist in the database!"
            channel.send(message.encode())
            print(message)
            return
        del students[index]
        message = f"Student with index number {index} was successfully deleted."
        channel.send(message.encode())
        print(message)

while True: 
    message = channel.recv(1024).decode()    
    if not message : break
    execute_action(message)
    
print("Server se gasi.")
server.close()


    
