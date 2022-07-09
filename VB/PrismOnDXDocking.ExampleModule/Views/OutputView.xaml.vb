Imports System.ComponentModel.Composition
Imports System.Windows.Controls

Namespace PrismOnDXDocking.ExampleModule.Views

    <PartCreationPolicy(CreationPolicy.NonShared), Export>
    Public Partial Class OutputView
        Inherits UserControl

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Public ReadOnly Property PanelCaption As String
            Get
                Return "Output"
            End Get
        End Property
    End Class
End Namespace
