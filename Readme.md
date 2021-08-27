<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/153779058/18.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830504)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
## How to: provide hierarchical data to Sunburst

This example demonstrates how to visualize hierarchical data using the SunburstControl.

![](Images/sunburst.png)

### Description

Create a **SunburstHierarchicalDataAdapter** object and assign it to the **SunburstControl.DataAdapter** property to provide hierarchical data to Sunburst. Then, specify the adapter's data source object using the **DataSource** property. Use **SunburstHierarchicalDataMapping** objects to configure how the SunburstControl should convert hierarchical data to sunburst items. The **LabelDataMember** property allows you to specify a label data member, the **ValueDataMember** property - a value data member, the **ChildrenDataMember** property - a data member that contains children items and the **Type** property - a type of items at the current level.
