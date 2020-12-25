## Install 
* npm init -- fill detail as required


###ExpressJs
* npm install express --save
```js
const express = require('express')
const app = express()
const port = 3000

app.get('/', (req, res) => {
  res.send('Hello World!')
})

app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`)
})
```

### MERN
* npm i -s express body-parser cors mongoose dotenv

