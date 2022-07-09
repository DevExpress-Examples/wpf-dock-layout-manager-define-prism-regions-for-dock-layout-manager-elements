Imports System.Collections.Specialized
Imports System.ComponentModel.Composition
Imports DevExpress.Xpf.Docking
Imports Prism.Regions

Namespace PrismOnDXDocking.Infrastructure.Adapters

    <Export(GetType(LayoutGroupAdapter)), PartCreationPolicy(CreationPolicy.NonShared)>
    Public Class LayoutGroupAdapter
        Inherits RegionAdapterBase(Of LayoutGroup)

        <ImportingConstructor>
        Public Sub New(ByVal behaviorFactory As IRegionBehaviorFactory)
            MyBase.New(behaviorFactory)
        End Sub

        Protected Overrides Function CreateRegion() As IRegion
            Return New AllActiveRegion()
        End Function

        Protected Overrides Sub Adapt(ByVal region As IRegion, ByVal regionTarget As LayoutGroup)
            AddHandler region.Views.CollectionChanged, Sub(s, e) OnViewsCollectionChanged(region, regionTarget, s, e)
            AddHandler regionTarget.Items.CollectionChanged, Sub(s, e) OnItemsCollectionChanged(region, regionTarget, s, e)
        End Sub

        Private _lockItemsChanged As Boolean

        Private _lockViewsChanged As Boolean

        Private Sub OnItemsCollectionChanged(ByVal region As IRegion, ByVal regionTarget As LayoutGroup, ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
            If _lockItemsChanged Then Return
            If e.Action = NotifyCollectionChangedAction.Remove Then
                _lockViewsChanged = True
                Dim lp = CType(e.OldItems(0), LayoutPanel)
                Dim view = lp.Content
                lp.Content = Nothing
                region.Remove(view)
                _lockViewsChanged = False
            End If
        End Sub

        Private Sub OnViewsCollectionChanged(ByVal region As IRegion, ByVal regionTarget As LayoutGroup, ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
            If _lockViewsChanged Then Return
            If e.Action = NotifyCollectionChangedAction.Add Then
                For Each view In e.NewItems
                    Dim panel = New LayoutPanel With {.Content = view}
                    _lockItemsChanged = True
                    regionTarget.Items.Add(panel)
                    _lockItemsChanged = False
                    regionTarget.SelectedTabIndex = regionTarget.Items.Count - 1
                Next
            End If

            If e.Action = NotifyCollectionChangedAction.Remove Then
                For Each view In e.OldItems
                    Dim viewPanel As LayoutPanel = Nothing
                    For Each panel As LayoutPanel In regionTarget.Items
                        If panel.Content Is view Then
                            viewPanel = panel
                            Exit For
                        End If
                    Next

                    If viewPanel Is Nothing Then Continue For
                    viewPanel.Content = Nothing
                    _lockItemsChanged = True
                    regionTarget.Items.Remove(viewPanel)
                    _lockItemsChanged = False
                    regionTarget.SelectedTabIndex = regionTarget.Items.Count - 1
                Next
            End If
        End Sub
    End Class
End Namespace
