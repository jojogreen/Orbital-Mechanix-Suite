Imports ChartDirector

Public Class crosshair
    Implements DemoModule

    ' Name of demo module
    Public Function getName() As String Implements DemoModule.getName
        Return "Crosshair with Axis Labels"
    End Function

    ' Number of charts produced in this demo module
    Public Function getNoOfCharts() As Integer Implements DemoModule.getNoOfCharts
        Return 1
    End Function

    ' Main code for creating chart.
    Public Sub createChart(ByVal viewer As WinChartViewer, ByVal chartIndex As Integer) _
        Implements DemoModule.createChart
        'This demo uses its own form. The viewer on the right pane is not used.
        viewer.Image = Nothing
        Dim f As System.Windows.Forms.Form = New FrmCrossHair()
        f.ShowDialog()
        f.Dispose()
    End Sub

End Class
