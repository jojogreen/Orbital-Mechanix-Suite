Imports System
Imports Microsoft.VisualBasic
Imports ChartDirector

Public Class surface2
    Implements DemoModule

    'Name of demo module
    Public Function getName() As String Implements DemoModule.getName
        Return "Surface Chart (2)"
    End Function

    'Number of charts produced in this demo module
    Public Function getNoOfCharts() As Integer Implements DemoModule.getNoOfCharts
        Return 1
    End Function

    'Main code for creating chart.
    'Note: the argument chartIndex is unused because this demo only has 1 chart.
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

        ' Create a SurfaceChart object of size 720 x 540 pixels
        Dim c As SurfaceChart = New SurfaceChart(720, 540)

        ' Add a title to the chart using 20 points Times New Roman Italic font
        c.addTitle("Quantum Wave Function", "Times New Roman Italic", 20)

        ' Set the center of the plot region at (360, 245), and set width x depth x height to 360 x
        ' 360 x 270 pixels
        c.setPlotRegion(360, 245, 360, 360, 270)

        ' Set the elevation and rotation angles to 20 and 30 degrees
        c.setViewAngle(20, 30)

        ' Set the data to use to plot the chart
        c.setData(dataX, dataY, dataZ)

        ' Spline interpolate data to a 80 x 80 grid for a smooth surface
        c.setInterpolation(80, 80)

        ' Set surface grid lines to semi-transparent black (dd000000)
        c.setSurfaceAxisGrid(&Hdd000000)

        ' Set contour lines to semi-transparent white (80ffffff)
        c.setContourColor(&H80ffffff)

        ' Add a color axis (the legend) in which the left center is anchored at (645, 270). Set the
        ' length to 200 pixels and the labels on the right side. Use smooth gradient coloring.
        c.setColorAxis(645, 270, Chart.Left, 200, Chart.Right).setColorGradient()

        ' Set the x, y and z axis titles using 10 points Arial Bold font
        c.xAxis().setTitle("x/L(x)", "Arial Bold", 10)
        c.yAxis().setTitle("y/L(y)", "Arial Bold", 10)
        c.zAxis().setTitle("Wave Function Amplitude", "Arial Bold", 10)

        ' Output the chart
        viewer.Chart = c

    End Sub

End Class

