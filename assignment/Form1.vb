Imports System.Windows.Forms
Imports System.Drawing

Public Class Form1
    Inherits Form

    ' UI components
    Private lblHeader As Label
    Private txtCelsius As TextBox
    Private txtFahrenheit As TextBox
    Private btnConvert As Button
    Private btnClear As Button

    Public Sub New()
        ' Window settings
        Me.Text = "Temperature Converter"
        Me.Size = New Size(1000, 500)
        Me.StartPosition = FormStartPosition.CenterScreen

        InitializeControls()
    End Sub

    Private Sub InitializeControls()

        ' ----- Header -----
        lblHeader = New Label()
        lblHeader.Text = "Celsius to Fahrenheit Converter"
        lblHeader.Font = New Font("Arial", 16, FontStyle.Bold)
        lblHeader.Dock = DockStyle.Top
        lblHeader.Height = 60
        lblHeader.TextAlign = ContentAlignment.MiddleCenter

        ' ----- TextBoxes -----
        txtCelsius = New TextBox()
        txtCelsius.Width = 350

        txtFahrenheit = New TextBox()
        txtFahrenheit.Width = 350

        ' ----- Buttons -----
        btnConvert = New Button()
        btnConvert.Text = "Convert"
        btnConvert.Width = 150
        btnConvert.Height = 60
        AddHandler btnConvert.Click, AddressOf ConvertTemperature

        btnClear = New Button()
        btnClear.Text = "Clear"
        btnClear.Width = 100
        btnClear.Height = 60
        AddHandler btnClear.Click, AddressOf ClearFields

        ' ----- Layout Panel -----
        Dim layout As New TableLayoutPanel()
        layout.Dock = DockStyle.Fill
        layout.ColumnCount = 2
        layout.RowCount = 3
        layout.Padding = New Padding(80, 30, 80, 80)

        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40))
        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60))

        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        layout.RowStyles.Add(New RowStyle(SizeType.Percent, 100))

        layout.Controls.Add(New Label() With {.Text = "Celsius:", .Anchor = AnchorStyles.Right, .AutoSize = True}, 0, 0)
        layout.Controls.Add(txtCelsius, 1, 0)

        layout.Controls.Add(New Label() With {.Text = "Fahrenheit:", .Anchor = AnchorStyles.Right, .AutoSize = True}, 0, 1)
        layout.Controls.Add(txtFahrenheit, 1, 1)

        layout.Controls.Add(btnConvert, 0, 2)
        layout.Controls.Add(btnClear, 1, 2)

        btnConvert.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClear.Anchor = AnchorStyles.Top Or AnchorStyles.Left

        ' ----- Add controls -----
        Me.Controls.Add(layout)
        Me.Controls.Add(lblHeader)

    End Sub

    ' ----- Conversion Logic -----
    Private Sub ConvertTemperature(sender As Object, e As EventArgs)

        ' Prevent both fields being filled
        If Not String.IsNullOrWhiteSpace(txtCelsius.Text) AndAlso
           Not String.IsNullOrWhiteSpace(txtFahrenheit.Text) Then
            MessageBox.Show("Please clear one field before converting.", "Input Error")
            Return
        End If

        If Not String.IsNullOrWhiteSpace(txtCelsius.Text) Then
            Dim celsius As Double
            If Double.TryParse(txtCelsius.Text, celsius) Then
                txtFahrenheit.Text = ((celsius * 9 / 5) + 32).ToString("0.00")
            Else
                MessageBox.Show("Enter a valid Celsius value.", "Input Error")
            End If

        ElseIf Not String.IsNullOrWhiteSpace(txtFahrenheit.Text) Then
            Dim fahrenheit As Double
            If Double.TryParse(txtFahrenheit.Text, fahrenheit) Then
                txtCelsius.Text = ((fahrenheit - 32) * 5 / 9).ToString("0.00")
            Else
                MessageBox.Show("Enter a valid Fahrenheit value.", "Input Error")
            End If

        Else
            MessageBox.Show("Please enter a value to convert.", "Input Error")
        End If

    End Sub

    ' ----- Clear Fields -----
    Private Sub ClearFields(sender As Object, e As EventArgs)
        txtCelsius.Clear()
        txtFahrenheit.Clear()
    End Sub

End Class