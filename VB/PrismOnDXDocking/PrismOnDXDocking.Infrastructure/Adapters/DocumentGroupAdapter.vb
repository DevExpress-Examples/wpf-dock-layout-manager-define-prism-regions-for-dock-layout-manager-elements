' Developer Express Code Central Example:
' Prism - How to define Prism regions for various DXDocking elements
' 
' Since Prism RegionManager supports standard controls only, it is necessary to
' write custom RegionAdapters (a descendant of the
' Microsoft.Practices.Prism.Regions.RegionAdapterBase class) in order to instruct
' Prism RegionManager how to deal with DXDocking elements.
' 
' This example covers
' the following scenarios:
' 
' Using a LayoutPanel as a Prism region. The
' LayoutPanelAdapter class creates a new ContentControl containing a View and then
' places it into a target LayoutPanel.
' Using a LayoutGroup as a Prism region. The
' LayoutGroupAdapter creates a new LayoutPanel containing a View, and then adds it
' to a target LayoutGroup’s Items collection,
' Using a DocumentGroup as a Prism
' region. The DocumentGroupAdapter behaves similarly to the LayoutGroupAdapter.
' The only difference is that it manipulates DocumentPanels.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3339

Imports DevExpress.Xpf.Docking
Imports System.Collections.Specialized
Imports System.ComponentModel.Composition
Imports Prism.Regions

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
            AddHandler region.Views.CollectionChanged, Sub(s, e)
                OnViewsCollectionChanged(region, regionTarget, s, e)
            End Sub
        End Sub
        Private Sub OnViewsCollectionChanged(ByVal region As IRegion, ByVal regionTarget As DocumentGroup, ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
            If e.Action = NotifyCollectionChangedAction.Add Then
                For Each view As Object In e.NewItems
                    Dim manager As DockLayoutManager = regionTarget.GetDockLayoutManager()
                    Dim panel As DocumentPanel = manager.DockController.AddDocumentPanel(regionTarget)
                    panel.Content = view
                    manager.DockController.Activate(panel)
                Next view
            End If
        End Sub
    End Class
End Namespace
