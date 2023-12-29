<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128533487/11.2.10%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3929)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# ASPxGridView - How to calculate column values on the client side using DataItemTemplate


<p>This example demonstrates how to calculate column values on the client side via editors inside DataItemTemplate and submit the changes to a datasource.<br />
</p><p>1) Define <strong>ASPxSpinEdit</strong> editors inside the "Unit Price" and "Units In Stock" column DataItemTemplate and bind the editors with corresponding column values;<br />
2) Define both an unbound column and <strong>ASPxTextBox</strong> editors inside its<strong> DataItemTemplate</strong> to display the results of the calculation;<br />
3) Handle the <strong>ASPxGridView.CustomUnboundColumnData</strong> event to populate unbound column values;<br />
4) Handle the client-side NumberChanged event of template <strong>ASPxSpinEdit</strong> and calculate a resultant total value for a corresponding DataRow;<br />
5) Track all the modifications via the <strong>ASPxHiddenField</strong> control;<br />
6) Perform a postback to the server and submit all the changes to the datasource: retrieve the changes from the<strong> ASPxHiddenField</strong> control.</p><p><strong>See Also:<br />
</strong><a href="https://www.devexpress.com/Support/Center/p/E2961">E2961: How to sum values of bound and unbound columns and calculate a total value on the client side</a></p><p></p>

<br/>


