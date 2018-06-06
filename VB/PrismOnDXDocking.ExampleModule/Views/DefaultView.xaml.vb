Imports System.ComponentModel.Composition
Imports System.Windows.Controls

Namespace PrismOnDXDocking.ExampleModule.Views
    <PartCreationPolicy(CreationPolicy.NonShared), Export> _
    Partial Public Class DefaultView
        Inherits UserControl

        Public Sub New()
            InitializeComponent()
        End Sub
        Public ReadOnly Property PanelCaption() As String
            Get
                Return "New Page"
            End Get
        End Property
    End Class
End Namespace
