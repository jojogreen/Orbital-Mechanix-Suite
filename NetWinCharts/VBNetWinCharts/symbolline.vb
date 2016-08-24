Imports System
Imports Microsoft.VisualBasic
Imports ChartDirector

Public Class symbolline
    Implements DemoModule

    'Name of demo module
    Public Function getName() As String Implements DemoModule.getName
        Return "Symbol Line Chart"
    End Function

    'Number of charts produced in this demo module
    Public Function getNoOfCharts() As Integer Implements DemoModule.getNoOfCharts
        Return 1
    End Function

    'Main code for creating chart.
    'Note: the argument chartIndex is unused because this demo only has 1 chart.
    Public Sub createChart(viewer As WinChartViewer, chartIndex As Integer) _
        Implements DemoModule.createChart

        ' The data for the line chart
        Dim data0() As Double = {60.2, 51.7, 81.3, 48.6, 56.2, 68.9, 52.8}
        Dim data1() As Double = {30.0, 32.7, 33.9, 29.5, 32.2, 28.4, 29.8}
        Dim labels() As String = {"Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"}

        ' Create a XYChart object of size 300 x 180 pixels, with a pale yellow (0xffffc0)
        ' background, a black border, and 1 pixel 3D border effect.
        Dim c As XYChart = New XYChart(300, 180, &Hffffc0, &H000000, 1)

        ' Set the plotarea at (45, 35) and of size 240 x 120 pixels, with white background. Turn on
        ' both horizontal and vertical grid lines with light grey color (0xc0c0c0)
        c.setPlotArea(45, 35, 240, 120, &Hffffff, -1, -1, &Hc0c0c0, -1)

        ' Add a legend box at (45, 12) (top of the chart) using horizontal layout and 8pt Arial font
        ' Set the background and border color to Transparent.
        c.addLegend(45, 12, False, "", 8).setBackground(Chart.Transparent)

        ' Add a title to the chart using 9pt Arial Bold/white font. Use a 1 x 2 bitmap pattern as
        ' the background.
        c.addTitle("Server Load (Jun 01 - Jun 07)", "Arial Bold", 9, &Hffffff).setBackground( _
            c.patternColor(New Integer() {&H004000, &H008000}, 2))

        ' Set the y axis label format to nn%
        c.yAxis().setLabelFormat("{value}%")

        ' Set the labels on the x axis
        c.xAxis().setLabels(labels)

        ' Add a line layer to the chart
        Dim layer As LineLayer = c.addLineLayer()

        ' Add the first line. Plot the points with a 7 pixel square symbol
        layer.addDataSet(data0, &Hcf4040, "Peak").setDataSymbol(Chart.SquareSymbol, 7)

        ' Add the second line. Plot the points with a 9 pixel dismond symbol
        layer.addDataSet(data1, &H40cf40, "Average").setDataSymbol(Chart.DiamondSymbol, 9)

        ' Enable data label on the data points. Set the label format to nn%.
        layer.setDataLabelFormat("{value|0}%")

        ' Output the chart
        viewer.Chart = c

        'include tool tip for the chart
        viewer.ImageMap = c.getHTMLImageMap("clickable", "", _
            "title='{xLabel}: {dataSetName} {value}%'")

    End Sub

End Class

