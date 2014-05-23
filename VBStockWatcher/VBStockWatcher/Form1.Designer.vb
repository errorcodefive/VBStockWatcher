<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStartup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtTestOutput = New System.Windows.Forms.TextBox()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtTestOutput
        '
        Me.txtTestOutput.Location = New System.Drawing.Point(38, 26)
        Me.txtTestOutput.Multiline = True
        Me.txtTestOutput.Name = "txtTestOutput"
        Me.txtTestOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTestOutput.Size = New System.Drawing.Size(528, 324)
        Me.txtTestOutput.TabIndex = 0
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(250, 356)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(97, 51)
        Me.btnQuery.TabIndex = 1
        Me.btnQuery.Text = "Click to Query"
        Me.btnQuery.UseMnemonic = False
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(619, 26)
        Me.txtURL.Multiline = True
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(416, 316)
        Me.txtURL.TabIndex = 2
        '
        'frmStartup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1066, 419)
        Me.Controls.Add(Me.txtURL)
        Me.Controls.Add(Me.btnQuery)
        Me.Controls.Add(Me.txtTestOutput)
        Me.Name = "frmStartup"
        Me.Text = "StockWatcher"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTestOutput As System.Windows.Forms.TextBox
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents txtURL As System.Windows.Forms.TextBox

End Class
