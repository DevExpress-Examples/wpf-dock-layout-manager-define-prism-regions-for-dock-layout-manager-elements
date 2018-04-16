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
Imports DevExpress.Xpf.Docking

Namespace PrismOnDXDocking.Infrastructure.Adapters
    <Export(GetType(LayoutGroupAdapter)), PartCreationPolicy(CreationPolicy.NonShared)> _
    Public Class LayoutGroupAdapter
        Inherits RegionAdapterBase(Of LayoutGroup)

        <ImportingConstructor> _
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
            If _lockItemsChanged Then
                Return
            End If

            'if (e.Action == NotifyCollectionChangedAction.Remove)
            '{
            '    _lockViewsChanged = true;
            '    var lp = (LayoutPanel)e.OldItems[0];
            '    var view = lp.Content;
            '    lp.Content = null;
            '    region.Remove(view);
            '    _lockViewsChanged = false;
            '}
        End Sub

        Private Sub OnViewsCollectionChanged(ByVal region As IRegion, ByVal regionTarget As LayoutGroup, ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
            If _lockViewsChanged Then
                Return
            End If

            If e.Action = NotifyCollectionChangedAction.Add Then
                For Each view In e.NewItems
                    Dim panel = New LayoutPanel With {.Content = view}
                    If TypeOf view Is IPanelInfo Then
                        panel.Caption = DirectCast(view, IPanelInfo).GetPanelCaption()
                    Else
                        panel.Caption = "new Page"
                    End If

                    _lockItemsChanged = True
                    regionTarget.Items.Add(panel)
                    _lockItemsChanged = False

                    regionTarget.SelectedTabIndex = regionTarget.Items.Count - 1
                Next view
            End If
            If e.Action = NotifyCollectionChangedAction.Remove Then
                For Each view In e.OldItems
                    Dim viewPanel As LayoutPanel = Nothing
                    For Each panel As LayoutPanel In regionTarget.Items
                        If panel.Content Is view Then
                            viewPanel = panel
                            Exit For
                        End If
                    Next panel
                    If viewPanel Is Nothing Then
                        Continue For
                    End If
                    viewPanel.Content = Nothing
                    _lockItemsChanged = True
                    regionTarget.Items.Remove(viewPanel)
                    _lockItemsChanged = False
                    regionTarget.SelectedTabIndex = regionTarget.Items.Count - 1
                Next view
            End If
        End Sub
    End Class
End Namespace
