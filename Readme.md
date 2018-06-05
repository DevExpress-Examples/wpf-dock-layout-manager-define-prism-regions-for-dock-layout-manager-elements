# How to define Prism regions for various DXDocking elements


<p>This example demonstrates how to use DXDocking with PRISM. To obtain more information about how to accomplish this in a particular version, press the <strong>Show Implementation Details</strong> link.</p>


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


