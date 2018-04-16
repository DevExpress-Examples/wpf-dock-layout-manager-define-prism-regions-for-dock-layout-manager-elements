Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports PrismOnDXDocking.Infrastructure
Imports System.ComponentModel.Composition

Namespace PrismOnDXDocking.ExampleModule.Views
	''' <summary>
	''' Interaction logic for DocumentView.xaml
	''' </summary>

	<PartCreationPolicy(CreationPolicy.NonShared), Export> _
	Partial Public Class DocumentView
		Inherits UserControl
		Implements IPanelInfo
		Public Sub New()
			InitializeComponent()
		End Sub

        Public Function GetPanelCaption() As String Implements IPanelInfo.GetPanelCaption
            Return "New document"
        End Function
	End Class
End Namespace
