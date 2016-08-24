Imports System
Imports Microsoft.VisualBasic
Imports ChartDirector

Public Class bubble
    Implements DemoModule

    'Name of demo module
    Public Function getName() As String Implements DemoModule.getName
        Return "Bubble Chart"
    End Function

    'Number of charts produced in this demo module
    Public Function getNoOfCharts() As Integer Implements DemoModule.getNoOfCharts
        Return 1
    End Function

    'Main code for creating chart.
    'Note: the argument chartIndex is unused because this demo only has 1 chart.
    Public Sub createChart(viewer As WinChartViewer, chartIndex As Integer) _
        Implements DemoModule.createChart

        ' The XYZ points for the bubble chart
        Dim dataX0() As Double = {150, 300, 1000, 1700}
        Dim dataY0() As Double = {12, 60, 25, 65}
        Dim dataZ0() As Double = {20, 50, 50, 85}

        Dim dataX1() As Double = {500, 1000, 1300}
        Dim dataY1() As Double = {35, 50, 75}
        Dim dataZ1() As Double = {30, 55, 95}

        ' Create a XYChart object of size 450 x 420 pixels
        Dim c As XYChart = New XYChart(450, 420)

        ' Set the plotarea at (55, 65) and of size 350 x 300 pixels, with a light grey border
        ' (0xc0c0c0). Turn on both horizontal and vertical grid lines with light grey color
        ' (0xc0c0c0)
        c.setPlotArea(55, 65, 350, 300, -1, -1, &Hc0c0c0, &Hc0c0c0, -1)

        ' Add a legend box at (50, 30) (top of the chart) with horizontal layout. Use 12pt Times
        ' Bold Italic font. Set the background and border color to Transparent.
        c.addLegend(50, 30, False, "Times New Roman Bold Italic", 12).setBackground( _
            Chart.Transparent)

        ' Add a title to the chart using 18pt Times Bold Itatic font.
        c.addTitle("Product Comparison Chart", "Times New Roman Bold Italic", 18)

        ' Add a title to the y axis using 12pt Arial Bold Italic font
        c.yAxis().setTitle("Capacity (tons)", "Arial Bold Italic", 12)

        ' Add a title to the x axis using 12pt Arial Bold Italic font
        c.xAxis().setTitle("Range (miles)", "Arial Bold Italic", 12)

        ' Set the axes line width to 3 pixels
        c.xAxis().setWidth(3)
        c.yAxis().setWidth(3)

        ' Add (dataX0, dataY0) as a scatter layer with semi-transparent red (0x80ff3333) circle
        ' symbols, where the circle size is modulated by dataZ0. This creates a bubble effect.
        c.addScatterLayer(dataX0, dataY0, "Technology AAA", Chart.CircleSymbol, 9, &H80ff3333, _
            &H80ff3333).setSymbolScale(dataZ0)

        ' Add (dataX1, dataY1) as a scatter layer with semi-transparent green (0x803333ff) circle
        ' symbols, where the circle size is modulated by dataZ1. This creates a bubble effect.
        c.addScatterLayer(dataX1, dataY1, "Technology BBB", Chart.CircleSymbol, 9, &H803333ff, _
            &H803333ff).setSymbolScale(dataZ1)

        ' Output the chart
        viewer.Chart = c

        'include tool tip for the chart
        viewer.ImageMap = c.getHTMLImageMap("clickable", "", _
            "title='[{dataSetName}] Range = {x} miles, Capacity = {value} tons, Length = {z} " & _
            "meters'")

    End Sub

End Class

