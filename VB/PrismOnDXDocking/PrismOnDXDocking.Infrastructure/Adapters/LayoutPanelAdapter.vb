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

Imports System.ComponentModel.Composition
Imports DevExpress.Xpf.Docking
Imports Prism.Regions

Namespace PrismOnDXDocking.Infrastructure.Adapters
    <Export(GetType(LayoutPanelAdapter)), PartCreationPolicy(CreationPolicy.NonShared)> _
    Public Class LayoutPanelAdapter
        Inherits RegionAdapterBase(Of LayoutPanel)

        <ImportingConstructor> _
        Public Sub New(ByVal behaviorFactory As IRegionBehaviorFactory)
            MyBase.New(behaviorFactory)
        End Sub
        Protected Overrides Function CreateRegion() As IRegion
            Return New SingleActiveRegion()
        End Function
        Protected Overrides Sub Adapt(ByVal region As IRegion, ByVal regionTarget As LayoutPanel)
            AddHandler region.Views.CollectionChanged, Sub(d, e)
                If e.NewItems IsNot Nothing Then
                    regionTarget.Content = e.NewItems(0)
                End If
            End Sub
        End Sub
    End Class
End Namespace
