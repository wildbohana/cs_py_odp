# 1. Dodeliti vrednost sledećeg izraza promenljivoj x: 5^2 + 3/4
x = 5 ** 2 + 3/4
print("Rezultat: ", x)

# 2. Neka je a = 17, a b = 3. Odrediti količnik i ostatak pri deljenju a sa b. Zapisati ih u promenljive kolicnik i ostatak.
a = 17
b = 3
kolicnik = a/b
ostatak = a%b
print("Količnik: ", kolicnik)
print("Ostatak: ", ostatak)

# 3. Celobrojno podeliti kolicnik sa 2, a zatim rezultat uvećati tri puta.
novi = kolicnik // 2
novi *= 3
print("Treći: ", novi)

#####

# 1. Napisati logički izraz koji će vratiti tačno ukoliko se a nalazi između 5 i 10, uključujući ih.
a = int(input("Unesite neki broj: "))
i1 = a>=5 and a<=10
print("Prvi logički izraz: ", i1)

# 2. Napisati logički izraz koji će vratiti tačno ukoliko je a strogo manje od –10 ili strogo veće od 10.
i2 = a>10 or a<-10
print("Drugi logički izraz:", i2)

# 3. Negirati logičke izraze iz prethodna dva zadatka.
print("Negirani izrazi")
print(not(i1), not(i2), sep=', ')

#####

# 1. Tražiti od korisnika da unese dva realna broja, sabrati ih i ispisati rezultat na ekran.
r1 = float(input("Unesite prvi realan broj: "))
r2 = float(input("Unesite drugi realan broj: "))
print("Rezultat r1+r2 = ", r1+r2)

# 2. Tražiti od korisnika da unese tri cela broja, koji redom predstavljaju dan, mesec i godinu, 
# a zatim ih ispisati na ekran u sledećem formatu: dd/mm/yyyy
dan = input("Unesite dan: ")
mesec = input("Unesite mesec: ")
godina = input("Unesite godinu: ")
print(dan, mesec, godina, sep='/')

#####

# 1. Tražiti od korisnika da unese neki tekst, prebaciti ga u mala slova, obrisati sve bele karaktere sa oba kraja tog teksta i podeliti ga po razmaku.
unos = input("Unesite neki string: ")
print(unos.lower().strip().split(" "))

# 2. Tražiti od korisnika da unese neki tekst i zameniti svaku pojavu reči ’cao’ sa ’zdravo’.
drugi_unos = input("Unesite neki string: ")
print(drugi_unos.replace('cao', 'zdravo'))

# 3. Tražiti od korisnika da unese neki tekst i napisati sledeče logičke izraze:
# a. ’je’ se nalazi u tekstu
# b. ’sam’ se ne nalazi u tekstu
# c. Prvo slovo je ’A’
# d. Dužina teksta je različita od nule
treci_unos = input("Unesite neki string: ")
t1 = "je" in treci_unos
t2 = "sam" not in treci_unos
t3 = treci_unos[0] == "A"
t4 = len(treci_unos) != 0
print("T1, T2, T3, T4: ")
print(t1, t2, t3, t4, sep=", ")

# 4. Tražiti od korisnika da unese ime, prezime i godine, odvojene zarezom. Svaku vrednost sačuvati u posebnu promenljivu i zatim ih ispisati u sledećem formatu: „Marko Marković ima 20 godina.“
cetvrti_unos = input("Uneite ime, prezime i godine, odvojene zarezom: ")
ime, prz, god = cetvrti_unos.split(',')
ispis = "{} {} ima {} godina."
print(ispis.format(ime, prz, god))
