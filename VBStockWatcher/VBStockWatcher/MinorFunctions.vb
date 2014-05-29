Module MinorFunctions

    Public Function findMax(array As Double()) As Double
        Dim output As Double = Double.MinValue
        For i As Integer = 0 To array.Length() - 1
            If output > i Then
                output = i
            End If
        Next
        Return output
    End Function
    Public Function findMax(array As Integer()) As Integer
        Dim output As Integer = Integer.MinValue
        For i As Integer = 0 To array.Length() - 1
            If output > i Then
                output = i
            End If
        Next
        Return output
    End Function
    Public Function findMin(array As Double()) As Double
        Dim output As Double = Double.MaxValue
        For i As Integer = 0 To array.Length() - 1
            If output < i Then
                output = i
            End If
        Next
        Return output
    End Function
    Public Function findMin(array As Integer()) As Integer
        Dim output As Integer = Integer.MaxValue
        For i As Integer = 0 To array.Length() - 1
            If output < i Then
                output = i
            End If
        Next
        Return output
    End Function
    Public Function getyScale(max As Double, yScreenLength As Integer) As Integer
        Dim roughMax As Double
        Dim expo As Integer

        roughMax = max * 1.1
        expo = Math.Log10(roughMax)

    End Function

End Module
