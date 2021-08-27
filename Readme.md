<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128589810/12.1.7%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E975)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [BO.cs](./CS/WinWebSolution.Module/BO.cs) (VB: [BO.vb](./VB/WinWebSolution.Module/BO.vb))
<!-- default file list end -->
# How to display detail collections with descendants filtered by an object type


<p>Suppose we have the same classes structure as shown in the <a href="http://documentation.devexpress.com/#Xaf/CustomDocument2797">How to: Use UpCasting</a> help topic.<br> Our goal is to provide two details collections into a DetailView that will allow end-users to view objects of the LocalEmployee and ForeignEmployee classes separately in a Department DetailView.<br> In order to do this, we will declare two calculated details collections in the Department class and also write some code to update these collections when objects are added in or deleted from the main (associated) Employees collections.<br> By design the Employees collection is intended to list both local and foreign employees and also to allow end-users to perform any operations with them. The LocalEmployees and ForeignEmployees collections are intended to view objects only. So, the corresponding nested ListViews will be readonly.</p>
<p><strong>See Also:</strong><br> How to: Set Relationships Between Objects<br> <a href="http://documentation.devexpress.com/#Xaf/CustomDocument3179">How to: Calculate a Property Value Based on Values from a Detail Collection</a><br> <a href="https://www.devexpress.com/Support/Center/p/E2027">How to filter persistent objects against their type</a><br><a href="https://www.devexpress.com/Support/Center/p/K18195">Collection properties and the New/Delete/Link/Unlink Actions</a></p>

<br/>


