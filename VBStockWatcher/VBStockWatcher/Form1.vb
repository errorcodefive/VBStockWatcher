Imports System.Net
Imports System.IO
Public Class frmStartup
    Dim histPrices As String
    Dim formatHistPrices As String(,)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        histPrices = queryYahoo("GE", "01001991", "01001992", "d")
        txtTestOutput.Text = histPrices
        Dim temp As String(,) = formatCSV(histPrices)

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
    Public Function formatCSV(inputCSV As String) As String(,)
        'perhaps change to output as datatable/dataset instead of array
        Dim parser As New FileIO.TextFieldParser(New StringReader(inputCSV))
        Dim temp As String()
        Dim columns = 7
        Dim rows As Integer = 0

        parser.TextFieldType = FileIO.FieldType.Delimited
        parser.SetDelimiters(",")
        While parser.EndOfData = False
            rows = rows + 1
            temp = parser.ReadFields
        End While
        parser.Close()

        parser = New FileIO.TextFieldParser(New StringReader(inputCSV))
        parser.TextFieldType = FileIO.FieldType.Delimited
        parser.SetDelimiters(",")

        Dim output(6, rows - 1) As String
        Dim k As Integer = 0
        For i As Integer = 0 To rows - 1
            temp = parser.ReadFields

            For Each j As String In temp
                output(k, i) = j
                k = k + 1
            Next
            k = 0
        Next

        Return output
    End Function
End Class
