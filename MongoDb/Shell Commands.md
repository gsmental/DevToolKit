```code```

* mongo port--27018  (if u want to connect on different port
* show dbs >>```selecg * from sys.databases```
* use {dbname}  >>```use mydb``` it does not matter db exists or not, but it will visible when minimum one collection create
* db.flightData.insertOne{**json**}   >> ```Insert into```
* db.flightData.deleteOne({flightName:”Air India”}) >> ```DELETE FROM flightData WHERE flightName='Air India'``` 
* db.flightData.updateOne({distance:12000},{$set {flightName:”Jetairways”,pilotName:”Gurpreet Singh”}}) ```UPDATE flightData set flightName='', pilotName='' WHERE distance=12000```

