Imports Microsoft.VisualBasic
Imports System.ComponentModel.Composition
Imports Microsoft.Practices.Prism.Regions
Imports System.Windows.Controls
Imports DevExpress.Xpf.Docking
Imports System
Imports System.Collections.Specialized

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
			AddHandler region.Views.CollectionChanged, Function(d, e) AnonymousMethod1(d, e, regionTarget)
		End Sub
		
		Private Function AnonymousMethod1(ByVal d As Object, ByVal e As Object, ByVal regionTarget As LayoutPanel) As Boolean
			If e.NewItems IsNot Nothing Then
				regionTarget.Content = e.NewItems(0)
			End If
			Return True
		End Function
	End Class
End Namespace
