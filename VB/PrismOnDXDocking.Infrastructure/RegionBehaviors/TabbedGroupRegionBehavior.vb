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
		Private private_RegionManager As IRegionManager
		<Import> _
		Public Property _RegionManager() As IRegionManager
			Get
				Return private_RegionManager
			End Get
			Set(ByVal value As IRegionManager)
				private_RegionManager = value
			End Set
		End Property

		Private hostControl_Renamed As DependencyObject
		Public Property HostControl() As DependencyObject
			Get
				Return hostControl_Renamed
			End Get
			Set(ByVal value As DependencyObject)
				If IsAttached Then
					Throw New InvalidOperationException()
				End If
				Me.hostControl_Renamed = value
			End Set
		End Property
		Protected Overrides Sub OnAttach()
			RegisterRegion()
		End Sub
		Private Sub RegisterRegion()
			Dim targetElement As DependencyObject = HostControl
			If targetElement.CheckAccess() Then
				Dim tg As TabbedGroup = TryCast(targetElement, TabbedGroup)
				If tg IsNot Nothing Then
					If _RegionManager IsNot Nothing Then
						_RegionManager.Regions.Add(Region)
					End If
				End If
			End If
		End Sub
	End Class
End Namespace