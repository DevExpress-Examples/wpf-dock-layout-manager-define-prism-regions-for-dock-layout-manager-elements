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
Imports System.ComponentModel.Composition
Imports PrismOnDXDocking.Infrastructure

Namespace PrismOnDXDocking.ExampleModule.Views
	<PartCreationPolicy(CreationPolicy.NonShared), Export> _
	Partial Public Class PropertiesView
		Inherits UserControl
		Implements IPanelInfo
		Public Sub New()
			InitializeComponent()
		End Sub
		Public Function GetPanelCaption() As String Implements IPanelInfo.GetPanelCaption
			Return "Properties"
		End Function
	End Class
End Namespace
