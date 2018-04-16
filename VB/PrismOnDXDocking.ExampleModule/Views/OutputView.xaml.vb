Imports Microsoft.VisualBasic
Imports System.ComponentModel.Composition
Imports System.Windows.Controls
Imports PrismOnDXDocking.Infrastructure

Namespace PrismOnDXDocking.ExampleModule.Views
	''' <summary>
	''' Interaction logic for NewView.xaml
	''' </summary>\
	<PartCreationPolicy(CreationPolicy.NonShared), Export> _
	Partial Public Class OutputView
		Inherits UserControl
		Implements IPanelInfo
		Public Sub New()
			InitializeComponent()
		End Sub

        Public Function GetPanelCaption() As String Implements IPanelInfo.GetPanelCaption
            Return "Output"
        End Function
	End Class
End Namespace
