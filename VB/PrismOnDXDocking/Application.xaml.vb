Imports System.Windows

Namespace PrismOnDXDocking

    Public Partial Class App
        Inherits Application

        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            MyBase.OnStartup(e)
            Dim bootstrapper As Bootstrapper = New Bootstrapper()
            bootstrapper.Run()
            ShutdownMode = ShutdownMode.OnMainWindowClose
        End Sub
    End Class
End Namespace
