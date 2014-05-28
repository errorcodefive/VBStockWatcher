Imports System.Net
Imports System.IO
Imports System.Drawing.Graphics



Public Class frmStartup
    Dim histPrices As String
    Dim formatHistPrices As String(,)
    Dim mainGraph As System.Drawing.Graphics
    Dim ticker As String
    Dim startdate As Date
    Dim enddate As Date


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        picMain.ClientSize = New Size(Me.Width, Me.Height)
        frmControl.Show()

        histPrices = queryYahoo("GE", "01001991", "01001992", "d")
        Dim test As DataTable
        test = formatCSV(histPrices)
        'For Each i As DataRow In test.Rows
        'For j As Integer = 0 To 6
        'MsgBox(i(j))
        'Next
        'Next
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
        Dim request As WebRequest
        Dim response As WebResponse

        Dim inputStream As StreamReader
        request = HttpWebRequest.Create(url)
        response = request.GetResponse()

        inputStream = New StreamReader(response.GetResponseStream)
        output = inputStream.ReadToEnd
        inputStream.Close()
        response.Close()

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
    Public Function formatCSV(inputCSV As String) As System.Data.DataTable
        'perhaps change to output as datatable/dataset instead of array
        Dim parser As New FileIO.TextFieldParser(New StringReader(inputCSV))
        Dim temp As String()
        Dim columns As System.Data.DataColumn

        Dim output = New System.Data.DataTable("Output")

        columns = New DataColumn("Date", System.Type.GetType("System.String"))
        columns.Caption = "Date"
        output.Columns.Add(columns)

        columns = New DataColumn("Open", System.Type.GetType("System.Double"))
        columns.Caption = "Open"
        output.Columns.Add(columns)

        columns = New DataColumn("High", System.Type.GetType("System.Double"))
        columns.Caption = "High"
        output.Columns.Add(columns)

        columns = New DataColumn("Low", System.Type.GetType("System.Double"))
        columns.Caption = "Low"
        output.Columns.Add(columns)

        columns = New DataColumn("Close", System.Type.GetType("System.Double"))
        columns.Caption = "Close"
        output.Columns.Add(columns)

        columns = New DataColumn("Volume", System.Type.GetType("System.Double"))
        columns.Caption = "Vol"
        output.Columns.Add(columns)

        columns = New DataColumn("Adjusted Closing Price", System.Type.GetType("System.Double"))
        columns.Caption = "Adj Close"
        output.Columns.Add(columns)

        parser.TextFieldType = FileIO.FieldType.Delimited
        parser.SetDelimiters(",")

        Dim k As Integer = 0
        parser.ReadFields()
        While parser.EndOfData = False
            temp = parser.ReadFields
            output.Rows.Add(temp)
        End While


        Return output
    End Function
 

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim testPen As New System.Drawing.Pen(Color.Red, 10)
        mainGraph = picMain.CreateGraphics
        mainGraph.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias



    End Sub

    Private Sub frmStartup_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        picMain.ClientSize = New Size(Me.Width, Me.Height)
    End Sub
    Public Sub updateSelection()
        ticker = frmControl.getTicker
        enddate = frmControl.getEndDate
        startdate = frmControl.getStartDate
    End Sub
End Class
