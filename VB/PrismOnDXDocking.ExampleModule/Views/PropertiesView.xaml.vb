Imports System.Windows.Controls
Imports System.ComponentModel.Composition

Namespace PrismOnDXDocking.ExampleModule.Views
    <PartCreationPolicy(CreationPolicy.NonShared), Export> _
    Partial Public Class PropertiesView
        Inherits UserControl

        Public Sub New()
            InitializeComponent()
        End Sub
        Public ReadOnly Property PanelCaption() As String
            Get
                Return "Properties"
            End Get
        End Property
    End Class
End Namespace
