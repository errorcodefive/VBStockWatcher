Public Class frmControl

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        frmStartup.updateSelection()
        frmStartup.getQuery()
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
    Public Sub initForm()
        txtTicker.Text = "GE"
        Dim initDate As New Date(1991, 1, 1)
        Dim endDate As New Date(1992, 1, 1)
        calStart.SetDate(initDate)
        calEnd.SetDate(endDate)
    End Sub
End Class