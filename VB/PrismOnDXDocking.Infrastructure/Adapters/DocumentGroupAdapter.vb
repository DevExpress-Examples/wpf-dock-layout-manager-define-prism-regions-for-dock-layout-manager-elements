Imports DevExpress.Xpf.Docking
Imports System.Collections.Specialized
Imports System.ComponentModel.Composition
Imports Prism.Regions

Namespace PrismOnDXDocking.Infrastructure.Adapters
    <Export(GetType(DocumentGroupAdapter)), PartCreationPolicy(CreationPolicy.NonShared)>
    Public Class DocumentGroupAdapter
        Inherits RegionAdapterBase(Of DocumentGroup)
        <ImportingConstructor>
        Public Sub New(ByVal BehaviorFactory As IRegionBehaviorFactory)
            MyBase.New(BehaviorFactory)
        End Sub
        Protected Overrides Function CreateRegion() As IRegion
            Return New AllActiveRegion()
        End Function
        Protected Overrides Sub Adapt(ByVal region As IRegion, ByVal regionTarget As DocumentGroup)
            AddHandler region.Views.CollectionChanged, Function(sender, e) AnonymousMethod1(sender, e, region, regionTarget)
        End Sub

        Private Function AnonymousMethod1(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs, ByVal region As IRegion, ByVal regionTarget As DocumentGroup) As Boolean
            OnViewsCollectionChanged(sender, e, region, regionTarget)
            Return True
        End Function

        Private Sub OnViewsCollectionChanged(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs, ByVal region As IRegion, ByVal regionTarget As DocumentGroup)
            If e.Action = NotifyCollectionChangedAction.Add Then
                For Each view As Object In e.NewItems
                    Dim manager As DockLayoutManager = regionTarget.GetDockLayoutManager()
                    Dim panel As DocumentPanel = manager.DockController.AddDocumentPanel(regionTarget)
                    panel.Content = view
                    If TypeOf view Is IPanelInfo Then
                        panel.Caption = (CType(view, IPanelInfo)).GetPanelCaption()
                    Else
                        panel.Caption = "New Page"
                    End If
                    manager.DockController.Activate(panel)
                Next view
            End If
        End Sub

    End Class
End Namespace
