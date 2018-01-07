Sample Transactions API

This is a take-home programming exercise to demonstrate my familiarity with C#, .NET MVC, and APIs.

Rules:

Create a .NET solution to consume a supplied endpoint that requires a secure authorization token. Manually parse the response without the help of any third party libraries, normalize the data, and display to the user a formatted list of all transactions as well
as a breakdown of various metrics.

This was an enjoyable task to work on because the supplied endpoint was perhaps intentionally less than ideal with random spaces in column names, tabbed-separated data instead of JSON. Good stuff.


Questions for Interviewer:

I was a little confused by what it meant to remove duplicate transactions, in a normal environment I would ask for feedback first. I assumed we wanted to remove duplicate transaction ids, but a less literal interpretation might mean removing 
items with the same cost on the same date.
