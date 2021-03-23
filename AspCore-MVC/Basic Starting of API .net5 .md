
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


ValidateData.cs
```CSharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;


  public class ValidateData : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var currentUser = filterContext.HttpContext.User;
            string actionName = filterContext.HttpContext.GetRouteValue("action").ToString();
            string controllerName = filterContext.HttpContext.GetRouteValue("controller").ToString();

            //if (true)
            //{
            //    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
            //    {
            //        controller = "Login",
            //        action = "InvalidDate"
            //    }));
            //}

        }

        public ClaimObject CurrentUser
        {
            get
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                ClaimObject obj = new ClaimObject();
             
            
                //obj.DocsSource = identity.FindFirst("DocsSource").Value;
               // obj.RoleId = Convert.ToInt32( identity.FindFirst("RoleId").Value);
                obj.UA_AccountName = identity.FindFirst("UA_AccountName").Value;
                obj.UA_CentreId= Convert.ToInt32(identity.FindFirst("UA_CentreId").Value);
                obj.UA_EvalID = Convert.ToInt32(identity.FindFirst("UA_EvalID").Value);
                obj.UA_ExamType= identity.FindFirst("UA_ExamType").Value;
                obj.UA_FacUserId= Convert.ToInt32(identity.FindFirst("UA_FacUserId").Value);
                obj.UA_InstId= Convert.ToInt32(identity.FindFirst("UA_InstId").Value);
                obj.UA_NodalId= Convert.ToInt32(identity.FindFirst("UA_NodalId").Value);
                obj.UA_PersonName= identity.FindFirst("UA_PersonName").Value;
                obj.UA_UserType= identity.FindFirst("UA_UserType").Value;
                obj.UserAccountId= Convert.ToInt32(identity.FindFirst("UserAccountId").Value);
                return obj;
            }
        }
        
        
         public class ClaimObject
    {
        public int UserAccountId { get; set; }
        public string UA_AccountName { get; set; }
        public int UA_CentreId { get; set; }
        public string UA_ExamType { get; set; }
        public string UA_UserType { get; set; }
       // public string EsName { get; set; }
       // public int SessionId { get; set; }
        public int UA_EvalID { get; set; }
        public int UA_FacUserId { get; set; }
        public int UA_InstId { get; set; }
        public int UA_NodalId { get; set; }
        public int RoleId { get; set; }
       // public int FinId { get; set; }
        public string UA_PersonName { get; set; }
        public string DocsSource { get; set; }
   
        
    }
    }
```


