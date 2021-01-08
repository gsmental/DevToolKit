* https://babeljs.io/en/setup#installation
* npm init --yes
* npm install express body-parser --save
* npm install --save-dev @babel/core @babel/node @babel/preset-env -D 
* npm install @babel/preset-env --save-dev
* npm i @babel/plugin-transform-runtime -D
* npm i -g babel-node
* scripts "start": "nodemon --exec babel-node --require dotenv/config src/index.js"
* create file in root **.babelrc**
```javascript
{
    "presets": ["@babel/preset-env"],
    "plugins": ["@babel/plugin-transform-runtime"]
}
```


### Simple express
```javascript
// **src/index.js**
import express from 'express';
const app = express()
app.use(express.json())

app.get('/', (req, res) => {
  return res.status(200).send({'message': 'YAY! Congratulations! Your first endpoint is working'});
})

app.listen(8099)
console.log('app running on port ', 8099);
```

### Mongodb Connection
```javascript
// **src/index.js   Mongodb coonection**

import express from 'express';
import bodyParser from 'body-parser'
import mongoose from "mongoose";
import cors from "cors";
import dotenv from 'dotenv'
dotenv.config()
// if you type Port number in connection, sometime It did not responde but shows connect with db , so try it without port
// mongoose.connect("mongodb://localhost/informmedb",{useNewUrlParser:true,useUnifiedTopology:true}, (err) => {
mongoose.connect(`mongodb+srv://${process.env.DB_USER}:${process.env.DB_PASS}@imcluster.hghnl.mongodb.net/${process.env.DB_NAME}?retryWrites=true&w=majority`,{useNewUrlParser:true,useUnifiedTopology:true},(err)=>{ 
  if (!err) {
    console.log("Mongo Connect");
    const app = express()
    app.use(express.json())
    app.use(bodyParser.json());
    
     // CORS middleware with express
     app.use(
      cors({
        origin: true,
        credentials: true
      })
    );
    
    app.get('/', (req, res) => {
      return res.status(200).send({'message': 'YAY! Congratulations! Your first endpoint is working'});
    })
    
    app.listen(8099)
    console.log('app running on port ', 8099);

  } else {
    console.log("Mongo Error: " + JSON.stringify(err,undefined, 2));
  }
});
```


### router Import
```javascript
//src/index.js  
import SignUpController from './controllers/v1/SignUp/SignUpController';

app.use('/api/v1/signup/',SignUpController);

//SignUpController.js
import express from "express";
const SignUpController = express.Router();

SignUpController.get("/countryList",  (req, res,next) => {
  res.json('this is testing from controller');
});
export default SignUpController;

//url
http://localhost:8099/api/v1/signup/countryList
```
