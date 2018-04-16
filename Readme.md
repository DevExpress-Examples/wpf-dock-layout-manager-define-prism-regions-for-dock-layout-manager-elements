# How to define Prism regions for various DXDocking elements


<p>This example demonstrates how to use DXDocking with PRISM. To obtain more information about how to accomplish this in a particular version, press the <strong>Show Implementation Details</strong> link.</p>


<h3>Description</h3>

<p>Since Prism RegionManager supports standard controls only, it is necessary to write custom RegionAdapters (a descendant of the Prism.Regions.RegionAdapterBase class) in order to instruct Prism RegionManager how to deal with DXDocking elements.</p>
<p>This example covers the following scenarios:</p>
<p>Using a LayoutPanel as a Prism region. The LayoutPanelAdapter class creates a new ContentControl containing a View and then places it into a target LayoutPanel.</p>
<p>Using a LayoutGroup as a Prism region. The LayoutGroupAdapter creates a new LayoutPanel containing a View, and then adds it to a target LayoutGroup&rsquo;s Items collection,</p>
<p>Using a DocumentGroup as a Prism region. The DocumentGroupAdapter behaves similarly to the LayoutGroupAdapter. The only difference is that it manipulates DocumentPanels.</p>

<br/>


