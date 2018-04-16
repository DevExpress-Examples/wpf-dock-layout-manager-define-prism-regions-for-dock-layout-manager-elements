Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Specialized
Imports System.ComponentModel.Composition
Imports Microsoft.Practices.Prism.Regions
Imports System.Windows.Controls
Imports DevExpress.Xpf.Docking
Imports System.Collections
Imports System.Windows
Imports Microsoft.Practices.Prism.Regions.Behaviors

Namespace PrismOnDXDocking.Infrastructure.Adapters
	<Export(GetType(TabbedGroupAdapter)), PartCreationPolicy(CreationPolicy.NonShared)> _
	Public Class TabbedGroupAdapter
		Inherits RegionAdapterBase(Of TabbedGroup)
		<ImportingConstructor> _
		Public Sub New(ByVal BehaviorFactory As IRegionBehaviorFactory)
			MyBase.New(BehaviorFactory)
		End Sub
		Protected Overrides Function CreateRegion() As IRegion
			Return New AllActiveRegion()
		End Function
		Protected Overrides Sub Adapt(ByVal region As IRegion, ByVal regionTarget As TabbedGroup)
'INSTANT VB TODO TASK: Anonymous methods are not converted by Instant VB if local variables of the outer method are referenced within the anonymous method:
			region.Views.CollectionChanged += delegate(Object sender, NotifyCollectionChangedEventArgs e)
				OnViewsCollectionChanged(sender, e, region, regionTarget)
		End Sub
		Private Sub OnViewsCollectionChanged(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs, ByVal region As IRegion, ByVal regionTarget As TabbedGroup)
			If e.Action = NotifyCollectionChangedAction.Add Then
				For Each view As Object In e.NewItems
					Dim panel As New LayoutPanel()
					panel.Content = view
					panel.Caption = "New Page"
					regionTarget.Items.Add(panel)
					regionTarget.SelectedTabIndex = regionTarget.Items.Count - 1
				Next view
			End If
		End Sub
	End Class
End Namespace