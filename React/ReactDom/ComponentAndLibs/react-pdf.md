##### Install
* npm i react-pdf
* npm i --save-dev @types/react-pdf

* import { Document,Page } from 'react-pdf/dist/esm/entry.webpack';

##### Note..
* In case of face issued related to CORS during download/view pdf file  then  change in Webconfig (.net/webapi website)


```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
 <system.webServer>
   <httpProtocol>
     <customHeaders>
       <add name="Access-Control-Allow-Origin" value="*" />
     </customHeaders>
   </httpProtocol>
 </system.webServer>
</configuration
```
