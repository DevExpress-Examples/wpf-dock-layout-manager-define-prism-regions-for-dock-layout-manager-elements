Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Microsoft.Practices.Prism.Regions
Imports DevExpress.Xpf.Docking
Imports System.Collections.Specialized
Imports System.ComponentModel.Composition

Namespace PrismOnDXDocking.Infrastructure.Adapters
	<Export(GetType(DocumentGroupAdapter)), PartCreationPolicy(CreationPolicy.NonShared)> _
	Public Class DocumentGroupAdapter
		Inherits RegionAdapterBase(Of DocumentGroup)
		<ImportingConstructor> _
		Public Sub New(ByVal behaviorFactory As IRegionBehaviorFactory)
			MyBase.New(behaviorFactory)
		End Sub
		Protected Overrides Function CreateRegion() As IRegion
			Return New AllActiveRegion()
		End Function
		Protected Overrides Sub Adapt(ByVal region As IRegion, ByVal regionTarget As DocumentGroup)
			AddHandler region.Views.CollectionChanged, Function(s, e) AnonymousMethod1(s, e, region, regionTarget)
		End Sub
		
		Private Function AnonymousMethod1(ByVal s As Object, ByVal e As Object, ByVal region As IRegion, ByVal regionTarget As DocumentGroup) As Boolean
			OnViewsCollectionChanged(region, regionTarget, s, e)
			Return True
		End Function
		Private Sub OnViewsCollectionChanged(ByVal region As IRegion, ByVal regionTarget As DocumentGroup, ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
			If e.Action = NotifyCollectionChangedAction.Add Then
				For Each view As Object In e.NewItems
					Dim manager As DockLayoutManager = regionTarget.GetDockLayoutManager()
					Dim panel As DocumentPanel = manager.DockController.AddDocumentPanel(regionTarget)
					panel.Content = view
					If TypeOf view Is IPanelInfo Then
						panel.Caption = (CType(view, IPanelInfo)).GetPanelCaption()
					Else
						panel.Caption = "new Page"
					End If
					manager.DockController.Activate(panel)
				Next view
			End If
		End Sub
	End Class
End Namespace
