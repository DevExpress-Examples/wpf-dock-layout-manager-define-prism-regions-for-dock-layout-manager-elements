Imports System.Windows.Controls
Imports System.ComponentModel.Composition

Namespace PrismOnDXDocking.ExampleModule.Views

    <PartCreationPolicy(CreationPolicy.NonShared), Export>
    Public Partial Class ToolBoxView
        Inherits UserControl

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Public ReadOnly Property PanelCaption As String
            Get
                Return "Toolbox"
            End Get
        End Property
    End Class
End Namespace
