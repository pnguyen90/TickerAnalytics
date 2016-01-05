Author: Phong Khoi Nguyen
Pupose: Hobby/Demo App
Date of conception: 12/26/2015
First working version: 1/3/2015
Application type: Stock Analytics Tool


This C# suite consists of two desktop applications:
k_means_cluster and performance_corr

Both desktop (Visual Studio WPF) applications utilize the methods contained inside the StasticsAPI 
library and the DatabaseAPI library. The DatabaseAPI is not a true service wrapper for the database, 
but just a conceptual distinction that should grow into a service API as the project further develops.

Both apps will need to be configured with a Microsoft SQL server DB with the correct database name, 
schema, and data before usage.

Database schema assumed: Single table with the following columns: Ticker (string), Date (Date object ex 2015-08-30), 
Time (Time object ex 09:45:08) , Price (decimal)

*********WHAT THE APPS DO****
performance_corr allows a user to input a list of stock ticker symbols and get
a price correlation matrix of the stocks in an excel file.

k_means_cluster allows a user to input stock ticker symbols and get an excel file
of ticker symbols clustered by performance correlation similarity to two fixed
ticker symbols. Each column of the output excel file consists of a stock cluster,
with the centroid of the cluster at the top of the column.
 
Example of k_means_cluster: 
- Fix stock AMRN as x and stock MNKD as y.
- Upload a .csv file with GOOG, APPL, MCSFT, GS, BAC
- Enter a time range for stock price data
- k_means_cluser will generate correlation coefficients (x,y)
for each of GOOG,APPL,MCSFT,GS, and BAC relative to AMRN(x)
and to MNKD(y)

- it will use these coefficient pair (x,y) when clustering
GOOG, APPL, MCSFT, GS, and BAC

- clusters represent groups of stocks that are exibit similar correlation 
behavior with respect to AMRN and MNKD.

- The output excel file with show each cluster in a column, and 
 display the centroid of each cluster on the top of the column


*********USER MANUAL*********

k_means_cluster:

Input fields: .csv file of ticker symbols,ticker symbol for x,ticker symbol for y,
beginning datetime, end datetime, and integer k of desired clusters.

After launching the application, the GUI will allow you to upload a CSV text file
with stock ticker symbol names. Use only one line in the text file and seperate
symbols by comma.

Type in the ticker symbol you want all stocks to be compared to for the x coordinate.
Type in the ticker symbol you want all stocks to be compared ot for the y coordinate.

Select start date and end date from which to get the price data for each stock.

Type in the number of clusters you want (the number should not exceed the number of stocks
in you .csv file)

Click get clusters button to generate the excel file with the clusters.



performance_corr:

Input fields: list of ticker symbols, beginning datetime, end datetime

After launching the application, the GUI will allow you to type in a list of ticker symbols
seperated by commas.

Select the start date and end date from which to get the price data for each stock.

Click create matrix button to see the performance correlation matrix of 
the stocks entered.
