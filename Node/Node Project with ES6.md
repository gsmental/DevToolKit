* https://babeljs.io/en/setup#installation
* npm init --yes
* npm install express body-parser --save
* npm install --save-dev @babel/core
* npm install @babel/preset-env --save-dev
* package.json  "type": "module"
* scripts "start": "nodemon src/index.js --exec babel-node --presets babel-preset-env"

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


