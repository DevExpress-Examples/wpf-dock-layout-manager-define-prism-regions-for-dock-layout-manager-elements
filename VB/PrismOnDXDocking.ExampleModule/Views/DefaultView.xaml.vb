Imports System.Windows.Controls

Namespace PrismOnDXDocking.ExampleModule.Views
    Partial Public Class DefaultView
        Inherits UserControl

        Public Sub New()
            InitializeComponent()
        End Sub

        Public ReadOnly Property PanelCaption As String
            Get
                Return "Default View"
            End Get
        End Property
    End Class
End Namespace