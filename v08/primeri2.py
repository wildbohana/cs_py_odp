# Pdf 28

# Primer 62
if 2 < 5:
    print("Dva je manje od pet.")

# Primer 63
a = 33
b = 200
if b > a:
    print("b je veće od a")
else:
    print("b nije veće od a")

# Primer 64
a = 33
b = 200
if b > a:
    print("b je veće od a")
elif a > b:
    print("a je veće od b")
else:
    print("a je jednako b")

# Primer 65
if a > b: print("a je veće od b")
print("A") if a > b else print("B")

# Primer 66
x = 41
if x > 10:
	print("x je veće od 10,")
	if x > 20:
		print("a veće je i od 20")
	else:
		print("ali nije veće od 20")

# Primer 67
lista = ["jabuka", "banana", "visnja"]
for x in lista:
    print(x)

rec = "jabuka"
for slovo in rec:
    print(slovo)

# Primer 68
for x in range(6):
	print(x) 		# Ispisuje 0 1 2 3 4 5

for x in range(2, 6):
	print(x) 		# Ispisuje 2 3 4 5

for x in range(2, 30, 3):
	print(x) 		# Ispisuje 2 5 8 11 14 17 20 23 26 29

# Primer 69
i = 1
while i < 6:
	print(i)
	i += 1

# Primer 70
for i in range(10):
    print(i)
    if i == 5:
        break

i = 1
while i < 6:
	print(i)
	if i == 3:
		break
	i += 1

# Primer 71
for i in range(1, 11):
    if i == 6:
        continue
    else:
        print(i, end=" ")

i = 0
while i < 10:
    if i == 5:
        i += 1
        continue
    print(i)
    i += 1

# Primer 72
n = 10
for i in range(n):
	pass

i = 0
while i < 6:
    i += 1
    pass

# Primer 73
for i in range(1, 4):
    print(i)
else:  
    print("Ovo se ispisuje na kraju.")

i = 0
while i < 4:
    i += 1
    print(i)
else:  
    print("Ovo se ispisuje na kraju.")
    