Module MinorFunctions

    Public Function findMax(array As Double()) As Double
        Dim output As Double = Double.MinValue
        For i As Integer = 0 To array.Length() - 1
            If output < i Then
                output = i
            End If
        Next
        Return output
    End Function
    Public Function findMax(array As Integer()) As Integer
        Dim output As Integer = Integer.MinValue
        For i As Integer = 0 To array.Length() - 1
            If output < i Then
                output = i
            End If
        Next
        Return output
    End Function
    Public Function findMax(list As List(Of frmStartup.stockData)) As Double
        Dim output As Double = Double.MinValue
        For Each i As frmStartup.stockData In list
            If output < i.high Then
                output = i.high
            End If
        Next
        Return output
    End Function
    Public Function findMin(array As Double()) As Double
        Dim output As Double = Double.MaxValue
        For i As Integer = 0 To array.Length() - 1
            If output > i Then
                output = i
            End If
        Next
        Return output
    End Function
    Public Function findMin(array As Integer()) As Integer
        Dim output As Integer = Integer.MaxValue
        For i As Integer = 0 To array.Length() - 1
            If output > i Then
                output = i
            End If
        Next
        Return output
    End Function
    Public Function findMin(list As List(Of frmStartup.stockData)) As Double
        Dim output As Double = Double.MaxValue
        For Each i As frmStartup.stockData In list
            If output > i.low Then
                output = i.low
            End If
        Next
        Return output
    End Function
    ''' <summary>
    ''' returns a scale unit in days.1,5,10 or 20. 5 = 1 week since no trading on sat or sun
    ''' </summary>
    ''' <param name="max">max date</param>
    ''' <param name="min">min date</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getxScale(max As Date, min As Date) As Integer
        Dim diff As Long
        Dim range As Double
        diff = DateDiff(DateInterval.Day, max, min)
        range = Math.Log10(diff)
        If range < 0.5 Then
            Return 1
        ElseIf range < 1 Then
            Return 5
        ElseIf range < 1.5 Then
            Return 10
        ElseIf range >= 1.5 Then
            Return 20
        Else
            Return 0
        End If
    End Function
    Public Function formatDate(d As Date) As String
        Dim output As String
        output = (d.Month() - 1).ToString.PadLeft(2, "0") + d.Day.ToString + d.Year.ToString
        Return output
    End Function

    Public Function getyScale(max As Double, min As Double) As Integer()
        Dim diff As Double
        Dim output(3) As Integer
        Dim increment As Integer
        Dim rounding As Integer
        diff = max - min

        increment = Math.Ceiling(diff / 5)
        output(1) = increment

        rounding = Int(Math.Floor(Math.Log10(increment)))
        output(0) = Math.Round(min - increment, rounding)
        output(2) = Math.Round(max + increment, rounding)

        Return output
    End Function

    Public Function convertToDate(d As String) As Date
        Dim output As Date
        Dim y As Integer
        Dim m As Integer
        Dim da As Integer
        y = Int(d.Substring(0, 4))
        m = Int(d.Substring(5, 2))
        da = Int(d.Substring(8, 2))


        output = New Date(y, m, da)
        Return output
    End Function
    Public Function convertPointToNormalPoint(p As Point, height As Integer) As Point
        Dim output As Point
        output = New Point(p.X, height - p.Y)
        Return output
    End Function
End Module
