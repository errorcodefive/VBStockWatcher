Public Class frmControl

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
<<<<<<< HEAD
        btnUpdate.Ena()
        btnUpdate.Enabled = True
=======
        frmStartup.updateSelection()
        frmStartup.getQuery()
>>>>>>> 85be2ca63cc0c840a23ad74aecbd5f8f573a534e
    End Sub
    Public Function getTicker() As String
        Return txtTicker.Text
    End  Date
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
<<<<<<< HEAD

=======
>>>>>>> 85be2ca63cc0c840a23ad74aecbd5f8f573a534e
End Class