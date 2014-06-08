Imports System.Net
Imports System.IO
Imports System.Drawing.Graphics
Imports System.Math


Public Class frmStartup
    Dim histPrices As String
    Dim formatHistPrices As List(Of stockData)
    Dim mainGraph As System.Drawing.Graphics
    Dim ticker As String
    Dim startdate As Date
    Dim enddate As Date
    Dim xScale As Double
    Dim yScale(3) As Integer
    Dim xrat As Double
    Dim yrat As Double


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        picMain.ClientSize = New Size(Me.Width, Me.Height)
        frmControl.Show()
        frmControl.initForm()

        Dim lblX(10) As Label
        lblX(0) = lblX0
        lblX(1) = lblX1
        lblX(2) = lblX2
        lblX(3) = lblX3
        lblX(4) = lblX4
        lblX(5) = lblX5
        lblX(6) = lblX6
        lblX(7) = lblX7
        lblX(8) = lblX8
        lblX(9) = lblX9
        Dim lblY(10) As Label
        lblY(0) = lblY0
        lblY(1) = lblY1
        lblY(2) = lblY2
        lblY(3) = lblY3
        lblY(4) = lblY4
        lblY(5) = lblY5
        lblY(6) = lblY6
        lblY(7) = lblY7
        lblY(8) = lblY8
        lblY(9) = lblY9

        Dim testPen As New System.Drawing.Pen(Color.Red, 10)
        mainGraph = picMain.CreateGraphics
        mainGraph.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

    End Sub

    Public Sub getQuery(ticker As String, startDate As Date, endDate As Date)
        Dim formatStartDate As String
        Dim formatEndDate As String

        

        formatStartDate = startDate.Day.ToString.PadLeft(2, "0") + (startDate.Month - 1).ToString.PadLeft(2, "0") + startDate.Year.ToString
        formatEndDate = endDate.Day.ToString.PadLeft(2, "0") + (endDate.Month - 1).ToString.PadLeft(2, "0") + endDate.Year.ToString

        histPrices = queryYahoo(ticker, formatStartDate, formatEndDate, "d")
        formatHistPrices = formatCSV(histPrices)
        Dim highs As Point()
        highs = highToPoint(formatHistPrices)
        GraphicsModule.drawConnectedLineArray(mainGraph, highs, System.Drawing.Color.Aqua, 2)

    End Sub

    ''' <summary>
    ''' Query for historical data from yahoo, returns csv text, dates not inclusive
    ''' </summary>
    ''' <param name="stockTicker">Ticker name, default NYSE</param>
    ''' <param name="startDate">Starting query date format DDMMYYYY</param>
    ''' <param name="endDate">Ending query date format DDMMYYYY</param>
    ''' <param name="stepLength">stepLength for query d,w,m or v for dividend</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function queryYahoo(stockTicker As String, startDate As String, endDate As String, stepLength As String) As String

        Dim output As String
        output = getWholePage(generateYahooURL(stockTicker, startDate, endDate, stepLength))


        Return output
    End Function
    ''' <summary>
    ''' returns the whole page from a given url
    ''' </summary>
    ''' <param name="url">url to get whole page</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getWholePage(url As String) As String
        Dim output As String
        output = ""
        Dim request As WebRequest
        Dim response As WebResponse

        Dim inputStream As StreamReader
        request = HttpWebRequest.Create(url)
        Try
            response = request.GetResponse()
            inputStream = New StreamReader(response.GetResponseStream)
            output = inputStream.ReadToEnd
            inputStream.Close()
            response.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try



        Return output

    End Function
    Public Function generateYahooURL(stockTicker As String, startDate As String, endDate As String, stepLength As String) As String
        'Query parameters: 
        's = ticker
        'a = start date month starting from 0 (Jan = 0, Dec = 11)
        'b = start date day (DD)
        'c = start date year (YYYY)
        'd = end date month
        'e = end date day (DD)
        'f = end date year (YYYY)
        'g = step, d = by day, w = by week, m = by month, v = by dividend
        Dim queryURL As String
        Dim queryParams As String
        'Create URL for query
        queryURL = "https://ichart.finance.yahoo.com/table.csv?s="
        queryURL = queryURL + stockTicker + "&"
        queryParams = "a=" + startDate.Substring(2, 2) + "&b=" + startDate.Substring(0, 2) + "&c=" + startDate.Substring(4, 4)
        queryParams = queryParams + "&d=" + endDate.Substring(2, 2) + "&e=" + endDate.Substring(0, 2) + "&f=" + endDate.Substring(4, 4) + "&g=" + stepLength + "&ignore=.csv"
        queryURL = queryURL + queryParams
        Return queryURL
    End Function
    Public Function formatCSV(inputCSV As String) As List(Of stockData)
        'perhaps change to output as datatable/dataset instead of array
        Dim parser As New FileIO.TextFieldParser(New StringReader(inputCSV))
        Dim temp As String()
        Dim tempData As stockData

        Dim out As New List(Of stockData)

        parser.TextFieldType = FileIO.FieldType.Delimited
        parser.SetDelimiters(",")

        Dim k As Integer = 0
        parser.ReadFields()
        While parser.EndOfData = False
            temp = parser.ReadFields
            tempData.day = temp(0)
            tempData.open = temp(1)
            tempData.high = temp(2)
            tempData.low = temp(3)
            tempData.close = temp(4)
            tempData.adjClose = temp(5)
            out.Add(tempData)

        End While


        Return out
    End Function


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
       

    End Sub
    ''' <summary>
    ''' Only converts all highs to points
    ''' </summary>
    ''' <param name="formatList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function highToPoint(formatList As List(Of stockData)) As Point()
        Dim ymax As Double
        Dim ymin As Double

        Dim output(formatList.Count()) As Point
        Dim count As Integer
        Dim temp As Point
        Dim x As Integer
        Dim y As Integer

        count = 0

        xScale = MinorFunctions.getxScale(startdate, enddate)
        xrat = Me.Height / Abs(DateDiff(DateInterval.Day, enddate, startdate))
        ymax = MinorFunctions.findMax(formatHistPrices)
        ymin = MinorFunctions.findMin(formatHistPrices)
        yScale = MinorFunctions.getyScale(ymax, ymin)
        yrat = Me.Height / Abs((yScale(2) - yScale(0)))
        For Each i As stockData In formatList
            y = (i.high - yScale(0)) * yrat
            x = xrat * Abs(DateDiff(DateInterval.Day, startdate, MinorFunctions.convertToDate(i.day)))
            temp = New Point(x, y)
            output(count) = MinorFunctions.convertPointToNormalPoint(temp, Me.Height)
            count = count + 1
        Next
        Return output
    End Function

    Private Sub frmStartup_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        picMain.ClientSize = New Size(Me.Width, Me.Height)
    End Sub
    Public Sub updateSelection()
        ticker = frmControl.getTicker
        enddate = frmControl.getEndDate
        startdate = frmControl.getStartDate
    End Sub
    Public Structure stockData
        Public day As Date
        Public open As Double
        Public high As Double
        Public low As Double
        Public close As Double
        Public volume As Double
        Public adjClose As Double
    End Structure
End Class
