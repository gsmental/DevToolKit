CentralErrorHandler.ts

```typescript
const CentralErrorHandler=(err:any, req:any, res:any, next:any)=> {
    console.log(err);
    
        if (err.name === 'UnauthorizedError') {
            // jwt authentication error
            return res.status(401).json({message: "The user is not authorized"})
        }
    
        if (err.name === 'ValidationError') {
            //  validation error
            return res.status(401).json({message: err})
        }
    
        // default to 500 server error
        return res.status(500).json(err);
    }
    
    export default CentralErrorHandler;
```



JwtAuth.ts
```typescript
import expressJwt from 'express-jwt';

const JwtAut:any = {};
JwtAut.JwtValidate=()=> {
    const secret:any = process.env.TOKEN_SECRET as string;
    //const api = process.env.API_URL;
    return expressJwt({
        secret,
        algorithms: ['HS256'],
       //isRevoked: isRevoked
    }).unless(
        {
        path: [
            // {url: /\/public\/uploads(.*)/ , methods: ['GET', 'OPTIONS'] },
            // {url: /\/api\/v1\/products(.*)/ , methods: ['GET', 'OPTIONS'] },
            // {url: /\/api\/v1\/categories(.*)/ , methods: ['GET', 'OPTIONS'] },
            // {url: /\/api\/v1\/orders(.*)/,methods: ['GET', 'OPTIONS', 'POST']},
            //`${api}/users/login`,
            //`${api}/users/register`,
            "/api/v1/web/webLogin/",
        ]
    }
    
    )
}

async function isRevoked(req:any, payload:any, done:any) {
    if(!payload.isAdmin) {
        done(null, true)
    }
    done();
}
export default JwtAut;
```




index.ts
```typescript
import JwtAuth from './Helper/JwtAuth';
import CentralErrorHandler from './Helper/CentralErrorHandler';

 // console.log("Mongo Connect");
    //const app = express()
    //app.use(express.json())
    //app.use(bodyParser.json());
    
    app.use(JwtAuth.JwtValidate());
    app.use(CentralErrorHandler);

```
