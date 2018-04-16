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
		Public Sub New(ByVal behaviorFactory As IRegionBehaviorFactory)
			MyBase.New(behaviorFactory)
		End Sub
		Protected Overrides Function CreateRegion() As IRegion
			Return New AllActiveRegion()
		End Function
		Protected Overrides Sub Adapt(ByVal region As IRegion, ByVal regionTarget As TabbedGroup)
			AddHandler region.Views.CollectionChanged, Function(s, e) AnonymousMethod1(s, e, region, regionTarget)
		End Sub
		
		Private Function AnonymousMethod1(ByVal s As Object, ByVal e As Object, ByVal region As IRegion, ByVal regionTarget As TabbedGroup) As Boolean
			OnViewsCollectionChanged(region, regionTarget, s, e)
			Return True
		End Function
		Private Sub OnViewsCollectionChanged(ByVal region As IRegion, ByVal regionTarget As TabbedGroup, ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
			If e.Action = NotifyCollectionChangedAction.Add Then
				For Each view As Object In e.NewItems
					Dim panel As New LayoutPanel()
					panel.Content = view
					panel.Caption = "new Page"
					regionTarget.Items.Add(panel)
					regionTarget.SelectedTabIndex = regionTarget.Items.Count - 1
				Next view
			End If
		End Sub
	End Class
End Namespace