Public Class frmControl

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        frmStartup.updateSelection()

    End Sub
    Public Function getTicker() As String
        Return txtTicker.Text
    End Function
    Public Function getStartDate() As Date
        Dim output As Date
        output = calStart.SelectionStart
        Return output
    End Function
    Public Function getEndDate() As Date
        Return calEnd.SelectionStart
    End Function
End Class