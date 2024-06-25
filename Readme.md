<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128643433/17.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3339)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# How to define Prism regions for various DXDocking elements


<p>This example demonstrates how to use DXDocking with PRISM.</p>


<h3>Description</h3>

<p>Starting with version 17.1, you can use built-in PRISM adapters from the DevExpress.Xpf.PrismAdapters.vXX.X assembly. Here is how they can be registered:</p>

```cs
protected override RegionAdapterMappings ConfigureRegionAdapterMappings() {
    RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
    var factory = Container.GetExportedValue<IRegionBehaviorFactory>();
    mappings.RegisterMapping(typeof(LayoutPanel), AdapterFactory.Make<RegionAdapterBase<LayoutPanel>>(factory));
    mappings.RegisterMapping(typeof(LayoutGroup), AdapterFactory.Make<RegionAdapterBase<LayoutGroup>>(factory));
    mappings.RegisterMapping(typeof(DocumentGroup), AdapterFactory.Make<RegionAdapterBase<DocumentGroup>>(factory));
    return mappings;
}
```

```vb
Protected Overrides Function ConfigureRegionAdapterMappings() As RegionAdapterMappings
	Dim mappings As RegionAdapterMappings = MyBase.ConfigureRegionAdapterMappings()
	Dim factory = Container.GetExportedValue(Of IRegionBehaviorFactory)()
    mappings.RegisterMapping(GetType(LayoutPanel), AdapterFactory.Make(Of RegionAdapterBase(Of LayoutPanel))(factory))
    mappings.RegisterMapping(GetType(LayoutGroup), AdapterFactory.Make(Of RegionAdapterBase(Of LayoutGroup))(factory))
    mappings.RegisterMapping(GetType(DocumentGroup), AdapterFactory.Make(Of RegionAdapterBase(Of DocumentGroup))(factory))
    Return mappings
End Function
```


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-dock-layout-manager-define-prism-regions-for-dock-layout-manager-elements&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-dock-layout-manager-define-prism-regions-for-dock-layout-manager-elements&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
