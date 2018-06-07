Imports System
Imports System.ComponentModel.Composition
Imports System.Windows
Imports DevExpress.Xpf.Docking
Imports Prism.Regions.Behaviors
Imports Prism.Regions

Namespace PrismOnDXDocking.Infrastructure.Behaviors
    <Export(GetType(LayoutGroupRegionBehavior)), PartCreationPolicy(CreationPolicy.NonShared)> _
    Public Class LayoutGroupRegionBehavior
        Inherits RegionBehavior
        Implements IHostAwareRegionBehavior
        <Import>
        Public Property _RegionManager() As IRegionManager
        Private _hostControl As DependencyObject
        Public Property HostControl() As DependencyObject Implements IHostAwareRegionBehavior.HostControl
            Get
                Return _hostControl
            End Get
            Set(ByVal value As DependencyObject)
                If IsAttached Then
                    Throw New InvalidOperationException()
                End If
                Me._hostControl = value
            End Set
        End Property
        Protected Overrides Sub OnAttach()
            RegisterRegion()
        End Sub
        Private Sub RegisterRegion()
            Dim targetElement As DependencyObject = HostControl
            If targetElement.CheckAccess() Then
                Dim lg As LayoutGroup = TryCast(targetElement, LayoutGroup)
                If lg IsNot Nothing Then
                    If _RegionManager IsNot Nothing Then
                        _RegionManager.Regions.Add(Region)
                    End If
                End If
            End If
        End Sub
    End Class
End Namespace
