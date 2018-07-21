#print("Cong 2 so")
#num1=input("Nhap so 1: ")
#num2=input("Nhap so 2: ")
#sum=float(num1)+float(num2)
#print("Tong: "+str(sum))
#print("Tong: {0} ".format(sum))

from Student import Student

print("Nhap diem cho hoc sinh")
name = input("Nhap ten hoc sinh: ")
age = input("Nhap tuoi: ")
mC = input("Nhap diem mon C: ")
mHTML = input("Nhap diem mon HTML: ")
mJava = input("Nhap diem Java: ")

studentA= Student(name,age,mC,mHTML,mJava)

print("---------------------------------")
print(studentA.display())
print("---------------------------------")
