
##Create a  Project
##### Install from nuget (API)
* Microsoft.AspNetCore.Authentication.JwtBearer
* Microsoft.AspNetCore.Mvc.NewtonsoftJson
* Newtonsoft.Json

##### Install from nuget (Class)
* Dapper
* System.Data.SqlClient
* 


##### DBconnection in Clas(dbConnPtuExam.cs)

```CSharp
using System.Data;
using System.Data.SqlClient;
namespace PtuExamRestClass
{
    public class dbConnPtuExam
    {
        public static string dbConnPtuExamString = "";
        public SqlConnection con = new SqlConnection();
        public IDbConnection db_dapper;

        public dbConnPtuExam()
        {
            con.ConnectionString = dbConnPtuExamString;
            db_dapper = new SqlConnection(con.ConnectionString);
        }
    }
}
```

