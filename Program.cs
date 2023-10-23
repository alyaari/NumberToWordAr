// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
var x = ConvertNumberToWords2(12504.25, "ريال", "فلس");
Console.WriteLine(x);
string ConvertNumberToWords2(double Number, string MainCurrency, string SubCurrency)
{
    string ConvertNumberToWords2Ret = "";
    var Array1 = new string[10];
    var Array2 = new string[10];
    var Array3 = new string[10];
    string MyNumber;
    string GetNumber;
    string ReadNumber;
    string My100;
    string My10;
    string My1;
    var My11 = default(string);
    var My12 = default(string);
    string GetText;
    var Billion = default(string);
    var Million = default(string);
    var Thousand = default(string);
    var Hundred = default(string);
    var Fraction = default(string);
    string MyAnd;
    int I;
    var ReMark = default(string);
    if (Number > 999999999999.99d)
        return "";
    if (Number < 0d)
    {
        Number = Number * -1;
        ReMark = "سالب ";
    }
    if (Number == 0d)
    {
        ConvertNumberToWords2Ret = "صفر";
        return ConvertNumberToWords2Ret;
    }
    MyAnd = " و";
    Array1[0] = "";
    Array1[1] = "مائة";
    Array1[2] = "مائتان";
    Array1[3] = "ثلاثمائة";
    Array1[4] = "أربعمائة";
    Array1[5] = "خمسمائة";
    Array1[6] = "ستمائة";
    Array1[7] = "سبعمائة";
    Array1[8] = "ثمانمائة";
    Array1[9] = "تسعمائة";
    Array2[0] = "";
    Array2[1] = " عشر";
    Array2[2] = "عشرون";
    Array2[3] = "ثلاثون";
    Array2[4] = "أربعون";
    Array2[5] = "خمسون";
    Array2[6] = "ستون";
    Array2[7] = "سبعون";
    Array2[8] = "ثمانون";
    Array2[9] = "تسعون";
    Array3[0] = "";
    Array3[1] = "واحد";
    Array3[2] = "اثنان";
    Array3[3] = "ثلاثة";
    Array3[4] = "أربعة";
    Array3[5] = "خمسة";
    Array3[6] = "ستة";
    Array3[7] = "سبعة";
    Array3[8] = "ثمانية";
    Array3[9] = "تسعة";
    GetNumber = Strings.Format(Number, "000000000000.00");
    I = 0;
    while (I < 15)
    {
        if (I < 12)
        {
            MyNumber = Strings.Mid(GetNumber, I + 1, 3);
        }
        else
        {
            MyNumber = "0" + Strings.Mid(GetNumber, I + 2, 2);
        }
        if (Convert.ToDouble(Strings.Mid(MyNumber, 1, 3)) > 0d)
        {
            ReadNumber = Strings.Mid(MyNumber, 1, 1);
            My100 = Array1[Convert.ToInt32(ReadNumber)];
            ReadNumber = Strings.Mid(MyNumber, 3, 1);
            My1 = Array3[Convert.ToInt32(ReadNumber)];
            ReadNumber = Strings.Mid(MyNumber, 2, 1);
            My10 = Array2[Convert.ToInt32(ReadNumber)];
            if (Convert.ToDouble(Strings.Mid(MyNumber, 2, 2)) == 11d)
                My11 = "إحدى عشر";
            if (Convert.ToDouble(Strings.Mid(MyNumber, 2, 2)) == 12d)
                My12 = "إثنى عشر";
            if (Convert.ToDouble(Strings.Mid(MyNumber, 2, 2)) == 10d)
                My10 = "عشرة";
            if (Convert.ToDouble(Strings.Mid(MyNumber, 1, 1)) > 0d & Convert.ToDouble(Strings.Mid(MyNumber, 2, 2)) > 0d)
                My100 = My100 + MyAnd;
            if (Convert.ToDouble(Strings.Mid(MyNumber, 3, 1)) > 0d & Convert.ToDouble(Strings.Mid(MyNumber, 2, 1)) > 1d)
                My1 = My1 + MyAnd;
            GetText = My100 + My1 + My10;
            if (Convert.ToDouble(Strings.Mid(MyNumber, 3, 1)) == 1d & Convert.ToDouble(Strings.Mid(MyNumber, 2, 1)) == 1d)
            {
                GetText = My100 + My11;
                if (Convert.ToDouble(Strings.Mid(MyNumber, 1, 1)) == 0d)
                    GetText = My11;
            }
            if (Convert.ToDouble(Strings.Mid(MyNumber, 3, 1)) == 2d & Convert.ToDouble(Strings.Mid(MyNumber, 2, 1)) == 1d)
            {
                GetText = My100 + My12;
                if (Convert.ToDouble(Strings.Mid(MyNumber, 1, 1)) == 0d)
                    GetText = My12;
            }
            if (I == 0 & !string.IsNullOrEmpty(GetText))
            {
                if (Convert.ToDouble(Strings.Mid(MyNumber, 1, 3)) > 10d)
                {
                    Billion = GetText + " مليار";
                }
                else
                {
                    Billion = GetText + " مليارات";
                    if (Convert.ToDouble(Strings.Mid(MyNumber, 1, 3)) == 2d)
                        Billion = " مليار";
                    if (Convert.ToDouble(Strings.Mid(MyNumber, 1, 3)) == 2d)
                        Billion = " ملياران";
                }
            }
            if (I == 3 & !string.IsNullOrEmpty(GetText))
            {
                if (Convert.ToDouble(Strings.Mid(MyNumber, 1, 3)) > 10d)
                {
                    Million = GetText + " مليون";
                }
                else
                {
                    Million = GetText + " ملايين";
                    if (Convert.ToDouble(Strings.Mid(MyNumber, 1, 3)) == 1d)
                        Million = " مليون";
                    if (Convert.ToDouble(Strings.Mid(MyNumber, 1, 3)) == 2d)
                        Million = " مليونان";
                }
            }
            if (I == 6 & !string.IsNullOrEmpty(GetText))
            {
                if (Convert.ToDouble(Strings.Mid(MyNumber, 1, 3)) > 10d)
                {
                    Thousand = GetText + " ألف";
                }
                else
                {
                    Thousand = GetText + " ألاف";
                    if (Convert.ToDouble(Strings.Mid(MyNumber, 3, 1)) == 1d)
                        Thousand = " ألف";
                    if (Convert.ToDouble(Strings.Mid(MyNumber, 3, 1)) == 2d)
                        Thousand = " ألفان";
                }
            }
            if (I == 9 & !string.IsNullOrEmpty(GetText))
                Hundred = GetText;
            if (I == 12 & !string.IsNullOrEmpty(GetText))
                Fraction = GetText;
        }
        I = I + 3;
    }
    if (!string.IsNullOrEmpty(Billion))
    {
        if (!string.IsNullOrEmpty(Million) | !string.IsNullOrEmpty(Thousand) | !string.IsNullOrEmpty(Hundred))
            Billion = Billion + MyAnd;
    }
    if (!string.IsNullOrEmpty(Million))
    {
        if (!string.IsNullOrEmpty(Thousand) | !string.IsNullOrEmpty(Hundred))
            Million = Million + MyAnd;
    }
    if (!string.IsNullOrEmpty(Thousand))
    {
        if (!string.IsNullOrEmpty(Hundred))
            Thousand = Thousand + MyAnd;
    }
    if (!string.IsNullOrEmpty(Fraction))
    {
        if (!string.IsNullOrEmpty(Billion) | !string.IsNullOrEmpty(Million) | !string.IsNullOrEmpty(Thousand) | !string.IsNullOrEmpty(Hundred))
        {
            ConvertNumberToWords2Ret = ReMark + Billion + Million + Thousand + Hundred + " " + MainCurrency + MyAnd + Fraction + " " + SubCurrency;
        }
        else
        {
            ConvertNumberToWords2Ret = ReMark + Fraction + " " + SubCurrency;
        }
    }
    else
    {
        ConvertNumberToWords2Ret = ReMark + Billion + Million + Thousand + Hundred + " " + MainCurrency;
    }

    return ConvertNumberToWords2Ret;
}
