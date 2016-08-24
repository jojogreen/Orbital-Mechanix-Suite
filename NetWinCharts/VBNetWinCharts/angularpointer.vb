Imports System
Imports Microsoft.VisualBasic
Imports ChartDirector

Public Class angularpointer
    Implements DemoModule

    'Name of demo module
    Public Function getName() As String Implements DemoModule.getName
        Return "Angular Meter Pointers (1)"
    End Function

    'Number of charts produced in this demo module
    Public Function getNoOfCharts() As Integer Implements DemoModule.getNoOfCharts
        Return 1
    End Function

    'Main code for creating chart.
    'Note: the argument chartIndex is unused because this demo only has 1 chart.
    Public Sub createChart(viewer As WinChartViewer, chartIndex As Integer) _
        Implements DemoModule.createChart

        ' Create an AngularMeter object of size 300 x 300 pixels with transparent background
        Dim m As AngularMeter = New AngularMeter(300, 300, Chart.Transparent)

        ' Set the default text and line colors to white (0xffffff)
        m.setColor(Chart.TextColor, &Hffffff)
        m.setColor(Chart.LineColor, &Hffffff)

        ' Center at (150, 150), scale radius = 128 pixels, scale angle 0 to 360 degrees
        m.setMeter(150, 150, 128, 0, 360)

        ' Add a black (0x000000) circle with radius 148 pixels as background
        m.addRing(0, 148, &H000000)

        ' Add a ring between radii 139 and 147 pixels using the silver color with a light grey
        ' (0xcccccc) edge as border
        m.addRing(139, 147, Chart.silverColor(), &Hcccccc)

        ' Meter scale is 0 - 100, with major/minor/micro ticks every 10/5/1 units
        m.setScale(0, 100, 10, 5, 1)

        ' Set the scale label style to 16pt Arial Italic. Set the major/minor/micro tick lengths to
        ' 13/10/7 pixels pointing inwards, and their widths to 2/1/1 pixels.
        m.setLabelStyle("Arial Italic", 16)
        m.setTickLength(-13, -10, -7)
        m.setLineWidth(0, 2, 1, 1)

        ' Add a semi-transparent blue (0x7f6666ff) pointer using the default shape
        m.addPointer(25, &H7f6666ff, &H6666ff)

        ' Add a semi-transparent red (0x7fff6666) pointer using the arrow shape
        m.addPointer(9, &H7fff6666, &Hff6666).setShape(Chart.ArrowPointer2)

        ' Add a semi-transparent yellow (0x7fffff66) pointer using another arrow shape
        m.addPointer(51, &H7fffff66, &Hffff66).setShape(Chart.ArrowPointer)

        ' Add a semi-transparent green (0x7f66ff66) pointer using the line shape
        m.addPointer(72, &H7f66ff66, &H66ff66).setShape(Chart.LinePointer)

        ' Add a semi-transparent grey (0x7fcccccc) pointer using the pencil shape
        m.addPointer(85, &H7fcccccc, &Hcccccc).setShape(Chart.PencilPointer)

        ' Output the chart
        viewer.Chart = m

    End Sub

End Class

