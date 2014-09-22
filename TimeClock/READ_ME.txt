The Time Clock application is for the time clock that sits on laptop, and is used to read the end-user's swipes and uploads the data to the database 
provided there is an internet connection.

The application has 4 parts:
1. frmTimeClock - the c# application that sits on the laptop.
2. TimeClock.sqlite - sqlite database that sits on the client and stores the swipes. The database is installed in the %temp% directory.
3. UpdateRemoteDB_Console - console application, that uploads the data to the remote DB, that is on rackspace.com.
* this program needs to be run as a scheduled task, I usually create a scheduled task to run every 30 seconds. There
is an example of a scheduled task in the install, that can be imported to the task scheduler. 
** Double Check to make sure scheduled task works properly after creating.
4. htcTimeClock_Installer - creates the *.msi file for the application.
* make sure the local account (StateFair) has administrator privelges on the local machine.
the application will install to the %program files%\htc\StateFair directory.

There is an *.sln file within the frmTimeClock directory, that has all the projects setup. However it probably has my filepaths
hard-coded into the *.sln, so you may have to create a new solution and add the 3 projects to the solution. You may also have to
edit the htcTimeClock_Installer file with the updated outputs.


Badges:
1. Badge Picture Capture: is used to capture the employees picture. It works in conjunction with a webcam installed on a laptop.
It allows you to name the pictures according to the user's name (ex: Jon_Doe.jpg). It makes creating the badges infinately easier.
Overcame the problem of having the picture subject, hold a card with their name written out on it. You will have to go in and
crop and resize the picture aftwards though. The pictures will later be uploaded to the server.
2. createCardDB.sql, is the sql that creates the *xls file required by the badge software to perform a batch print job of cards.
3. StateFair.car is the template used by the badge printing software to create the badge. 

