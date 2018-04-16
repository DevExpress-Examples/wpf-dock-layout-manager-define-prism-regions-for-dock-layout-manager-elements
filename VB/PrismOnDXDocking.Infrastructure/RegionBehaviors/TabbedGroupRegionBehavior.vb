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
Imports System.ComponentModel.Composition
Imports System.Windows
Imports DevExpress.Xpf.Docking
Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Prism.Regions.Behaviors

Namespace PrismOnDXDocking.Infrastructure.Behaviors
    <Export(GetType(TabbedGroupRegionBehavior)), PartCreationPolicy(CreationPolicy.NonShared)> _
    Public Class TabbedGroupRegionBehavior
        Inherits RegionBehavior
        Implements IHostAwareRegionBehavior

        <Import> _
        Public Property RegionManager() As IRegionManager
        Public Property HostControl() As DependencyObject Implements IHostAwareRegionBehavior.HostControl
        Protected Overrides Sub OnAttach()
            RegisterRegion()
        End Sub
        Private Sub RegisterRegion()
            Dim targetElement As DependencyObject = HostControl
            If targetElement.CheckAccess() Then
                Dim tg As TabbedGroup = TryCast(targetElement, TabbedGroup)
                If tg IsNot Nothing AndAlso RegionManager IsNot Nothing Then
                    RegionManager.Regions.Add(Region)
                End If
            End If
        End Sub
    End Class
End Namespace