import socket
from constants import actions, PORT, ADDRESS

client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
client.connect((ADDRESS, PORT))
print("Client is connected to service.")

def create_message(action, index_num, first_name="", last_name="", average_grade=0):
    list_of_values = [action, index_num]
    if action == actions[1] or action == actions[2]:
        list_of_values.append(first_name)
        list_of_values.append(last_name)
        list_of_values.append(average_grade)
    message = ",".join(list_of_values)   
    return message.encode()

while True: 
    action = int(input("Choose an operation \n1.Add student \n2.Modify student \n3.Read student \n4.Delete student \n ")) 
    if not action : break 
    if action == 1: # CREATE        
        index_num = input("Index number -> ")
        first_name = input("First name -> ")
        last_name = input("Last name -> ")
        average_grade = input("Average grade -> ")
        client.send(create_message(actions[action], index_num ,first_name ,last_name ,average_grade))
        print(client.recv(1024).decode())
    elif action == 2: # UPDATE        
        index_num = input("Index number -> ")
        first_name = input("First name -> ")
        last_name = input("Last name -> ")
        average_grade = input("Average grade -> ")
        client.send(create_message(actions[action], index_num ,first_name ,last_name ,average_grade))
        print(client.recv(1024).decode())
    elif action == 3: # READ
        index_num = input("Index number -> ")
        client.send(create_message(action= actions[action], index_num=index_num))
        print(client.recv(1024).decode())        
    elif action == 4: # DELETE
        index_num = input("Index number -> ")
        client.send(create_message(action = actions[action], index_num=index_num))
        print(client.recv(1024).decode())
    else:
        print("Plese try valid operation")
        continue

client.close() 
print("Connection closed.")