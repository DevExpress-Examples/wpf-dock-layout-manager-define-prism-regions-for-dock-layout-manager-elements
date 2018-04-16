Imports Microsoft.VisualBasic
Imports System.ComponentModel.Composition
Imports System.Windows.Controls
Imports PrismOnDXDocking.Infrastructure

Namespace PrismOnDXDocking.ExampleModule.Views
	<PartCreationPolicy(CreationPolicy.NonShared), Export>
	Partial Public Class DefaultView
        Inherits UserControl
        Implements IPanelInfo

        Public Sub New()
			InitializeComponent()
		End Sub

        Public ReadOnly Property PanelCaption As String Implements IPanelInfo.PanelCaption
            Get
                Return "Default View"
            End Get
        End Property
    End Class
End Namespace
