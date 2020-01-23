Imports Microsoft.VisualBasic
Imports System.ComponentModel.Composition
Imports DevExpress.Xpf.Core

Namespace PrismOnDXDocking
	<Export> _
	Partial Public Class Shell
		Inherits DXWindow
		Public Sub New()
			InitializeComponent()
		End Sub
	End Class
End Namespace
