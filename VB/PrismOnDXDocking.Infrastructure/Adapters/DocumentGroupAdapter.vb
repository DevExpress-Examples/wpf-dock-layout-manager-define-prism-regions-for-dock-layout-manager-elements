Imports DevExpress.Xpf.Docking
Imports System.Collections.Specialized
Imports System.ComponentModel.Composition
Imports Prism.Regions

Namespace PrismOnDXDocking.Infrastructure.Adapters

    <Export(GetType(DocumentGroupAdapter)), PartCreationPolicy(CreationPolicy.NonShared)>
    Public Class DocumentGroupAdapter
        Inherits RegionAdapterBase(Of DocumentGroup)

        <ImportingConstructor>
        Public Sub New(ByVal behaviorFactory As IRegionBehaviorFactory)
            MyBase.New(behaviorFactory)
        End Sub

        Protected Overrides Function CreateRegion() As IRegion
            Return New AllActiveRegion()
        End Function

        Protected Overrides Sub Adapt(ByVal region As IRegion, ByVal regionTarget As DocumentGroup)
            AddHandler region.Views.CollectionChanged, Sub(s, e) OnViewsCollectionChanged(region, regionTarget, s, e)
        End Sub

        Private Sub OnViewsCollectionChanged(ByVal region As IRegion, ByVal regionTarget As DocumentGroup, ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
            If e.Action = NotifyCollectionChangedAction.Add Then
                For Each view As Object In e.NewItems
                    Dim manager As DockLayoutManager = regionTarget.GetDockLayoutManager()
                    Dim panel As DocumentPanel = manager.DockController.AddDocumentPanel(regionTarget)
                    panel.Content = view
                    manager.DockController.Activate(panel)
                Next
            End If
        End Sub
    End Class
End Namespace
