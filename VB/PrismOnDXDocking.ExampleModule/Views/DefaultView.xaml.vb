Imports System.ComponentModel.Composition
Imports System.Windows.Controls

Namespace PrismOnDXDocking.ExampleModule.Views

    <PartCreationPolicy(CreationPolicy.NonShared), Export>
    Public Partial Class DefaultView
        Inherits UserControl

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Public ReadOnly Property PanelCaption As String
            Get
                Return "New Page"
            End Get
        End Property
    End Class
End Namespace
