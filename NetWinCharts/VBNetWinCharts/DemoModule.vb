' <summary>
' Represents the function each demo chart module must provide
' </summary>
Interface DemoModule

    ' <summary>
    ' A human readable name for the module
    ' </summary>
    Function getName() As String

    ' <summary>
    ' The number of demo charts generated by this module
    ' </summary>
    Function getNoOfCharts() As Integer

    ' <summary>
    ' Generate a demo chart and display it in the given WinChartViewer. The chartIndex argument
    ' indicate which demo chart to generate. It must be a number from 0 to (n - 1).
    ' </summary>
    Sub createChart(ByVal viewer As ChartDirector.WinChartViewer, ByVal chartIndex As Integer)
End Interface
