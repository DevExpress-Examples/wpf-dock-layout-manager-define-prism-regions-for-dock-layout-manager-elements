Imports Microsoft.VisualBasic
Imports System
Imports System.Windows

Namespace PrismOnDXDocking
    Partial Public Class App
        Inherits Application

        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            MyBase.OnStartup(e)
            Dim bootstrapper As New Bootstrapper()
            bootstrapper.Run()
            ShutdownMode = ShutdownMode.OnMainWindowClose
        End Sub
    End Class
End Namespace