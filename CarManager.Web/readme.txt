Car Manager Sample
==================

This sample is an online resource for testing CacheCow.Server (https://github.com/aliostad/CacheCow)

You may try HTTP caching using verbs to call the server and try different scenarios. You need a "REST"
tool (although it has nothing to do with REST) such as Fiddler, Chrome Postman, etc to make direct HTTP
calls to the server.

For all cases below, use Accept header of "application/json" or "text/xml". I will be using Fiddler.


Scenario 1: GET a car
---------------------
Try GET http://carmanager.azurewebsites.net/api/Car/1 
You will see that you get back an ETag. On subsequent calls, you will get the same ETag (yours will be different):

200 OK
Content-Length: 110
Last-Modified: Sun, 19 Aug 2012 19:47:07 GMT
Server: ASP.NET Development Server/10.0.0.0
ETag: "8656c372ea414c8486cec6279220ec5f"
Vary: Accept
Content-Type: application/json; charset=utf-8
Cache-Control: no-transform, must-revalidate, max-age=604800, private
{"Id":1,"Make":"Vauxhall","Model":"Astra","BuildYear":1997,"Price":175.0,"MaxSpeed":90,"WarrantyProvided":false}

Note the Vary, CacheControl and Last-Modified headers.



Scenario 2: Conditional GET using If-None-Match
-----------------------------------------------
Now make the call with the ETag we got back in the header below (your ETag will be different):

If-None-Match: "8656c372ea414c8486cec6279220ec5f"

You should receive a 304 (not modified) response:

HTTP/1.1 304 Not Modified
Cache-Control: no-cache
Pragma: no-cache
Expires: -1
Connection: Close



Scenario 3: Conditional GET using If-Modified-Since
---------------------------------------------------
Now make the call with the Last-Modified we got back in the header below (your Last-Modified will be different):

If-Modified-Since: Sun, 19 Aug 2012 20:01:05 GMT

You should receive a 304 (not modified) response:

HTTP/1.1 304 Not Modified
Cache-Control: no-cache
Pragma: no-cache
Expires: -1
Connection: Close



Scenario 4: Update using PUT and try scenario 2 and 3
-----------------------------------------------------
Now Update the resource using PUT for example change WarrantyProvided:
{"Id":1,"Make":"Vauxhall","Model":"Astra","BuildYear":1997,"Price":175.0,"MaxSpeed":90,"WarrantyProvided":true}

Now try scenario 2 and 3. You should get a different ETag and Last-Modified and conditional calls will return
new object with code 200 and not 304.



Scenario 5: Collection scenario with POST and GET
-------------------------------------------------
Now you can do GET similar to scenario one but this time to http://carmanager.azurewebsites.net/api/Car to get
all cars. Now similar to scenario 2 and 3, try using Last-Modified or ETag to make a conditional GET. You should
see status 304.


Now POST a new car to the same URL. Now try GET and you will get 200 instead of 304 since the resource has been 
modified.

