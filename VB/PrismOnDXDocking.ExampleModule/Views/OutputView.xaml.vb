Imports Microsoft.VisualBasic
Imports System.ComponentModel.Composition
Imports System.Windows.Controls
Imports PrismOnDXDocking.Infrastructure

Namespace PrismOnDXDocking.ExampleModule.Views
    <PartCreationPolicy(CreationPolicy.NonShared), Export>
    Partial Public Class OutputView
        Inherits UserControl
        Implements IPanelInfo

        Public Sub New()
            InitializeComponent()
        End Sub

        Public ReadOnly Property PanelCaption As String Implements IPanelInfo.PanelCaption
            Get
                Return "Output"
            End Get
        End Property
    End Class
End Namespace
