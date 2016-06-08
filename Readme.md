# Readme.md

ASP.NET MVC 5 App

Customers can request a service, queued services can be viewed and admins can amend the details.


* Uses a dynamic form which changes the fields to be completed based on a drop down selection.

* Both client and server side validation are used.

* The model implements business rule validation using the IValidatableObject contract.

* Edit/Update/Delete operations on the Customers Index listing is only visible to users in the 'admins' role.

* Entity framework migrations seed two test users one of which is an admin.

* Added Sorting and Paging to Customers Index page

<hr/>
Note: prior to running the project for the first time you may need to update the respective databases from the EF migrations configuration files (see EF_Notes.txt and EF_Seed_Methods.txt)