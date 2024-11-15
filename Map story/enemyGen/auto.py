file=open("enemies.txt")
list1=file.read().split(",")
for x in range(len(list1)):
    list1[x]=list1[x].strip("“")
    list1[x]=list1[x].strip("”")
for x in range(len(list1)):
    print("enemy_names["+str(x+8)+"] = \""+list1[x]+"\";")
