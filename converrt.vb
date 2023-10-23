Using System;
Using System.Collections.Generic;
Using System.Linq;
Using System.Text;
Using System.Threading.Tasks;

  Function ConvertNumberToWords2(Number As Double, MainCurrency As String, SubCurrency As String)
    Dim Array1(0 To 9) As String
    Dim Array2(0 To 9) As String
    Dim Array3(0 To 9) As String
    Dim MyNumber As String
    Dim GetNumber As String
    Dim ReadNumber As String
    Dim My100 As String
    Dim My10 As String
    Dim My1 As String
    Dim My11 As String
    Dim My12 As String
    Dim GetText As String
    Dim Billion As String
    Dim Million As String
    Dim Thousand As String
    Dim Hundred As String
    Dim Fraction As String
    Dim MyAnd As String
    Dim I As Integer
    Dim ReMark As String
    If Number > 999999999999.99 Then Exit Function
    If Number < 0 Then
        Number = Number * -1
        ReMark = "سالب "
    End If
    If Number = 0 Then
        ConvertNumberToWords2 = "صفر"
        Exit Function
    End If
    MyAnd = " و"
    Array1(0) = ""
    Array1(1) = "مائة"
    Array1(2) = "مائتان"
    Array1(3) = "ثلاثمائة"
    Array1(4) = "أربعمائة"
    Array1(5) = "خمسمائة"
    Array1(6) = "ستمائة"
    Array1(7) = "سبعمائة"
    Array1(8) = "ثمانمائة"
    Array1(9) = "تسعمائة"
    Array2(0) = ""
    Array2(1) = " عشر"
    Array2(2) = "عشرون"
    Array2(3) = "ثلاثون"
    Array2(4) = "أربعون"
    Array2(5) = "خمسون"
    Array2(6) = "ستون"
    Array2(7) = "سبعون"
    Array2(8) = "ثمانون"
    Array2(9) = "تسعون"
    Array3(0) = ""
    Array3(1) = "واحد"
    Array3(2) = "اثنان"
    Array3(3) = "ثلاثة"
    Array3(4) = "أربعة"
    Array3(5) = "خمسة"
    Array3(6) = "ستة"
    Array3(7) = "سبعة"
    Array3(8) = "ثمانية"
    Array3(9) = "تسعة"
    GetNumber = Format(Number, "000000000000.00")
    I = 0
    Do While I < 15
        If I < 12 Then
            MyNumber = Mid$(GetNumber, I + 1, 3)
        Else
            MyNumber = "0" + Mid$(GetNumber, I + 2, 2)
        End If
        If (Mid$(MyNumber, 1, 3)) > 0 Then
            ReadNumber = Mid$(MyNumber, 1, 1)
            My100 = Array1(ReadNumber)
            ReadNumber = Mid$(MyNumber, 3, 1)
            My1 = Array3(ReadNumber)
            ReadNumber = Mid$(MyNumber, 2, 1)
            My10 = Array2(ReadNumber)
            If Mid$(MyNumber, 2, 2) = 11 Then My11 = "إحدى عشر"
            If Mid$(MyNumber, 2, 2) = 12 Then My12 = "إثنى عشر"
            If Mid$(MyNumber, 2, 2) = 10 Then My10 = "عشرة"
            If ((Mid$(MyNumber, 1, 1)) > 0) And ((Mid$(MyNumber, 2, 2)) > 0) Then My100 = My100 + MyAnd
            If ((Mid$(MyNumber, 3, 1)) > 0) And ((Mid$(MyNumber, 2, 1)) > 1) Then My1 = My1 + MyAnd
            GetText = My100 + My1 + My10
            If ((Mid$(MyNumber, 3, 1)) = 1) And ((Mid$(MyNumber, 2, 1)) = 1) Then
                GetText = My100 + My11
                If ((Mid$(MyNumber, 1, 1)) = 0) Then GetText = My11
            End If
            If ((Mid$(MyNumber, 3, 1)) = 2) And ((Mid$(MyNumber, 2, 1)) = 1) Then
                GetText = My100 + My12
                If ((Mid$(MyNumber, 1, 1)) = 0) Then GetText = My12
            End If
            If (I = 0) And (GetText <> "") Then
                If ((Mid$(MyNumber, 1, 3)) > 10) Then
                    Billion = GetText + " مليار"
                Else
                    Billion = GetText + " مليارات"
                    If ((Mid$(MyNumber, 1, 3)) = 2) Then Billion = " مليار"
                    If ((Mid$(MyNumber, 1, 3)) = 2) Then Billion = " ملياران"
                End If
            End If
            If (I = 3) And (GetText <> "") Then
                If ((Mid$(MyNumber, 1, 3)) > 10) Then
                    Million = GetText + " مليون"
                Else
                    Million = GetText + " ملايين"
                    If ((Mid$(MyNumber, 1, 3)) = 1) Then Million = " مليون"
                    If ((Mid$(MyNumber, 1, 3)) = 2) Then Million = " مليونان"
                End If
            End If
            If (I = 6) And (GetText <> "") Then
                If ((Mid$(MyNumber, 1, 3)) > 10) Then
                    Thousand = GetText + " ألف"
                Else
                    Thousand = GetText + " ألاف"
                    If ((Mid$(MyNumber, 3, 1)) = 1) Then Thousand = " ألف"
                    If ((Mid$(MyNumber, 3, 1)) = 2) Then Thousand = " ألفان"
                End If
            End If
            If (I = 9) And (GetText <> "") Then Hundred = GetText
            If (I = 12) And (GetText <> "") Then Fraction = GetText
        End If
        I = I + 3
    Loop
    If (Billion <> "") Then
        If (Million <> "") Or (Thousand <> "") Or (Hundred <> "") Then Billion = Billion + MyAnd
    End If
    If (Million <> "") Then
        If (Thousand <> "") Or (Hundred <> "") Then Million = Million + MyAnd
    End If
    If (Thousand <> "") Then
        If (Hundred <> "") Then Thousand = Thousand + MyAnd
    End If
    If Fraction <> "" Then
        If (Billion <> "") Or (Million <> "") Or (Thousand <> "") Or (Hundred <> "") Then
            ConvertNumberToWords2 = ReMark + Billion + Million + Thousand + Hundred + " " + MainCurrency + MyAnd + Fraction + " " + SubCurrency
        Else
            ConvertNumberToWords2 = ReMark + Fraction + " " + SubCurrency
        End If
    Else
        ConvertNumberToWords2 = ReMark + Billion + Million + Thousand + Hundred + " " + MainCurrency
    End If
End Function