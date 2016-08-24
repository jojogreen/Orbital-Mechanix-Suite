Imports System
Imports Microsoft.VisualBasic
Imports ChartDirector

Public Class stepline
    Implements DemoModule

    'Name of demo module
    Public Function getName() As String Implements DemoModule.getName
        Return "Step Line Chart"
    End Function

    'Number of charts produced in this demo module
    Public Function getNoOfCharts() As Integer Implements DemoModule.getNoOfCharts
        Return 1
    End Function

    'Main code for creating chart.
    'Note: the argument chartIndex is unused because this demo only has 1 chart.
    Public Sub createChart(viewer As WinChartViewer, chartIndex As Integer) _
        Implements DemoModule.createChart

        ' The data for the chart
        Dim dataY0() As Double = {4, 4.5, 5, 5.25, 5.75, 5.25, 5, 4.5, 4, 3, 2.5, 2.5}
        Dim dataX0() As Date = {DateSerial(1997, 1, 1), DateSerial(1998, 6, 25), DateSerial(1999, _
            9, 6), DateSerial(2000, 2, 6), DateSerial(2000, 9, 21), DateSerial(2001, 3, 4), _
            DateSerial(2001, 6, 8), DateSerial(2002, 2, 4), DateSerial(2002, 5, 19), DateSerial( _
            2002, 8, 16), DateSerial(2002, 12, 1), DateSerial(2003, 1, 1)}

        Dim dataY1() As Double = {7, 6.5, 6, 5, 6.5, 7, 6, 5.5, 5, 4, 3.5, 3.5}
        Dim dataX1() As Date = {DateSerial(1997, 1, 1), DateSerial(1997, 7, 1), DateSerial(1997, _
            12, 1), DateSerial(1999, 1, 15), DateSerial(1999, 6, 9), DateSerial(2000, 3, 3), _
            DateSerial(2000, 8, 13), DateSerial(2001, 5, 5), DateSerial(2001, 9, 16), DateSerial( _
            2002, 3, 16), DateSerial(2002, 6, 1), DateSerial(2003, 1, 1)}

        ' Create a XYChart object of size 500 x 270 pixels, with a pale blue (e0e0ff) background,
        ' black border, 1 pixel 3D border effect and rounded corners
        Dim c As XYChart = New XYChart(600, 300, &He0e0ff, &H000000, 1)
        c.setRoundedFrame()

        ' Set the plotarea at (55, 60) and of size 520 x 200 pixels, with white (ffffff) background.
        ' Set horizontal and vertical grid lines to grey (cccccc).
        c.setPlotArea(50, 60, 525, 200, &Hffffff, -1, -1, &Hcccccc, &Hcccccc)

        ' Add a legend box at (55, 32) (top of the chart) with horizontal layout. Use 9pt Arial Bold
        ' font. Set the background and border color to Transparent.
        c.addLegend(55, 32, False, "Arial Bold", 9).setBackground(Chart.Transparent)

        ' Add a title box to the chart using 15pt Times Bold Italic font. The text is white (ffffff)
        ' on a deep blue (000088) background, with soft lighting effect from the right side.
        c.addTitle("Long Term Interest Rates", "Times New Roman Bold Italic", 15, &Hffffff _
            ).setBackground(&H000088, -1, Chart.softLighting(Chart.Right))

        ' Set the y axis label format to display a percentage sign
        c.yAxis().setLabelFormat("{value}%")

        ' Add a red (ff0000) step line layer to the chart and set the line width to 2 pixels
        Dim layer0 As StepLineLayer = c.addStepLineLayer(dataY0, &Hff0000, "Country AAA")
        layer0.setXData(dataX0)
        layer0.setLineWidth(2)

        ' Add a blue (0000ff) step line layer to the chart and set the line width to 2 pixels
        Dim layer1 As StepLineLayer = c.addStepLineLayer(dataY1, &H0000ff, "Country BBB")
        layer1.setXData(dataX1)
        layer1.setLineWidth(2)

        ' Output the chart
        viewer.Chart = c

        'include tool tip for the chart
        viewer.ImageMap = c.getHTMLImageMap("clickable", "", _
            "title='{dataSetName} change to {value}% on {x|mmm dd, yyyy}'")

    End Sub

End Class

