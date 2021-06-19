### NPM 
* npm install pg
* npm i --save-dev @types/pg


### .ENV
* db_User=fdgdfg
* db_host=101.215.321.210
* db_database=dbane
* db_password=fghfgh
* db_port=5432

### index.ts (root)
* import dotenv from 'dotenv';
* dotenv.config();


###  helper/dbConfig.ts
```js
import dotenv from 'dotenv';

dotenv.config();
export const dbConfig = {
    user: process.env.db_User as string,
    host: process.env.db_host as string,
    database: process.env.db_database as string,
    password: process.env.db_password as string,
    port: parseInt(process.env.db_port as string) //(process.env.db_port as string) as unknown as number
};
```

### ClassLib/TableNameClass.ts
```ts
import { Pool } from "pg";
import { dbConfig } from "../helper/dbConfig";
import { JsonResponse } from "../Modals/JsonResponse";

class TableNameClass {
  pool: Pool;

  constructor() {
    this.pool = new Pool(dbConfig);
  }

  GetNewsCategoryList = async (cb: (resp: JsonResponse) => void) => {
    // const pool = new Pool(dbConfig;
    let jResponse = new JsonResponse();

    await this.pool
      .query(
        "Select categoryid,categoryname  from categorymaster",
      )
      .then((resp) => {
        jResponse.data = resp.rows;
      })
      .catch((err) => {
        jResponse.data = err.message;
        jResponse.message = err.message;
        jResponse.statusCode = 500;
        jResponse.success = false;
      });

    cb(jResponse);
  };

}

export default TableNameClass;


```

### Models/JsonResponse.ts
```js
export class JsonResponse {
    success: boolean = true;
    statusCode: number = 200;
    data: any;
    message: string = "ok";
  }
```




