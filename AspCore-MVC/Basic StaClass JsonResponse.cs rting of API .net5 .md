
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
using System.Security.Claims;



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


```CSharp
    ###### Class JsonResponse.cs 
    
     namespace PtuExamClassLib
{
 
 public class JsonResponse
    {

        public bool success { get; set; } = true;
        public int statusCode { get; set; } = 200;
        public dynamic data { get; set; }
        public string message { get; set; } = "ok";
    }

    public class JsonResponse<T>
    {

        public bool success { get; set; } = true;
        public int statusCode { get; set; } = 200;
        public T data { get; set; }
        public string message { get; set; } = "ok";
    }
}
```


```CSharp
    


    
    //BLL
     DLL_ExamConductRoomStrength objRoom;
        public BLL_ExamConductRoomStrength()
        {
            objRoom = new DLL_ExamConductRoomStrength();
        }
        
        //DLL
         public  class DLL_ExamConductRoomStrength:dbConnPtuDocs
    {
        public dynamic usp_ConfirmExamConductRoomStrengthData(int ID)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@ID", ID);
            var data = db_dapper.Query<dynamic>("usp_ConfirmExamConductRoomStrengthData", parameter, commandType: CommandType.StoredProcedure);
            return data;
        }
        }
        
 ```


```CSharp  
namespace PtuExamClassLib
{
          public class LoginDetails
    {
        public JsonResponse Response { get; set; }
        public string JsonToken { get; set; }
        public int TokenTimeOut { get; set; }
    }
}
 ```


```CSharp
    //CommonFunctions.cs
    
   using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PtuExamClassLib
{
 public  class CommonFunctions
    {

        public static JsonResponse getResponse(DataTable dt)
        {
            JsonResponse _resp = new JsonResponse();
            if (dt == null)
            {
                _resp.data = null;
                _resp.statusCode = StatusCodes.Status404NotFound;
                _resp.message = "No Record Found";
                _resp.success = false;

                return _resp;
            }
            if (dt.Rows.Count == 0)
            {
                _resp.data = null;
                _resp.statusCode = StatusCodes.Status404NotFound;
                _resp.message = "No Record Found";
                _resp.success = false;

                return _resp;
            }
            _resp.data = dt.ToDynamic();
            return _resp;
        }


        public static JsonResponse getResponse(dynamic dt)
        {
            JsonResponse _resp = new JsonResponse();
            if (dt == null)
            {
                _resp.data = null;
                _resp.statusCode = StatusCodes.Status404NotFound;
                _resp.message = "No Record Found";
                _resp.success = false;

                return _resp;
            }
            //try
            //{
            //    if (dt.Count == 0)
            //    {
            //        _resp.data = null;
            //        _resp.statusCode = StatusCodes.Status404NotFound;
            //        _resp.message = "No Record Found";
            //        _resp.success = false;

            //        return _resp;
            //    }
            //}
            //catch (System.Exception)
            //{

                
            //}
           
            _resp.data = dt;
            return _resp;
        }

        public static JsonResponse ErrorResponse(string Exception)
        {
            JsonResponse _resp = new JsonResponse();
            _resp.data = null;
            _resp.statusCode = StatusCodes.Status500InternalServerError;
            _resp.message = Exception;
            _resp.success = false;

            return _resp;
        }

        public static JsonResponse<T> ErrorConvertedResponse<T>(string Exception) where T : class
        {
           JsonResponse<T> _resp = new JsonResponse<T>();
            _resp.data = null;
            _resp.statusCode = StatusCodes.Status500InternalServerError;
            _resp.message = Exception;
            _resp.success = false;

            return _resp;
        }



        public static JsonResponse<T> getConvertedResponse<T>(T dt) where T : class
        {
            JsonResponse<T> _resp = new JsonResponse<T>();
            if (dt == null)
            {
                _resp.data = null;
                _resp.statusCode = StatusCodes.Status404NotFound;
                _resp.message = "No Record Found";
                _resp.success = false;

                return _resp;
            }
            _resp.data = dt;
            return _resp;
        }

        public static DataTable ConvertToDatatable(dynamic data)
        {
            var obj = Enumerable.ToList<dynamic>(data);
            var json = JsonConvert.SerializeObject(obj);
            return (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
        }
    }
}
   
   
```

```CSharp
//StatusCodes
namespace PtuExamRestClass
{    public  class  StatusCodes
    {
        public static int Status404NotFound = 404;
        public static int Status500InternalServerError = 500;
    }
}
```

```CSharp
//ExtensionMethods.cs
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
namespace PtuExamRestClass
{
     public static class ExtensionMethods
    {
        public static List<dynamic> ToDynamic(this DataTable dt)
        {
            var dynamicDt = new List<dynamic>();
            foreach (DataRow row in dt.Rows)
            {
                dynamic dyn = new ExpandoObject();
                dynamicDt.Add(dyn);
                foreach (DataColumn column in dt.Columns)
                {
                    var dic = (IDictionary<string, object>)dyn;
                    dic[column.ColumnName] = row[column];
                }
            }
            return dynamicDt;
        }
    }
}

```

