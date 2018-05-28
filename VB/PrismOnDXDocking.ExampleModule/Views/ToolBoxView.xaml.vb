Imports System
Imports System.ComponentModel.Composition
Imports System.Linq
Imports System.Windows.Controls
Imports PrismOnDXDocking.Infrastructure

Namespace PrismOnDXDocking.ExampleModule.Views
    <PartCreationPolicy(CreationPolicy.NonShared), Export> _
    Partial Public Class ToolBoxView
        Inherits UserControl

        Public Sub New()
            InitializeComponent()
        End Sub
        Public ReadOnly Property PanelCaption() As String
            Get
                Return "Toolbox"
            End Get
        End Property
    End Class
End Namespace