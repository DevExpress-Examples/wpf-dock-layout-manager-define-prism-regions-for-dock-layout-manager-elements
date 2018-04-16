Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Specialized
Imports System.ComponentModel.Composition
Imports Microsoft.Practices.Prism.Regions
Imports DevExpress.Xpf.Docking

Namespace PrismOnDXDocking.Infrastructure.Adapters
	<Export(GetType(LayoutGroupAdapter)), PartCreationPolicy(CreationPolicy.NonShared)> _
	Public Class LayoutGroupAdapter
		Inherits RegionAdapterBase(Of LayoutGroup)
		<ImportingConstructor> _
		Public Sub New(ByVal behaviorFactory As IRegionBehaviorFactory)
			MyBase.New(behaviorFactory)
		End Sub
		Protected Overrides Function CreateRegion() As IRegion
			 Return New AllActiveRegion()
		End Function
		Protected Overrides Sub Adapt(ByVal region As IRegion, ByVal regionTarget As LayoutGroup)
			AddHandler region.Views.CollectionChanged, Function(s, e) AnonymousMethod1(s, e, region, regionTarget)
		End Sub
		
		Private Function AnonymousMethod1(ByVal s As Object, ByVal e As Object, ByVal region As IRegion, ByVal regionTarget As LayoutGroup) As Boolean
			OnViewsCollectionChanged(region, regionTarget, s, e)
			Return True
		End Function

		Private Sub OnViewsCollectionChanged(ByVal region As IRegion, ByVal regionTarget As LayoutGroup, ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
			If e.Action = NotifyCollectionChangedAction.Add Then
				For Each view As Object In e.NewItems
					Dim panel As New LayoutPanel()
					panel.Content = view
					If TypeOf view Is IPanelInfo Then
						panel.Caption = (CType(view, IPanelInfo)).GetPanelCaption()
					Else
						panel.Caption = "new Page"
					End If
					regionTarget.Items.Add(panel)
					regionTarget.SelectedTabIndex = regionTarget.Items.Count - 1
				Next view
			End If
		End Sub
	End Class
End Namespace
