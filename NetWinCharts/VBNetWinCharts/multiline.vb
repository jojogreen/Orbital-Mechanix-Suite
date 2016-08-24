Imports System
Imports Microsoft.VisualBasic
Imports ChartDirector

Public Class multiline
    Implements DemoModule

    'Name of demo module
    Public Function getName() As String Implements DemoModule.getName
        Return "Multi-Line Chart (1)"
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
        Dim data0() As Double = {42, 49, 33, 38, 51, 46, 29, 41, 44, 57, 59, 52, 37, 34, 51, 56, _
            56, 60, 70, 76, 63, 67, 75, 64, 51}
        Dim data1() As Double = {50, 55, 47, 34, 42, 49, 63, 62, 73, 59, 56, 50, 64, 60, 67, 67, _
            58, 59, 73, 77, 84, 82, 80, 84, 98}
        Dim data2() As Double = {36, 28, 25, 33, 38, 20, 22, 30, 25, 33, 30, 24, 28, 15, 21, 26, _
            46, 42, 48, 45, 43, 52, 64, 60, 70}

        ' The labels for the line chart
        Dim labels() As String = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", _
            "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"}

        ' Create an XYChart object of size 600 x 300 pixels, with a light blue (EEEEFF) background,
        ' black border, 1 pxiel 3D border effect and rounded corners
        Dim c As XYChart = New XYChart(600, 300, &Heeeeff, &H000000, 1)
        c.setRoundedFrame()

        ' Set the plotarea at (55, 58) and of size 520 x 195 pixels, with white background. Turn on
        ' both horizontal and vertical grid lines with light grey color (0xcccccc)
        c.setPlotArea(55, 58, 520, 195, &Hffffff, -1, -1, &Hcccccc, &Hcccccc)

        ' Add a legend box at (50, 30) (top of the chart) with horizontal layout. Use 9pt Arial Bold
        ' font. Set the background and border color to Transparent.
        c.addLegend(50, 30, False, "Arial Bold", 9).setBackground(Chart.Transparent)

        ' Add a title box to the chart using 15pt Times Bold Italic font, on a light blue (CCCCFF)
        ' background with glass effect. white (0xffffff) on a dark red (0x800000) background, with a
        ' 1 pixel 3D border.
        c.addTitle("Application Server Throughput", "Times New Roman Bold Italic", 15 _
            ).setBackground(&Hccccff, &H000000, Chart.glassEffect())

        ' Add a title to the y axis
        c.yAxis().setTitle("MBytes per hour")

        ' Set the labels on the x axis.
        c.xAxis().setLabels(labels)

        ' Display 1 out of 3 labels on the x-axis.
        c.xAxis().setLabelStep(3)

        ' Add a title to the x axis
        c.xAxis().setTitle("Jun 12, 2006")

        ' Add a line layer to the chart
        Dim layer As LineLayer = c.addLineLayer2()

        ' Set the default line width to 2 pixels
        layer.setLineWidth(2)

        ' Add the three data sets to the line layer. For demo purpose, we use a dash line color for
        ' the last line
        layer.addDataSet(data0, &Hff0000, "Server #1")
        layer.addDataSet(data1, &H008800, "Server #2")
        layer.addDataSet(data2, c.dashLineColor(&H3333ff, Chart.DashLine), "Server #3")

        ' Output the chart
        viewer.Chart = c

        'include tool tip for the chart
        viewer.ImageMap = c.getHTMLImageMap("clickable", "", _
            "title='[{dataSetName}] Hour {xLabel}: {value} MBytes'")

    End Sub

End Class

