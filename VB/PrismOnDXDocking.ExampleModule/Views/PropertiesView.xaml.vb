Imports System.ComponentModel.Composition
Imports System.Windows.Controls

Namespace PrismOnDXDocking.ExampleModule.Views

    <PartCreationPolicy(CreationPolicy.NonShared), Export>
    Public Partial Class PropertiesView
        Inherits UserControl

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Public ReadOnly Property PanelCaption As String
            Get
                Return "Properties"
            End Get
        End Property
    End Class
End Namespace
