Imports System.Windows.Forms
Imports System.Drawing

Public Class Form1
    Inherits Form

    ' Declare UI components
    Private lblHeader As Label
    Private txtCelsius As TextBox
    Private txtFahrenheit As TextBox
    Private btnConvert As Button
    Private btnClear As Button

    Public Sub New()
        ' Set Window Title and Size
        Me.Text = "Temperature Converter"
        Me.Width = 350
        Me.Height = 280
        
        ' Center the project on the screen
        Me.StartPosition = FormStartPosition.CenterScreen
        
        InitializeComponents()
    End Sub

    Private Sub InitializeComponents()
        ' --- Header Label ---
        lblHeader = New Label()
        lblHeader.Text = "Celsius to Fahrenheit Converter"
        lblHeader.Font = New Font("Arial", 12, FontStyle.Bold)
        lblHeader.Location = New Point(20, 10)
        lblHeader.Size = New Size(300, 30)
        lblHeader.TextAlign = ContentAlignment.MiddleCenter

        ' --- Celsius Input Section ---
        Dim lblCelsius As New Label()
        lblCelsius.Text = "Celsius:"
        lblCelsius.Location = New Point(20, 60)
        lblCelsius.AutoSize = True

        txtCelsius = New TextBox()
        txtCelsius.Location = New Point(120, 58)
        txtCelsius.Width = 150

        ' --- Fahrenheit Input Section ---
        Dim lblFahrenheit As New Label()
        lblFahrenheit.Text = "Fahrenheit:"
        lblFahrenheit.Location = New Point(20, 100)
        lblFahrenheit.AutoSize = True

        txtFahrenheit = New TextBox()
        txtFahrenheit.Location = New Point(120, 98)
        txtFahrenheit.Width = 150
        ' Removed ReadOnly so users can enter Fahrenheit values too
        txtFahrenheit.ReadOnly = False 

        ' --- Buttons ---
        btnConvert = New Button()
        btnConvert.Text = "Convert"
        btnConvert.Location = New Point(50, 150)
        ' Add event listener for the click event
        AddHandler btnConvert.Click, AddressOf ConvertTemperature

        btnClear = New Button()
        btnClear.Text = "Clear"
        btnClear.Location = New Point(170, 150)
        AddHandler btnClear.Click, AddressOf ClearFields

        ' Add all controls to the form
        Me.Controls.Add(lblHeader)
        Me.Controls.Add(lblCelsius)
        Me.Controls.Add(txtCelsius)
        Me.Controls.Add(lblFahrenheit)
        Me.Controls.Add(txtFahrenheit)
        Me.Controls.Add(btnConvert)
        Me.Controls.Add(btnClear)
    End Sub

    ' Main logic to handle two-way conversion
    Private Sub ConvertTemperature(sender As Object, e As EventArgs)
        ' Check if Celsius has a value to convert to Fahrenheit
        If Not String.IsNullOrWhiteSpace(txtCelsius.Text) Then
            Dim celsius As Double
            If Double.TryParse(txtCelsius.Text, celsius) Then
                ' Formula: (C * 9/5) + 32
                Dim fahrenheit As Double = (celsius * 9 / 5) + 32
                txtFahrenheit.Text = fahrenheit.ToString("0.00")
            Else
                MessageBox.Show("Please enter a valid number in Celsius.", "Input Error")
            End If

        ' If Celsius is empty, check if Fahrenheit has a value to convert to Celsius
        ElseIf Not String.IsNullOrWhiteSpace(txtFahrenheit.Text) Then
            Dim fahrenheit As Double
            If Double.TryParse(txtFahrenheit.Text, fahrenheit) Then
                ' Formula: (F - 32) * 5/9
                Dim celsius As Double = (fahrenheit - 32) * 5 / 9
                txtCelsius.Text = celsius.ToString("0.00")
            Else
                MessageBox.Show("Please enter a valid number in Fahrenheit.", "Input Error")
            End If
        Else
            MessageBox.Show("Please enter a value in one of the fields.", "Input Error")
        End If
    End Sub

    ' Reset all text fields
    Private Sub ClearFields(sender As Object, e As EventArgs)
        txtCelsius.Clear()
        txtFahrenheit.Clear()
    End Sub

End Class