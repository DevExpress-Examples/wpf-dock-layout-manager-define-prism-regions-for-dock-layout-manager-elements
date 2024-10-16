<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128643433/19.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3339)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WPF Dock Layout Manager - Define Prism Regions for Dock Layout Manager Elements


This example uses the [DockLayoutManager](https://docs.devexpress.com/WPF/DevExpress.Xpf.Docking.DockLayoutManager) with PRISM.

The following code sample registers PRISM adapters from the `DevExpress.Xpf.PrismAdapters.vXX.X` assembly:

```cs
protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
{
    base.ConfigureRegionAdapterMappings(regionAdapterMappings);
    var factory = Container.Resolve<IRegionBehaviorFactory>();
    regionAdapterMappings.RegisterMapping(typeof(LayoutPanel), AdapterFactory.Make<RegionAdapterBase<LayoutPanel>>(factory));
    regionAdapterMappings.RegisterMapping(typeof(LayoutGroup), AdapterFactory.Make<RegionAdapterBase<LayoutGroup>>(factory));
    regionAdapterMappings.RegisterMapping(typeof(TabbedGroup), AdapterFactory.Make<RegionAdapterBase<TabbedGroup>>(factory));
    regionAdapterMappings.RegisterMapping(typeof(DocumentGroup), AdapterFactory.Make<RegionAdapterBase<DocumentGroup>>(factory));
}
```

```vb
Protected Overrides Sub ConfigureRegionAdapterMappings(ByVal regionAdapterMappings As RegionAdapterMappings)
	MyBase.ConfigureRegionAdapterMappings(regionAdapterMappings)
	Dim factory = Container.Resolve(Of IRegionBehaviorFactory)()
	regionAdapterMappings.RegisterMapping(GetType(LayoutPanel), AdapterFactory.Make(Of RegionAdapterBase(Of LayoutPanel))(factory))
	regionAdapterMappings.RegisterMapping(GetType(LayoutGroup), AdapterFactory.Make(Of RegionAdapterBase(Of LayoutGroup))(factory))
	regionAdapterMappings.RegisterMapping(GetType(TabbedGroup), AdapterFactory.Make(Of RegionAdapterBase(Of TabbedGroup))(factory))
	regionAdapterMappings.RegisterMapping(GetType(DocumentGroup), AdapterFactory.Make(Of RegionAdapterBase(Of DocumentGroup))(factory))
End Sub
```

<img src="https://user-images.githubusercontent.com/12169834/175349878-e1127eac-bbc2-412d-b36c-396a33b0c99f.png" width=700px/>

## Documentation

- [Prism Adapters](https://docs.devexpress.com/WPF/117848/common-concepts/prism-adapters?p=netframework)

<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-dock-layout-manager-define-prism-regions-for-dock-layout-manager-elements&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-dock-layout-manager-define-prism-regions-for-dock-layout-manager-elements&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
