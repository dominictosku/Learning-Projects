from pymongo import MongoClient
import bson


class MongoDb:
    def __init__(self, connectionString, _id=None):
        if _id is not None:
            self._id = _id
        connectionString = connectionString
        client = MongoClient(connectionString)
        self.client = client
        self.database = ""
        self.collection = ""

    def setDatabase(self, dbName):
        self.database = self.client[dbName]
        return

    def getDatabase(self):
        dblist = self.client.list_database_names()
        return dblist

    def setCollection(self, collectionName):
        self.collection = self.database[collectionName]
        return self.collection

    def getCollection(self):
        return self.database.list_collection_names()

    def insertSoftware(self, SoftwareName, manufacturer, Keys):
        json = {"Name": SoftwareName, "Hersteller": manufacturer, "Keys": Keys}
        return self.collection.insert_one(json)

    def insertKeyForSoftware(self, id, key):
        query = {"_id": bson.ObjectId(id)}
        newvalues = {"$push": {"Keys" : key} }
        return self.collection.update_one(query, newvalues)

    def getSoftwares(self):
        return self.collection.find("")

    def getKeys(self, id):
        query = {"_id": bson.ObjectId(id)}
        return self.collection.find_one(query)
    
    def printDocument(self, id):
        query = {"_id" : bson.ObjectId(id)}
        document = self.collection.find_one(query)
        print(document)
