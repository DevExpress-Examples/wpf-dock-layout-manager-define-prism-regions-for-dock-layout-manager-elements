<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128643433/11.2.7%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3339)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# How to define Prism regions for various DXDocking elements


<p>This example demonstrates how to use DXDocking with PRISM.</p>


<h3>Description</h3>

<p>Since Prism RegionManager supports standard controls only, it is necessary to write custom RegionAdapters (a descendant of the Prism.Regions.RegionAdapterBase class) in order to instruct Prism RegionManager how to deal with DXDocking elements.</p>
<p>This example covers the following scenarios:</p>
<p>Using a LayoutPanel as a Prism region. The LayoutPanelAdapter class creates a new ContentControl containing a View and then places it into a target LayoutPanel.</p>
<p>Using a LayoutGroup as a Prism region. The LayoutGroupAdapter creates a new LayoutPanel containing a View, and then adds it to a target LayoutGroup&rsquo;s Items collection,</p>
<p>Using a DocumentGroup as a Prism region. The DocumentGroupAdapter behaves similarly to the LayoutGroupAdapter. The only difference is that it manipulates DocumentPanels.</p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-dock-layout-manager-define-prism-regions-for-dock-layout-manager-elements&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-dock-layout-manager-define-prism-regions-for-dock-layout-manager-elements&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
