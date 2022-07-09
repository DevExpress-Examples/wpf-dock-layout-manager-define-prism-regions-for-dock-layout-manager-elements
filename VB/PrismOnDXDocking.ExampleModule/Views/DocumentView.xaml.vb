Imports System.Windows.Controls
Imports System.ComponentModel.Composition

Namespace PrismOnDXDocking.ExampleModule.Views

    <PartCreationPolicy(CreationPolicy.NonShared), Export>
    Public Partial Class DocumentView
        Inherits UserControl

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Public ReadOnly Property PanelCaption As String
            Get
                Return "New Document"
            End Get
        End Property
    End Class
End Namespace
