# Lawrence.Tsuro.TechTest
Poc demo console app to convert csv data and save it in the database, convert database data to json and csv which could be viewed on the 
console directly, and finally the option to convert between json to csv vice-versa


Solution Lawrence.Tsuro.TechTest .netcore 3.1
                 ---------------> Lawrence.Tsuro.TechTest.Entities 
                 ---------------> Lawrence.Tsuro.TechTest.Console 
                 ---------------> Lawrence.Tsuro.TechTest.Services 
                 ---------------> Lawrence.Tsuro.TechTest.Repository 
                 ---------------> Lawrence.Tsuro.TechTest.ServicesTest
                 
Database - Code First EF
Local SQL data base instance Lawrence.Tsuro.TechTest

File Paths
The csv file was downloaded randomly from the internet  and whose 500 records are used generate export files
../../../consoledata/import-addresses.csv
../../../consoledata/import-addresses.json
../../../consoledata/export-addresses.json
../../../consoledata/export-addresses.csv


Libraries
1. Console Tables for displaying data as a table on console.
2. Csv helper.
3. Autommapper which I believe that custom mapping was performed.

                 
Instructions
1. Open the project in your .net ide and make sure it builds.
2. Open the project directory Lawrence.Tsuro.TechTest.Entities to create a local database with the migration script provided 
   via cli or package manager. Confirm that a local instance database has been created.
3. Run the console application.
4. Selection 1 will harvest the data from import-addresses.csv and populate your local database instance. You do not need to check 
   your database if run successfully as the console will mimic the data.
   This option will flood the database with data iteratively used and likely to increase the size of the export files when a conversion is
   performed directly from the database. Delete some of teh records on the import csv file if preferred.
5. Follow the instructions on the screen and you can open the export files whilst they are being manipulated for sanity check.

Future Enhacements
1. For the purpose of this exercise, I hard coded the db context string and sorted out my dependency injection property in a clumsy way. 
   That may need to be moved to a config file manager later.
2. Create more unit test.
3. Check file types, corrupted files and data - e.g. binary / ascii jargon and overflow.
3. Solid property validation that sanitizes indivisul prvided data fields.

Problems / Lessons Learned
1. Csv helper complains on a ignored property, that is why I created a base dto and inherited from it to try and reduce the syntax.
   Due to time constraints, I settled for a work around that allows the csv to be read and then passed into a custom model validator for sanitisation.
 2. Should  have probably refactored some of the code and moved constants to appsettings.
