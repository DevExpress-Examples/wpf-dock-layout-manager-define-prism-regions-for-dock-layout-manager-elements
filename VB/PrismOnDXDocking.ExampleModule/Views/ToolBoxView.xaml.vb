Imports System.Windows.Controls

Namespace PrismOnDXDocking.ExampleModule.Views
    Partial Public Class ToolBoxView
        Inherits UserControl

        Public Sub New()
            InitializeComponent()
        End Sub

        Public ReadOnly Property PanelCaption As String
            Get
                Return "Toolbox"
            End Get
        End Property
    End Class
End Namespace