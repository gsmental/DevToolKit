
```csharp
 public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllers(); //add this
        }


 app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers(); // add this
            });
```
