* https://babeljs.io/en/setup#installation
* npm init --yes
* npm install express body-parser --save
* npm install --save-dev @babel/core
* npm install @babel/preset-env --save-dev
* package.json  "type": "module"
* scripts "start": "nodemon src/index.js --exec babel-node --presets babel-preset-env"

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
