Imports System.ComponentModel.Composition
Imports System.Windows
Imports DevExpress.Xpf.Docking
Imports Prism.Regions
Imports Prism.Regions.Behaviors

Namespace PrismOnDXDocking.Infrastructure.Behaviors
    <Export(GetType(TabbedGroupRegionBehavior)), PartCreationPolicy(CreationPolicy.NonShared)> _
    Public Class TabbedGroupRegionBehavior
        Inherits RegionBehavior
        Implements IHostAwareRegionBehavior

        <Import> _
        Public Property RegionManager() As IRegionManager
        Public Property HostControl() As DependencyObject
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