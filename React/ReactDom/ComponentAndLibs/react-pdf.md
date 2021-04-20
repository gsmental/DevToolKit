##### Install
* npm i react-pdf
* npm i --save-dev @types/react-pdf

* import { Document,Page } from 'react-pdf/dist/esm/entry.webpack';

##### Note..
* In case of face issued related to CORS then  change in Webconfig (.net website)

`xml
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
`
