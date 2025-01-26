from modules.MongoDB import MongoDb
import os

db = MongoDb(os.environ.get("CS_MONGODB"))


def checkForDb(dbs):
    if "Softwares" in dbs:
        return
    print("No database with name Software exists, do you want to create one?")
    print("Ja/Nein")
    accept = input().lower()
    if accept == "ja":
        db.setDatabase("Softwares")
        return
    endProgram()


def checkForCollection(collections):
    if "Keys" in collections:
        return
    print("No collection with name Keys exists, do you want to create one?")
    print("Ja/Nein")
    accept = input().lower()
    if accept == "ja":
        db.setCollection("Keys")
        return
    endProgram()


def insertSoftware():
    print("Enter name")
    name = input()
    print("Enter manufacturer")
    manufacturer = input()
    print("Enter keys, seperated by whitespace")
    keys = []
    keysInput = input()
    keysInput.split(" ")
    keys.append(keysInput)
    document = db.insertSoftware(name, manufacturer, keys)
    db.printDocument(document.inserted_id)


def getKeyForSoftware(id):
    document = db.getKeys(id)
    if(document is None):
        print("No entry for this id")
        return
    for keys in document["Keys"]:
        print("-", keys)
    print("Enter to continue")
    input()


def userInput():
    print("i: insert software, k: get keys, ik: insert key for software")
    prompt = input()
    match prompt:
        case "i":
            insertSoftware()
        case "k":
            print("Enter id for Software")
            id = input()
            getKeyForSoftware(id)
        case "ik":
            print("Enter id for Software")
            id = input()
            print("Enter Key")
            key = input()
            db.insertKeyForSoftware(id, key)
            db.printDocument(id)
            print("Successfully inserted key")

    return prompt


def endProgram():
    exit()

print("Checking for connection...")
try:
    connected = db.client.server_info()
except:
    print("Connection could not be established")
    endProgram()

print("Connected to mongo server")

dbs = db.getDatabase()

checkForDb(dbs)
db.setDatabase("Softwares")

collections = db.getCollection()

continueProgram = checkForCollection(collections)

db.setCollection("Keys")

softwares = db.getSoftwares()
for software in softwares:
    print("-", software)
action = ""
while action != "q":
    action = userInput()
