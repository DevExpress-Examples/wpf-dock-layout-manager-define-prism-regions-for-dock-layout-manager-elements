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
    <PartCreationPolicy(CreationPolicy.NonShared), Export>
    Partial Public Class DocumentView
        Inherits UserControl
        Implements IPanelInfo

        Public Sub New()
            InitializeComponent()
        End Sub

        Public ReadOnly Property PanelCaption As String Implements IPanelInfo.PanelCaption
            Get
                Return "new document"
            End Get
        End Property
    End Class
End Namespace
