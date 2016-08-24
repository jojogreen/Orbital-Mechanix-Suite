Imports System
Imports Microsoft.VisualBasic
Imports ChartDirector

Public Class surfaceperspective
    Implements DemoModule

    'Name of demo module
    Public Function getName() As String Implements DemoModule.getName
        Return "Surface Perspective"
    End Function

    'Number of charts produced in this demo module
    Public Function getNoOfCharts() As Integer Implements DemoModule.getNoOfCharts
        Return 6
    End Function

    'Main code for creating charts
    Public Sub createChart(viewer As WinChartViewer, chartIndex As Integer) _
        Implements DemoModule.createChart

        ' The x and y coordinates of the grid
        Dim dataX() As Double = {0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0}
        Dim dataY() As Double = {0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0}

        ' The values at the grid points. In this example, we will compute the values using the
        ' formula z = sin((x - 0.5) * 2 * pi) * sin((y - 0.5) * 2 * pi)
        Dim dataZ((UBound(dataX) + 1) * (UBound(dataY) + 1) - 1) As Double
        For yIndex As Integer = 0 To UBound(dataY)
            Dim y As Double = (dataY(yIndex) - 0.5) * 2 * 3.1416
            For xIndex As Integer = 0 To UBound(dataX)
                Dim x As Double = (dataX(xIndex) - 0.5) * 2 * 3.1416
                dataZ(yIndex * (UBound(dataX) + 1) + xIndex) = Math.Sin(x) * Math.Sin(y)
            Next
        Next

        ' the perspective level
        Dim perspective As Integer = chartIndex * 12

        ' Create a SurfaceChart object of size 360 x 360 pixels, with white (ffffff) background and
        ' grey (888888) border.
        Dim c As SurfaceChart = New SurfaceChart(360, 360, &Hffffff, &H888888)

        ' Set the perspective level
        c.setPerspective(perspective)
        c.addTitle("Perspective = " & perspective)

        ' Set the center of the plot region at (195, 165), and set width x depth x height to 200 x
        ' 200 x 150 pixels
        c.setPlotRegion(195, 165, 200, 200, 150)

        ' Set the plot region wall thichness to 5 pixels
        c.setWallThickness(5)

        ' Set the elevation and rotation angles to 30 and 30 degrees
        c.setViewAngle(30, 30)

        ' Set the data to use to plot the chart
        c.setData(dataX, dataY, dataZ)

        ' Spline interpolate data to a 40 x 40 grid for a smooth surface
        c.setInterpolation(40, 40)

        ' Use smooth gradient coloring.
        c.colorAxis().setColorGradient()

        ' Output the chart
        viewer.Chart = c

    End Sub

End Class

