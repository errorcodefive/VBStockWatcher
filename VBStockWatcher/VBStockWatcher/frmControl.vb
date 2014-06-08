Public Class frmControl

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click


        btnUpdate.Enabled = True

        frmStartup.updateSelection()
        frmStartup.getQuery(getTicker, getStartDate, getEndDate)

    End Sub
    Public Function getTicker() As String
        Return txtTicker.Text
    End Function

    Public Function getEndDate() As Date
        Return calEnd.SelectionStart
    End Function
    Public Function getStartDate() As Date
        Return calStart.SelectionStart
    End Function
    Public Sub initForm()
        txtTicker.Text = "GE"
        Dim initDate As New Date(1991, 1, 1)
        Dim endDate As New Date(1992, 1, 1)
        calStart.SetDate(initDate)
        calEnd.SetDate(endDate)
    End Sub

End Class