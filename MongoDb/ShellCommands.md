**```code```**

* mongo port--27018  (if u want to connect on different port
* show dbs >>**```selecg * from sys.databases```**
* use {dbname}  >>```use mydb``` it does not matter db exists or not, but it will visible when minimum one collection create
* db.flightData.insertOne{**json**}   >> **```Insert into```**
* db.flightData.deleteOne({flightName:”Air India”}) >> **```DELETE FROM flightData WHERE flightName='Air India'```** 
* db.flightData.updateOne({distance:12000},{$set: {flightName:”Jetairways”,pilotName:”Gurpreet Singh”}}) **```UPDATE flightData set flightName='', pilotName='' WHERE distance=12000```**, if field does not exists in document it will create field automatecally or if exists it will update value in field
* db.flightData.find({flightName:”Air India”}) >> **```SELECT * FROM flightData WHERE flightName='Air India'```** 
* db.flightData.find({price:{@gt:12000}}) >> **```SELECT * FROM flightData WHERE price>12000'```** 

| Mongo Command       | SQL Command     | Remarks    |
| :------------- | :----------: | -----------: |
|  db.flightData.find({flightName:”Air India”}) | SELECT * FROM flightData WHERE flightName='Air India   |     |
| db.country.updateMany({countryName:{$ne:"India"}},{$set:{isActive:false}})|UPDATE country SET isActive=0 where countryName<>'India' |
| db.country.find({isActive:true}, { _id: 0 })|SELECT * FROM country WHERE isActive=1 |{ _id: 0 }  exclude particular column
| db.stats()||statics related to database like database size,no views,no of tables etc. |
| type of  db.flightData.findOne().flightName||to getting datatype of particular field/column |
|db.country.update({},{$unset: {countryId: 1}}, {multi: true})| alter table country drop column countryId | drop field in collection, {multi-true} meaning from all rows|
