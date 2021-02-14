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
