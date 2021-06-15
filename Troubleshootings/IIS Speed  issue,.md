### How to install worker Process
https://forums.iis.net/t/1244084.aspx?Worker+Processes+cannot+click+to+view+running+requests

1)Open the Server Manager.

2)Select Roles and locate the Web Server (IIS) role.

3)Click Add Role Services.

4)Locate the Health and Diagnostics section then select Request Monitor.

5)Click Next and complete the wizard.

6)Once enabled, open IIS Manager and select the Web server.

7)In the Web Server Home Features view, go to the IIS section and select and open the Worker Processes feature.

8)Select the Desired worker process then, in the Actions pane, click View Current Requests (or right-click on the Worker Process and select View Current Requests.

You could also use the below command to get running worker processes using Command prompt:
C:\Windows\System32\inetsrv>appcmd.exe list wp



### how to increase speed/Concrunt Users
https://docs.trendmicro.com/all/ent/tmms-ee%5Cv9.0%5Cen-us%5Ctmms-ee_9.0_olh_server/t_increase_scalability.html

* Open the Internet Information Services (IIS) Manager, and select the server on which you want to perform this procedure.
* Click Application Pools in the left pane, select the AppPool where Mobile Security is installed from the list in the center pane, and then click Advanced Settings... in the right pane.
The Advanced Settings dialog box appears.
* On the Advanced Settings dialog box, make the following changes:
  i.Change the value of the parameter Queue Length to 65535.
 ii. Change the value of the parameter Maximum Worker Processes to 5 or more.
* After making the changes, Click OK, and close the Internet Information Services (IIS) Manager.
* Open Windows Command prompt, and then do the following:
  Type the following command to change the value of IIS concurrent request limit to 100000:
c:\windows\system32\inetsrv\appcmd.exe set config /section:serverRuntime /appConcurrentRequestLimit:100000
Note	
Note
To verify this change, open file applicationHost.config by typing command file %systemroot%\System32\inetsrv\config\applicationHost.config in the Command prompt, and then verify the value of parameter serverRuntime appConcurrentRequestLimit, which should be 100000.
Type the following command to change IIS concurrent request limit to 100000 in the Windows registry:
reg add HKLM\System\CurrentControlSet\Services\HTTP\Parameters /v MaxConnections /t REG_DWORD /d 100000
