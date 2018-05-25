Imports System
Imports System.ComponentModel.Composition
Imports System.Windows.Controls
Imports PrismOnDXDocking.Infrastructure

Namespace PrismOnDXDocking.ExampleModule.Views
    <PartCreationPolicy(CreationPolicy.NonShared), Export> _
    Partial Public Class DefaultView
        Inherits UserControl
        Implements IPanelInfo

        Public Sub New()
            InitializeComponent()
        End Sub

        Public ReadOnly Property PanelCaption() As String
            Get
                Return "Default View"
            End Get
        End Property
    End Class
End Namespace