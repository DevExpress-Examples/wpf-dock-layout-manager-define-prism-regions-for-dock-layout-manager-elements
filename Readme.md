<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128643433/19.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3339)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to define Prism regions for various DXDocking elements


<p>This example demonstrates how to use DXDocking with PRISM.</p>


<h3>Description</h3>

<p>Starting with version 17.1, you can use built-in PRISM adapters from the DevExpress.Xpf.PrismAdapters.vXX.X assembly. Here is how they can be registered:</p>

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


