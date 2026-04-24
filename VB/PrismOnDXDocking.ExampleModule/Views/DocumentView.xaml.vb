Imports System.Windows.Controls

Namespace PrismOnDXDocking.ExampleModule.Views
    Partial Public Class DocumentView
        Inherits UserControl

        Public Sub New()
            InitializeComponent()
        End Sub

        Public ReadOnly Property PanelCaption As String
            Get
                Return "new document"
            End Get
        End Property
    End Class
End Namespace