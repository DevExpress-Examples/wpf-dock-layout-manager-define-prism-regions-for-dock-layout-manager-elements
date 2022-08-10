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
Imports System.Windows.Controls
Imports DevExpress.Xpf.Docking
Imports Prism.Regions

Namespace PrismOnDXDocking.Infrastructure.Adapters

    <Export(GetType(DockManagerAdapter)), PartCreationPolicy(CreationPolicy.NonShared)>
    Public Class DockManagerAdapter
        Inherits RegionAdapterBase(Of DockLayoutManager)

        <ImportingConstructor>
        Public Sub New(ByVal behaviorFactory As IRegionBehaviorFactory)
            MyBase.New(behaviorFactory)
        End Sub

        Protected Overrides Function CreateRegion() As IRegion
            Return New SingleActiveRegion()
        End Function

        Protected Overrides Sub Adapt(ByVal region As IRegion, ByVal regionTarget As DockLayoutManager)
            Dim items As BaseLayoutItem() = regionTarget.GetItems()
            For Each item As BaseLayoutItem In items
                Dim regionName As String = RegionManager.GetRegionName(item)
                If Not String.IsNullOrEmpty(regionName) Then
                    Dim panel As LayoutPanel = TryCast(item, LayoutPanel)
                    If panel IsNot Nothing AndAlso panel.Content Is Nothing Then
                        Dim control As ContentControl = New ContentControl()
                        RegionManager.SetRegionName(control, regionName)
                        panel.Content = control
                    End If
                End If
            Next
        End Sub
    End Class
End Namespace
