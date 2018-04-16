Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.Composition
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes

Namespace ExampleModule.Views
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>
	<Export(GetType(TestView2)), PartCreationPolicy(CreationPolicy.NonShared)> _
	Partial Public Class TestView2
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub
	End Class
End Namespace
