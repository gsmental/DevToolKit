
## Create a  Project
##### Install from nuget (API)
* Microsoft.AspNetCore.Authentication.JwtBearer
* Microsoft.AspNetCore.Mvc.NewtonsoftJson
* Newtonsoft.Json

##### Install from nuget (Class)
* Dapper
* System.Data.SqlClient
* 


##### DBconnection in Class(dbConnPtuExam.cs)

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


###### Starup.cs
```CSharp
public void ConfigureServices(IServiceCollection services)
        {
          services.AddControllers();
          //db connection set in Class, connection will exit in appsettings.json ("DbConnection")
          dbConnPtuExam.dbConnPtuExamString = Configuration.GetConnectionString("DbConnection");
          
          //set Virtual Directory for (in case of file saving/or other content
           StaticValueUtility.UploadDirectory = Configuration.GetValue<string>("VirtualPath:UploadDirectory"); // settingUp Virtual Directory for file Upload


//Adding JWT token   (secrect will be available in appsettings.json
 services.AddAuthentication().AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;

                cfg.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audiance"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });


        }
```
```CSharp
    StaticValueUtility.cs
  public class StaticValueUtility
    {
        public static string UploadDirectory { get; set; }
        
    }
```

###### appsettings.js
```javascript
{
  "ConnectionStrings": {
    "DbConnection": "Data Source=IP;Initial Catalog=db;Persist Security Info=True;User ID=UserName;Password=Password;Connect Timeout=300;pooling=true;Max Pool Size=1024;"
  },


  "VirtualPath": {
    "UploadDirectory": "C:\\Users\\Lenovo\\Desktop\\Temp\\Upload"
  },

  "Jwt": {
    "Key": "Secret Key",
    "Issuer": "example.com",
    "Audiance": "example.com"
  },

  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}

```

