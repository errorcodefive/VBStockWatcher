Module GraphicsModule
    Public Sub drawLine(gra As System.Drawing.Graphics, x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer, col As System.Drawing.Color, thick As Integer)

        Dim pen As New System.Drawing.Pen(col, thick)
        gra.DrawLine(pen, x1, y1, x2, y2)
        pen.Dispose()
    End Sub
    Public Sub drawConnectedLineArray(gra As System.Drawing.Graphics, lineArray As Point(), col As System.Drawing.Color(), thick As Integer())
        Dim p1 As Point
        Dim p2 As Point
        Dim pen As System.Drawing.Pen
        For i As Integer = 1 To lineArray.Length() - 1
            pen = New System.Drawing.Pen(col(i), thick(i))
            p1 = lineArray(i - 1)
            p2 = lineArray(i)
            gra.DrawLine(pen, p1, p2)

        Next
        pen.Dispose()
    End Sub

End Module
