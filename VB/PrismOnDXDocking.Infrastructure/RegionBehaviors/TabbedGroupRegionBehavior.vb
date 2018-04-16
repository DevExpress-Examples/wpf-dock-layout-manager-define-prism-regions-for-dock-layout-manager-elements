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
		Private privateRegionManager As IRegionManager
		<Import> _
		Public Property RegionManager() As IRegionManager
			Get
				Return privateRegionManager
			End Get
			Set(ByVal value As IRegionManager)
				privateRegionManager = value
			End Set
		End Property
		Private privateHostControl As DependencyObject
		Public Property HostControl() As DependencyObject Implements IHostAwareRegionBehavior.HostControl
			Get
				Return privateHostControl
			End Get
			Set(ByVal value As DependencyObject)
				privateHostControl = value
			End Set
		End Property
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