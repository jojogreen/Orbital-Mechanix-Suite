Imports System
Imports Microsoft.VisualBasic
Imports ChartDirector

Public Class confidenceband
    Implements DemoModule

    'Name of demo module
    Public Function getName() As String Implements DemoModule.getName
        Return "Confidence Band"
    End Function

    'Number of charts produced in this demo module
    Public Function getNoOfCharts() As Integer Implements DemoModule.getNoOfCharts
        Return 1
    End Function

    'Main code for creating chart.
    'Note: the argument chartIndex is unused because this demo only has 1 chart.
    Public Sub createChart(viewer As WinChartViewer, chartIndex As Integer) _
        Implements DemoModule.createChart

        ' The XY data of the first data series
        Dim dataX() As Double = {50, 55, 37, 24, 42, 49, 63, 72, 83, 59}
        Dim dataY() As Double = {3.6, 2.8, 2.5, 2.3, 3.8, 3.0, 3.8, 5.0, 6.0, 3.3}

        ' Create a XYChart object of size 450 x 420 pixels
        Dim c As XYChart = New XYChart(450, 420)

        ' Set the plotarea at (55, 65) and of size 350 x 300 pixels, with white background and a
        ' light grey border (0xc0c0c0). Turn on both horizontal and vertical grid lines with light
        ' grey color (0xc0c0c0)
        c.setPlotArea(55, 65, 350, 300, &Hffffff, -1, &Hc0c0c0, &Hc0c0c0, -1)

        ' Add a title to the chart using 18 point Times Bold Itatic font.
        c.addTitle("Server Performance", "Times New Roman Bold Italic", 18)

        ' Add titles to the axes using 12pt Arial Bold Italic font
        c.yAxis().setTitle("Response Time (sec)", "Arial Bold Italic", 12)
        c.xAxis().setTitle("Server Load (TPS)", "Arial Bold Italic", 12)

        ' Set the axes line width to 3 pixels
        c.yAxis().setWidth(3)
        c.xAxis().setWidth(3)

        ' Add a scatter layer using (dataX, dataY)
        Dim scatterLayer As ScatterLayer = c.addScatterLayer(dataX, dataY, "", _
            Chart.DiamondSymbol, 11, &H008000)

        ' tool tip for scatter layer
        scatterLayer.setHTMLImageMap("", "", "title='Response time at {x} TPS: {value} sec'")

        ' Add a trend line layer for (dataX, dataY)
        Dim trendLayer As TrendLayer = c.addTrendLayer2(dataX, dataY, &H008000)

        ' Set the line width to 3 pixels
        trendLayer.setLineWidth(3)

        ' Add a 95% confidence band for the line
        trendLayer.addConfidenceBand(0.95, &H806666ff)

        ' Add a 95% confidence band (prediction band) for the points
        trendLayer.addPredictionBand(0.95, &H8066ff66)

        ' tool tip for trend layer
        trendLayer.setHTMLImageMap("", "", _
            "title='Slope = {slope|4} sec/TPS; Intercept = {intercept|4} sec'")

        ' Add a legend box at (50, 30) (top of the chart) with horizontal layout. Use 10pt Arial
        ' Bold Italic font. Set the background and border color to Transparent.
        Dim legendBox As LegendBox = c.addLegend(50, 30, False, "Arial Bold Italic", 10)
        legendBox.setBackground(Chart.Transparent)

        ' Add entries to the legend box
        legendBox.addKey("95% Line Confidence", &H806666ff)
        legendBox.addKey("95% Point Confidence", &H8066ff66)

        ' Display the trend line parameters as a text table formatted using CDML
        Dim textbox As ChartDirector.TextBox = c.addText(56, 65, _
            "<*block*>Slope<*br*>Intercept<*br*>Correlation<*br*>Std Error<*/*>   <*block*>" & _
            FormatNumber(trendLayer.getSlope(), 4) & " sec/tps<*br*>" & FormatNumber( _
            trendLayer.getIntercept(), 4) & " sec<*br*>" & FormatNumber(trendLayer.getCorrelation( _
            ), 4) & "<*br*>" & FormatNumber(trendLayer.getStdError(), 4) & " sec<*/*>", _
            "Arial Bold", 8)

        ' Set the background of the text box to light grey, with a black border, and 1 pixel 3D
        ' border
        textbox.setBackground(&Hc0c0c0, 0, 1)

        ' Output the chart
        viewer.Chart = c

        ' include tool tip for the chart
        viewer.ImageMap = c.getHTMLImageMap("clickable")

    End Sub

End Class

