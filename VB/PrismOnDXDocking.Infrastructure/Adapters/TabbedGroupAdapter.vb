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
            AddHandler region.Views.CollectionChanged, Sub(s, e) OnViewsCollectionChanged(region, regionTarget, s, e)
        End Sub
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