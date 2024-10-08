﻿using Microsoft.VisualBasic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace DATN.PARKING.DLL
{
    public static class Extension
    {

         
        #region CAST base type object

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubstringEx(this string str, int startIndex, int length)
        {
            try
            {
                if (str == null)
                {
                    return string.Empty;
                }

                if (startIndex + length <= str.Length)
                {
                    return str.Substring(startIndex, length);
                }

                return str.Substring(startIndex);
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static string SubstringEx(this string str, int startIndex)
        {
            if (str.TrimEx().IsNullOrEmpty())
            {
                return "";
            }

            if (startIndex < str.Length)
            {
                return str.Substring(startIndex);
            }
            return "";
        }

        /// <summary>
        /// remove last string by input length from last to first character
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RemoveLastStr(this string str, int length)
        {
            try
            {
                if (length > str.Length)
                {
                    return "";
                }

                return str.LeftEx(str.Length - length);
            }
            catch
            {
                return "";
            }
        }


        public static string GetNumberFromStr(this string input)
        {
            // Split on one or more non-digit characters.
            var numRegx = new Regex(@"-*\d{1,9}\.\d{1,9}|-*\d{1,9}");
            //@"([0-9]+)|([-][0-9]+)"

            var numbers = numRegx.Matches(input).Cast<Match>().Select(m => m.Value).ToArray();

            //string[] numbers = System.Text.RegularExpressions.Regex.Split(input, @"\-*\D+");
            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    double result;
                    if (double.TryParse(value, out result))
                    {
                        return value;
                    }
                }
            }

            return "";
        }

        public static bool IsValidTemperarure(this string input)
        {
            if (input.IsNumber())
            {
                return true;
            }

            var temp = input.SubstringEx(0, input.Length - 1);
            var unit = input.SubstringEx(temp.Length);

            if (!temp.IsNumber())
            {
                return false;
            }

            if (unit.ToUpper() != "C" && unit.ToUpper() != "F")
            {
                return false;
            }

            return true;

        }

        public static bool IsValidVent(this string input)
        {
            if (input.IsNumber())
            {
                return false;
            }

            var vent = input.SubstringEx(0, 1);
            var unit = "";

            if (!vent.IsNumber())
            {
                return false;
            }

            //while (vent.IsNumber() && vent.Length < input.Length)
            //{
            //    vent = input.SubstringEx(0, vent.Length + 1);
            //}

            vent = input.GetNumberFromStr();

            unit = input.SubstringEx(vent.Length);

            var VentUnit = new[] { "%", "M3", "M3/H", "M3H", "CBM", "CBMH", "CBM/H" };

            if (!VentUnit.Contains(unit.ToUpper()))
            {
                return false;
            }

            return true;

        }


        public static string GetTempUnitFromStr(this string input)
        {
            // Split on one or more letter characters.
            var letterRegx = new Regex(@"[CFcf]");
            //@"([0-9]+)|([-][0-9]+)"

            var letters = letterRegx.Matches(input).Cast<Match>().Select(m => m.Value).ToArray();

            //string[] numbers = System.Text.RegularExpressions.Regex.Split(input, @"\-*\D+");
            foreach (string value in letters)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    return value;
                }
            }

            return "C";
        }

        public static string GetVentUnitFromStr(this string input)
        {
            if (input.TrimEx().Contains("%"))
            {
                return "%";
            }

            if (input.TrimEx().ToUpper().Contains("M3"))
            {
                return "M3";
            }

            return "%";
        }

        /// <summary>
        /// Get the left string with fix length
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string LeftEx(this string str, int length)
        {
            try
            {
                if (str.Length < length)
                {
                    return str.Substring(0, str.Length);
                }
                return str.Substring(0, length);
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Get the right string with fix length
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string RightEx(this string str, int len)
        {
            try
            {
                return str.Substring(str.Length - len, len);
            }
            catch
            {
                return "";
            }
        }


        public static string RemoveMultipleWhiteSpaces(this string s)
        {
            var regex = new Regex("[ ]{2,}", RegexOptions.None);
            return regex.Replace(s, " ").ToUpper();
        }

        public static string RemoveCharacterAtFirstAndLastEx(this string s, string character)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            // remove comma in last
            while (s.EndsWith(character))
                s = s.Substring(0, s.Length - 1);

            // remove comma in last
            while (s.StartsWith(character))
                s = s.Substring(1, s.Length - 1);

            return s;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimEx(this string str)
        {
            if (str == null)
            {
                return "";
            }

            return str.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimEx(this object str)
        {
            if (str == null)
            {
                return "";
            }

            return Convert.ToString(str).Trim();
        }

        /// <summary>
        /// Return string value, if object is null return empty string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToStringEx(this object str)
        {
            if (str == null)
            {
                return "";
            }


            return str.ToString();
        }

        /// <summary>
        /// Return string value, if object is null or empty return oracle empty string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToStringExOra(this object str)
        {
            if (string.IsNullOrEmpty(str.ToStringEx()))
            {
                return " ";
            }


            return str.ToString().Trim();
        }

        public static string ToStringOracle(this string pStrInput)
        {
            string strOutput;
            string strTmp;
            int i;
            int strLen;

            strOutput = "";
            strLen = pStrInput.Length;

            for (i = 0; i < strLen; i++)
            {
                strTmp = pStrInput.SubstringEx(i, 1);
                if (strTmp != "\'")
                {
                    strOutput = strOutput + strTmp;
                    //if (strTmp == "+")
                    //{
                    //    strOutput = strOutput + "&";
                    //}
                    //else
                    //{
                    //    strOutput = strOutput + strTmp;
                    //}
                }
                else
                {
                    strOutput = strOutput + "\'\'";
                }
            }
            return strOutput.CheckBlankEx();
        }


        public static string ToUpperFirstAndLowerString(this string pStrInput)
        {
            if (pStrInput.TrimEx().Length <= 0)
            {
                return "";
            }

            return pStrInput.SubstringEx(0, 1).ToUpper() + pStrInput.SubstringEx(1).ToLower();
        }

        /// <summary>
        /// If the given string is null or empty, the function returns a space (' ') instead.
        /// Otherwise, the function returns a trimmed string.
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string CheckBlankEx(this string strInput)
        {
            if (strInput == null)
            {
                return " ";
            }

            return strInput.Trim() == "" ? " " : strInput.Trim();
        }

        /// <summary>
        /// Check if string is null or empty then return space
        /// otherwise return trim of itself        
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CheckBlankEx(this object str)
        {
            if (str == null)
                return " ";

            string returnVal = str.TrimEx();

            if (returnVal == "")
                return " ";

            return returnVal;
        }

        /// <summary>
        /// Convert object to bool value
        /// if can not, return 0
        /// </summary>
        /// <param name="inputVal"></param>
        /// <returns></returns>
        public static bool CheckBooleanEx(this object inputVal)
        {
            if (inputVal == null)
                return false;

            bool retValue;

            if (Boolean.TryParse(inputVal.TrimEx(), out retValue))
            {
                return (bool)retValue;
            }

            return false;
        }

        /// <summary>
        /// Convert object to int value
        /// if can not, return 0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int CheckIntEx(this object str)
        {
            if (str == null)
                return 0;

            Double retValue;

            if (Double.TryParse(str.TrimEx(), out retValue))
            {
                return (int)retValue;
            }

            //if (Int32.TryParse(str.TrimEx(), out retValue))
            //{
            //    return retValue;
            //}

            return 0;
        }

        public static decimal CheckDecimalEx(this object str)
        {
            if (str == null)
                return (decimal)0.0;

            decimal retValue;
            if (decimal.TryParse(str.TrimEx(), out retValue))
            {
                return retValue;
            }

            return 0;
        }

        /// <summary>
        /// convert object to double value
        /// if can not return 0.0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double CheckDoubleEx(this object str)
        {
            if (str == null)
                return 0.0;

            double retValue;
            if (Double.TryParse(str.TrimEx(), out retValue))
            {
                return retValue;
            }

            return 0;
        }

        /// <summary>
        /// convert object to long value
        /// if can not reuturn 0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long CheckLongEx(this object str)
        {
            if (str == null)
                return 0;

            long retValue;
            if (Int64.TryParse(str.TrimEx(), out retValue))
            {
                return retValue;
            }

            return 0;
        }

        /// <summary>
        /// Return string with fix size
        /// </summary>
        /// <returns></returns>
        public static string FixString(this string str, int size)
        {
            string result;

            if (str.Length > size)
            {
                result = str.SubstringEx(0, size);
            }
            else
            {
                var format = $"{{0, {-size}}}";
                result = string.Format(format, str);
            }

            return result;
        }

        /// <summary>
        /// Check if input string is null or empty/whitespace only
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
        public static bool IsEmpty(this object str)
        {
            return IsEmptyEx(str.ToStringEx());
        }

        public static bool IsEmptyEx(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        /// <summary>
        /// Check if input string is alphabet character
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsAlphabet(this string str)
        {
            string checkStr = str.ToUpper();

            if (checkStr.Trim().Length == 0)
                return false;

            int length = str.Length;
            for (int i = 0; i < length; i++)
            {
                if (!('A' <= checkStr[i] && checkStr[i] <= 'Z'))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Check input string is Digit characters
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDigit(this string str)
        {
            string checkStr = str;

            if (checkStr.Trim().Length == 0)
            {
                return false;
            }

            int length = str.Length;
            for (int i = 0; i < length; i++)
            {
                if (!('0' <= checkStr[i] && checkStr[i] <= '9'))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Check if input string is number
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumber(this string str)
        {
            if (str.Length == 0)
                return false;

            double retValue;
            return (Double.TryParse(str.TrimEx(), out retValue));
        }

        /// <summary>
        /// Get length of string in byte
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int LengthByte(this string str)
        {
            byte[] unicodeByte = Encoding.Unicode.GetBytes(str);
            return Encoding.Unicode.GetCharCount(unicodeByte);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubStringByte(this string str, int length)
        {
            int byteCount = 0;
            char[] buffer = new char[1];
            for (int i = 0; i < str.Length; i++)
            {
                buffer[0] = str[i];
                byteCount += Encoding.UTF8.GetByteCount(buffer);
                if (byteCount > length)
                {
                    // Couldn't add this character. Return its index
                    return str.Substring(0, i);
                }
            }
            return str;
        }

        public static string RejectMarks(this string text)
        {
            var pattern = new string[7];
            var replaceChar = new char[14];

            // Khởi tạo giá trị thay thế

            replaceChar[0] = 'a';
            replaceChar[1] = 'd';
            replaceChar[2] = 'e';
            replaceChar[3] = 'i';
            replaceChar[4] = 'o';
            replaceChar[5] = 'u';
            replaceChar[6] = 'y';
            replaceChar[7] = 'A';
            replaceChar[8] = 'D';
            replaceChar[9] = 'E';
            replaceChar[10] = 'I';
            replaceChar[11] = 'O';
            replaceChar[12] = 'U';
            replaceChar[13] = 'Y';

            //Mẫu cần thay thế tương ứng

            pattern[0] = "(á|à|ả|ã|ạ|ă|ắ|ằ|ẳ|ẵ|ặ|â|ấ|ầ|ẩ|ẫ|ậ)"; //letter a
            pattern[1] = "đ"; //letter d
            pattern[2] = "(é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ)"; //letter e
            pattern[3] = "(í|ì|ỉ|ĩ|ị)"; //letter i
            pattern[4] = "(ó|ò|ỏ|õ|ọ|ô|ố|ồ|ổ|ỗ|ộ|ơ|ớ|ờ|ở|ỡ|ợ)"; //letter o
            pattern[5] = "(ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự)"; //letter u
            pattern[6] = "(ý|ỳ|ỷ|ỹ|ỵ)"; //letter y

            for (int i = 0; i < pattern.Length; i++)
            {
                MatchCollection matchs = Regex.Matches(text, pattern[i], RegexOptions.IgnoreCase);
                foreach (Match m in matchs)
                {
                    char ch = char.IsLower(m.Value[0]) ? replaceChar[i] : replaceChar[i + 7];
                    text = text.Replace(m.Value[0], ch);
                }
            }
            return text;
        }

        public static string RejectMarksRegex(this string ip_str_change)
        {
            if (ip_str_change.IsEmpty())
            {
                return ip_str_change;
            }

            var v_reg_regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string v_str_FormD = ip_str_change.Normalize(NormalizationForm.FormD);

            var ret = v_reg_regex.Replace(v_str_FormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');

            var value = ret.PureASCII();

            return value;

        }

        public static string PureASCII(this string input)
        {
            var min = '\u0000';
            var max = '\u007F';
            return new string(input.Where(c => (c >= min && c < max)).ToArray());
        }

        /// <summary>
        /// Find findVal in the InString whole word only, if found return true,
        /// false otherwise
        /// </summary>
        /// <param name="inString"></param>
        /// <param name="findVal"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static bool ContainsEx(this string inString, string findVal, string splitChar = "")
        {
            if (splitChar.IsEmpty())
            {
                return inString == findVal;
            }

            string[] list = inString.ToUpper().Split(splitChar.ToCharArray());
            findVal = findVal.ToUpper().TrimEx();
            return list.Any(t => t.TrimEx() == findVal);
        }

        /// <summary>
        /// Remove all empty, blank chracter in string
        /// </summary>
        /// <param name="inString"></param>
        /// <returns></returns>
        public static string RemoveBlank(this string inString)
        {
            if (inString.IsEmpty())
            {
                return inString;
            }

            var strOutput = inString.ToCharArray().Where(c => c != ' ' && c != '\t' && c != '\r' && c != '\n').Aggregate("", (current, c) => current + c);

            return strOutput.TrimEx();
        }

        /// <summary>
        /// replace all \t \r \n by empty character 
        /// </summary>
        /// <param name="inString"></param>
        /// <returns></returns>
        public static string ReplaceBlank(this string inString)
        {
            if (inString.IsEmpty())
            {
                return inString;
            }

            var strOutput = "";
            foreach (char c in inString)
            {
                if (c == '\t' || c == '\r' || c == '\n' || c == (char)0xA0)
                {
                    strOutput = strOutput + " ";
                }
                else
                {
                    strOutput = strOutput + c;
                }
            }

            return strOutput.TrimEx();
        }

        /// <summary>
        /// Get number digit character in string
        /// </summary>
        /// <param name="inString"></param>
        /// <returns></returns>
        public static string GetNumericChar(this string inString)
        {
            var strOutput = inString.ToCharArray().Where(Char.IsDigit).Aggregate("", (current, c) => current + c);

            return strOutput.TrimEx();
        }

        /// <summary>
        /// Check if given Iso string is define for gerneral container
        /// </summary>
        /// <param name="iso"></param>
        /// <returns></returns>
        public static bool IsIsoGeneral(this string iso)
        {
            return ("0".Contains(iso.SubstringEx(2, 1).ToUpper()));
        }

        /// <summary>
        /// Kiểm tra Iso có phải cont 20 feet
        /// </summary>
        /// <param name="iso"></param>
        /// <returns></returns>
        public static bool IsIso20Feet(this string iso)
        {
            return ("2".Contains(iso.SubstringEx(0, 1).ToUpper()));
        }

        /// <summary>
        /// Kiểm tra Iso có phải cont 40 feet
        /// </summary>
        /// <param name="iso"></param>
        /// <returns></returns>
        public static bool IsIso40Feet(this string iso)
        {
            return ("49L".Contains(iso.SubstringEx(0, 1).ToUpper()));
        }

        public static bool IsIsoHigh(this string iso)
        {
            return ("4595L5".Contains(iso.SubstringEx(0, 2).ToUpper()));
        }
        /// <summary>
        /// Check if given Iso string is define for reefer container
        /// </summary>
        /// <param name="iso"></param>
        /// <returns></returns>
        public static bool IsIsoReefer(this string iso)
        {
            return ("34R".Contains(iso.SubstringEx(2, 1).ToUpper()));
        }

        public static bool IsIsoDry(this string iso)
        {
            return ("0G".Contains(iso.SubstringEx(2, 1).ToUpper()));
        }
        /// <summary>
        /// Check if given Iso string is define for flatrack container
        /// </summary>
        /// <param name="iso"></param>
        /// <returns></returns>
        public static bool IsIsoFlatRack(this string iso)
        {
            return ("P6".Contains(iso.SubstringEx(2, 1).ToUpper()));
        }

        public static bool IsIsoOog(this string iso)
        {
            return ("O5P6".Contains(iso.SubstringEx(2, 1).ToUpper()));
        }

        public static bool IsIsoTank(this string iso)
        {
            return ("T7".Contains(iso.SubstringEx(2, 1).ToUpper()));
        }
        /// <summary>
        /// Check if given Iso string is define for onpen top container
        /// </summary>
        /// <param name="iso"></param>
        /// <returns></returns>
        public static bool IsIsoOpenTop(this string iso)
        {
            return ("5".Contains(iso.SubstringEx(2, 1).ToUpper()));
        }

        public static bool IsDeliveryOperType(this string operationType)
        {
            return (operationType == "DELV" || operationType == "EDELV" || operationType == "DEPOTDELV");
        }

        /// <summary>
        /// Check if given string is valid taxfile no
        /// </summary>
        /// <param name="taxFileNo"></param>
        /// <returns></returns>
        public static bool IsValidTaxFileNo(this string taxFileNo)
        {
            if (taxFileNo.TrimEx().Length < 5)
            {
                return false;
            }

            if (taxFileNo.ToUpper().ToCharArray().Any(c => "ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*?~".Contains(c)))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check if given string is valid taxfile no
        /// </summary>
        /// <param name="sealNo"></param>
        /// <returns></returns>
        public static bool IsValidSealNo(this string sealNo)
        {
            if (sealNo.IsEmpty())
            {
                return false;
            }

            if (sealNo.Length > 20)
            {
                return false;
            }

            return !sealNo.IsContainUnicode();

        }

        /// <summary>
        /// Check if given string is valid taxfile no
        /// </summary>
        /// <param name="bookNo"></param>
        /// <returns></returns>
        public static bool IsValidBookNo(this string bookNo)
        {
            if (bookNo.IsEmpty())
            {
                return true;
            }

            if (bookNo.ToUpper().ToCharArray().Any(c => !"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".Contains(c)))
            {
                return false;
            }

            if (bookNo.Length > 20)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check if given string is valid taxfile no
        /// </summary>
        /// <param name="billingNo"></param>
        /// <returns></returns>
        public static bool IsValidBillNo(this string billingNo)
        {
            if (billingNo.IsEmpty())
            {
                return true;
            }

            if (billingNo.ToUpper().ToCharArray().Any(c => !"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".Contains(c)))
            {
                return false;
            }

            if (billingNo.Length > 20)
            {
                return false;
            }

            return true;
        }

        public static bool IsContainUnicode(this string input)
        {
            const int MaxAnsiCode = 127;
            return input.Any(c => c > MaxAnsiCode);
        }


        /// <summary>
        /// Check if given Iso string is define for tank container
        /// abcd: ab70 -> ab79
        /// </summary>
        /// <param name="iso"></param>
        /// <returns></returns>
        public static bool IsTank(this string iso)
        {
            var tmp = iso.SubstringEx(2, 2).ToUpper();
            return (tmp.CheckIntEx() >= 70 && tmp.CheckIntEx() <= 79);
        }

        /// <summary>
        /// Check if given port string is define for local port
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool IsDomesticPort(this string port)
        {
            if (port == null)
            {
                return false;
            }

            return (port.SubstringEx(0, 2).ToUpper() == "VN");
        }

        /// <summary>
        /// Format number to string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="numOfDec"></param>
        /// <returns></returns>
        public static string FormatNum(this object input, int numOfDec)
        {
            string value = input.ToStringEx();

            if (value.IsNumber())
            {

                decimal decNumber = Convert.ToDecimal(value);

                string result;
                if (numOfDec > 0)
                {
                    //result = String.Format("{0:0,0.00}", decNumber);

                    string sNumDecimal = "";
                    for (int i = 0; i < numOfDec; i++)
                    {
                        sNumDecimal += "0";
                    }

                    string sFormatPattern = "{0:#,0." + sNumDecimal + "}";
                    result = String.Format(sFormatPattern, decNumber);
                }
                else
                {
                    decNumber = decNumber.ToString().CheckIntEx();
                    result = $"{decNumber:#,0}";           //Hao, 26/08/2010
                }

                return result;
            }

            return value;

        }



        /// <summary>
        /// Remvoe single qoute from input string
        /// </summary>
        /// <param name="pStrInput"></param>
        /// <returns></returns>
        public static string DeleteSingleQuote(this string pStrInput)
        {
            if (pStrInput == null)
            {
                return null;
            }
            if (pStrInput.IsEmpty())
            {
                return "";
            }

            int i;

            string strOutput = "";
            int strLen = pStrInput.Length;

            for (i = 0; i < strLen; i++)
            {
                string strTmp = pStrInput.SubstringEx(i, 1);
                if (strTmp != "\'")
                {
                    strOutput = strOutput + strTmp;
                }
            }
            return strOutput;
        }

        public static string AppendSingleQuote(this string pStrInput)
        {
            if (pStrInput == null)
            {
                return null;
            }
            if (pStrInput.IsEmpty())
            {
                return "";
            }

            pStrInput = pStrInput.RemoveMultipleWhiteSpaces();
            while (pStrInput.Contains("''"))
            {
                pStrInput = pStrInput.Replace("''", "'");
            }

            return pStrInput.Replace("'", "''");
        }

        /// <summary>
        /// Round a number to accounting number
        /// Sai so lam tron cho phep = 0.5% neu so nho hon 1
        /// </summary>
        public static double RoundDoubleEx(this double piNumber, int maxPrecion = 10)
        {
            double ret = piNumber;


            if (ret == 0.0)
            {
                return piNumber;
            }

            //var precionNumber = (piNumber - Math.Truncate(piNumber)).ToString().SubstringEx(0, 2+maxPrecion).CheckDoubleEx();

            var intNumber = Math.Truncate(piNumber);

            var precionNum = piNumber - intNumber;

            precionNum = Math.Round(precionNum, 10);

            double retNum = precionNum.ToString("0.0000000000").SubstringEx(0, 2 + maxPrecion).CheckDoubleEx();
            var checkNum = precionNum.ToString("0.0000000000").SubstringEx(2 + maxPrecion, 1).CheckIntEx();

            if (checkNum >= 5)
            {
                retNum = (retNum * Math.Pow(10, maxPrecion) + 1) / Math.Pow(10, maxPrecion);
            }

            var result = Math.Round(intNumber + retNum, maxPrecion);

            return result;


        }

        /// <summary>
        /// Convert a number to accounting string , apply for Calculate Amount
        /// </summary>
        public static string ToAccountingStringEx(this double piNUmber, int piDecimal = 2, bool isVNDFormat = false)
        {
            string result = "";
            double retVal = piNUmber;

            if (piNUmber != 0)
            {

                if (Math.Abs(piNUmber) < 1)
                {
                    int i = 0;
                    while (i < 10)
                    {
                        if (Math.Abs(piNUmber - piNUmber.RoundDoubleEx(i)) / piNUmber < 0.001)
                        // if < 1 return the value round exact 1/1000 dvduoc 30-03-2012
                        {
                            retVal = piNUmber.RoundDoubleEx(i);
                            break;
                        }
                        i++;
                    }
                }
                else
                {
                    retVal = piNUmber.RoundDoubleEx(piDecimal);
                }
            }

            if (retVal == 0)
            {
                if (piDecimal == 0)
                {
                    result = "0";
                }
                else
                {
                    string lsFormat = "000000".Substring(0, piDecimal);
                    result = "0." + lsFormat;
                }

            }
            else if (Math.Abs(piNUmber) < 1)
            {
                result = retVal.ToString().Replace(",", ".");
            }
            else
            {
                if (piDecimal == 0)
                {
                    if (Math.Abs(retVal) < 1000)
                        result = retVal.ToString("0");
                    else
                        result = retVal.ToString("0,0");
                }
                else
                {
                    string lsFormat = "000000".Substring(0, piDecimal);
                    if (Math.Abs(retVal) < 1000)
                        result = retVal.ToString("0." + lsFormat);
                    else
                        result = retVal.ToString("0,0." + lsFormat);
                }
            }

            if (isVNDFormat)
            {
                result = result.Replace(".", "@");
                result = result.Replace(",", ".");
                result = result.Replace("@", ",");
            }
            return result;
        }

        public static string ToAccountingVNPTStringEx(this double piNUmber, int piDecimal = 2, bool isVNDFormat = false)
        {
            string result = "";
            double retVal = piNUmber;

            if (piNUmber != 0)
            {

                if (Math.Abs(piNUmber) < 1)
                {
                    int i = 0;
                    while (i < 10)
                    {
                        if (Math.Abs(piNUmber - piNUmber.RoundDoubleEx(i)) / piNUmber < 0.001)
                        {
                            retVal = piNUmber.RoundDoubleEx(i);
                            break;
                        }
                        i++;
                    }
                }
                else
                {
                    retVal = piNUmber.RoundDoubleEx(piDecimal);
                }
            }

            if (retVal == 0)
            {
                if (piDecimal == 0)
                {
                    result = "0";
                }
                else
                {
                    string lsFormat = "000000".Substring(0, piDecimal);
                    result = "0." + lsFormat;
                }

            }
            else if (Math.Abs(piNUmber) < 1)
            {
                result = retVal.ToString().Replace(",", ".");
            }
            else
            {
                if (piDecimal == 0)
                {
                    if (Math.Abs(retVal) < 1000)
                        result = retVal.ToString("0");
                    else
                        result = retVal.ToString("0,0");
                }
                else
                {
                    string lsFormat = "000000".Substring(0, piDecimal);
                    result = retVal.ToString("0." + lsFormat);
                }
            }
            return result;
        }

        /// <summary>
        /// Convert a number to accounting string , apply for Calculate Amount
        /// </summary>
        public static string ToVNDDisplayString(this double piNUmber)
        {
            int piDecimal = 0;

            string result = "";
            double retVal = piNUmber;

            var deNumber = piNUmber - piNUmber.RoundDoubleEx(0);

            if (deNumber != 0)
            {
                piDecimal = piNUmber.ToString().Length - piNUmber.RoundDoubleEx(0).ToString().Length - 1;
            }

            string lsFormat = "000000".Substring(0, piDecimal);


            if (retVal == 0)
            {
                return retVal.ToString();
            }

            if (piDecimal == 0)
            {
                if (Math.Abs(retVal) < 1000)
                    result = retVal.ToString("0");
                else
                    result = retVal.ToString("0,0");
            }
            else
            {
                if (Math.Abs(retVal) < 1000)
                    result = retVal.ToString("0." + lsFormat);
                else
                    result = retVal.ToString("0,0." + lsFormat);
            }

            result = result.Replace(".", "@");
            result = result.Replace(",", ".");
            result = result.Replace("@", ",");

            return result;
        }

        /// <summary>
        /// Hiển thị tiền tệ theo chuẩn Việt Nam
        /// </summary>
        /// <param name="piNUmber"></param>
        /// <returns></returns>
        public static string ToAccountingStringVn(this double piNUmber)
        {
            var retVal = piNUmber.ToString("#,##0.00");
            retVal = retVal.Replace(".", "@");
            retVal = retVal.Replace(",", ".");
            retVal = retVal.Replace("@", ",");
            return retVal;
        }

        /// <summary>
        /// convert chuỗi hiển thị tiền tệ theo chuẩn Việt Nam về kiểu số
        /// </summary>
        /// <param name="psNUmber"></param>
        /// <returns></returns>
        public static double AccountingStringVnToNumber(this string psNUmber)
        {
            var retVal = psNUmber;
            retVal = retVal.Replace(".", "@");
            retVal = retVal.Replace(",", ".");
            retVal = retVal.Replace("@", ",");
            return retVal.CheckDoubleEx();
        }

        public static double StringToNumber(this string psInput)
        {
            if (psInput.IsEmpty())
            {
                return 0;
            }
            var retVal = psInput;
            var commaIdx = psInput.LastIndexOf(',');
            var dotIdx = psInput.LastIndexOf('.');

            if (commaIdx >= 0 && dotIdx >= 0)
            {
                if (dotIdx > commaIdx)
                {
                    retVal = retVal.Replace(",", "");
                    return retVal.CheckDoubleEx();
                }

                if (dotIdx < commaIdx)
                {
                    retVal = retVal.Replace("", "");
                    retVal = retVal.Replace(",", ".");
                    return retVal.CheckDoubleEx();
                }
            }

            if (commaIdx >= 0)
            {
                if (psInput.Count(c => c == ',') > 1 || (psInput.SubstringEx(commaIdx + 1).Length % 3 == 0))
                {
                    retVal = retVal.Replace(",", "");
                }
                else
                {
                    retVal = retVal.Replace(",", ".");
                }

                return retVal.CheckDoubleEx();
            }

            if (psInput.Count(c => c == '.') > 1)
            {
                retVal = retVal.Replace(".", "");
            }

            return retVal.CheckDoubleEx();
        }

        #endregion

        #region Value OBJECT


        /// <summary>
        /// Copy các dữ liệu của Object, các dữ liệu có kiểu : string, số, ngày. 
        /// Các kiểu dữ liệu object khác thì gán tham chiếu.
        /// </summary>
        /// <returns></returns>
        public static void CopyDataTo(this Object fromObj, Object toObj)
        {
            if (fromObj.GetType().ToString() != toObj.GetType().ToString())
            {
                throw new Exception($"Different type {fromObj.GetType()} & {toObj.GetType()}");

            }

            PropertyInfo[] propsInfo = fromObj.GetType().GetProperties();
            foreach (PropertyInfo property in propsInfo)
            {
                if (!property.CanWrite)
                {
                    continue;
                }
                property.SetValue(toObj, property.GetValue(fromObj, null), null);
            }
        }

        /// <summary>
        /// cho phép cop từ object A sang B với A và B khác kiểu
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="toObj"></param>
        public static void CopyDataToEx(this Object fromObj, Object toObj)
        {


            PropertyInfo[] propsInfo = fromObj.GetType().GetProperties();
            PropertyInfo[] propsInfoTo = toObj.GetType().GetProperties();

            foreach (PropertyInfo property in propsInfo)
            {
                foreach (PropertyInfo propertyTo in propsInfoTo)
                {
                    if (propertyTo.Name == property.Name)
                    {
                        if (!property.CanWrite)
                        {
                            break;
                        }

                        try
                        {
                            propertyTo.SetValue(toObj, property.GetValue(fromObj, null), null);
                        }
                        catch
                        {

                        }

                        break;
                    }
                }



            }
        }

        /// <summary>
        /// sai khác : trả về false, giống nhau về dữ liệu trả về true
        /// </summary>
        /// <param name="fromObj"></param>
        /// <param name="toObj"></param>
        /// <returns></returns>
        public static bool CompareData(this Object fromObj, Object toObj)
        {
            if (fromObj.GetType().ToString() != toObj.GetType().ToString())
            {
                throw new Exception($"Different type {fromObj.GetType()} & {toObj.GetType()}");

            }

            PropertyInfo[] propsInfo = fromObj.GetType().GetProperties();
            foreach (PropertyInfo property in propsInfo)
            {

                var val1 = property.GetValue(fromObj, null);
                var val2 = property.GetValue(toObj, null);

                if (val1 == null)
                {
                    val1 = "";
                }

                if (val2 == null)
                {
                    val2 = "";
                }


                if (val1.ToString() != val2.ToString())
                {
                    return false;
                }
            }

            return true;
        }


        #endregion


        #region DATA
        public static void DisposeEx<T>(this IEnumerable<T> source)
        {
            foreach (object obj in source)
            {
                // uses modern pattern-matching
                if (obj is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
        }


        /// <summary>
        /// Kiểm tra DataSet có chứa dữ liệu hay không
        /// </summary>
        /// <param name="poDataSet"></param>
        /// <returns>True: Nếu có dữ liệu, false: không có dữ liệu</returns>
        public static bool IsEmptyData(this DataSet poDataSet)
        {
            bool lbEmpty = true;
            if (poDataSet != null && poDataSet.Tables.Count > 0)
            {
                foreach (DataTable loDT in poDataSet.Tables)
                {
                    if (loDT.Rows.Count > 0)
                    {
                        lbEmpty = false;
                    }

                }
            }
            return lbEmpty;
        }

        /// <summary>
        /// Check if Table container value identify by column name
        /// </summary>
        public static bool TableContainField(this DataTable pData, string pColumn, string pValue)
        {
            DataRow[] dr = pData.Select(pColumn + " = '" + pValue.Trim() + "' ");
            if (dr.Length > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Merge 2 Table into 1 Table by key column
        /// </summary>
        /// <param name="pMainData"></param>
        /// <param name="pGuestData"></param>
        /// <param name="m_KeyValue"></param>
        /// <returns></returns>
        public static DataTable MergeData(this DataTable pMainData, DataTable pGuestData, string m_KeyValue)
        {
            DataTable retData = pMainData.Clone();

            for (int i = 0; i < pGuestData.Columns.Count; i++)
                if (!retData.Columns.Contains(pGuestData.Columns[i].ColumnName))
                    retData.Columns.Add(pGuestData.Columns[i].ColumnName);

            //DataTable onGuestTable = retData.Clone();
            int idx = 0;
            foreach (DataRow dr in pMainData.Rows)
            {
                retData.ImportRow(dr);

                if (!pMainData.Columns.Contains(m_KeyValue) || !pGuestData.Columns.Contains(m_KeyValue))
                {
                    continue;
                }

                for (int i = 0; i < pGuestData.Rows.Count; i++)
                {
                    if (pGuestData.Rows[i][m_KeyValue].TrimEx() == dr[m_KeyValue].TrimEx())
                    {
                        for (int j = 0; j < pGuestData.Columns.Count; j++)
                        {
                            if (pGuestData.Columns[j].ColumnName.TrimEx().ToUpper() != m_KeyValue.Trim().ToUpper())
                                retData.Rows[idx][pGuestData.Columns[j].ColumnName] = pGuestData.Rows[i][j];
                        }

                        break;
                    }
                }
                idx++;
            }

            foreach (DataRow dr in pGuestData.Rows)
            {
                if (!pMainData.Columns.Contains(m_KeyValue) || !pGuestData.Columns.Contains(m_KeyValue))
                {
                    retData.ImportRow(dr);
                }
                else if (pMainData.Select($"{m_KeyValue} = '{dr[m_KeyValue].TrimEx()}'").Length <= 0)
                {
                    retData.ImportRow(dr);
                }
            }

            return retData;

        }


        #endregion

        #region OTHER

        /// <summary>
        /// Kiem tra co phai la gia tri null?
        /// Qui dinh DateTime = {31/12/1900} la gia tri null, empty
        /// </summary>
        /// <param name="poCheck"></param>
        /// <returns></returns>
        /// <history>
        /// Create by thhung, 23/08/2010
        /// </history>
        public static bool IsNullDateTime(this DateTime poCheck)
        {
            return poCheck.Year <= 1900;
        }

        public static string GetMd5Hash(this string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public static bool VerifyMd5Hash(this string input, string hash)
        {
            // Hash the input.
            string hashOfInput = input.GetMd5Hash();

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }

            return false;
        }

        public static int Max(this System.Enum enumType)
        {
            return System.Enum.GetValues(enumType.GetType()).Cast<int>().Max();
        }

        /// <summary>
        /// Convert a temperature value to string
        /// </summary>
        /// <returns></returns>
        public static string ConvertTempToString(this object temp)
        {
            try
            {
                if (Convert.ToDouble(temp) == 9999)
                {
                    return string.Empty;
                }

                return temp.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }

        }

        /// <summary>
        /// Convert a string to temperature value
        /// </summary>
        /// <returns></returns>
        public static double ConvertStringToTemp(this string temp)
        {
            if (string.IsNullOrWhiteSpace(temp))
            {
                return 9999;
            }

            return temp.CheckDoubleEx();
        }

        public static bool SqlLike(this string str, string pattern)
        {
            bool isMatch = true,
                isWildCardOn = false,
                isCharWildCardOn = false,
                isCharSetOn = false,
                isNotCharSetOn = false,
                endOfPattern = false;
            int lastWildCard = -1;
            int patternIndex = 0;
            List<char> set = new List<char>();
            char p = '\0';

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                endOfPattern = (patternIndex >= pattern.Length);
                if (!endOfPattern)
                {
                    p = pattern[patternIndex];

                    if (!isWildCardOn && p == '%')
                    {
                        lastWildCard = patternIndex;
                        isWildCardOn = true;
                        while (patternIndex < pattern.Length &&
                            pattern[patternIndex] == '%')
                        {
                            patternIndex++;
                        }
                        if (patternIndex >= pattern.Length) p = '\0';
                        else p = pattern[patternIndex];
                    }
                    else if (p == '_')
                    {
                        isCharWildCardOn = true;
                        patternIndex++;
                    }
                    else if (p == '[')
                    {
                        if (pattern[++patternIndex] == '^')
                        {
                            isNotCharSetOn = true;
                            patternIndex++;
                        }
                        else isCharSetOn = true;

                        set.Clear();
                        if (pattern[patternIndex + 1] == '-' && pattern[patternIndex + 3] == ']')
                        {
                            char start = char.ToUpper(pattern[patternIndex]);
                            patternIndex += 2;
                            char end = char.ToUpper(pattern[patternIndex]);
                            if (start <= end)
                            {
                                for (char ci = start; ci <= end; ci++)
                                {
                                    set.Add(ci);
                                }
                            }
                            patternIndex++;
                        }

                        while (patternIndex < pattern.Length &&
                            pattern[patternIndex] != ']')
                        {
                            set.Add(pattern[patternIndex]);
                            patternIndex++;
                        }
                        patternIndex++;
                    }
                }

                if (isWildCardOn)
                {
                    if (char.ToUpper(c) == char.ToUpper(p))
                    {
                        isWildCardOn = false;
                        patternIndex++;
                    }
                }
                else if (isCharWildCardOn)
                {
                    isCharWildCardOn = false;
                }
                else if (isCharSetOn || isNotCharSetOn)
                {
                    bool charMatch = (set.Contains(char.ToUpper(c)));
                    if ((isNotCharSetOn && charMatch) || (isCharSetOn && !charMatch))
                    {
                        if (lastWildCard >= 0) patternIndex = lastWildCard;
                        else
                        {
                            isMatch = false;
                            break;
                        }
                    }
                    isNotCharSetOn = isCharSetOn = false;
                }
                else
                {
                    if (char.ToUpper(c) == char.ToUpper(p))
                    {
                        patternIndex++;
                    }
                    else
                    {
                        if (lastWildCard >= 0) patternIndex = lastWildCard;
                        else
                        {
                            isMatch = false;
                            break;
                        }
                    }
                }
            }
            endOfPattern = (patternIndex >= pattern.Length);

            if (isMatch && !endOfPattern)
            {
                bool isOnlyWildCards = true;
                for (int i = patternIndex; i < pattern.Length; i++)
                {
                    if (pattern[i] != '%')
                    {
                        isOnlyWildCards = false;
                        break;
                    }
                }
                if (isOnlyWildCards) endOfPattern = true;
            }
            return isMatch && endOfPattern;
        }

        /// <summary>
        /// Convert a number to a string value. if the given value is 0, then return an empty string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToNonZeroString(this object value)
        {
            if ((int)value == 0)
            {
                return string.Empty;
            }

            return value.ToStringEx();

        }

        /// <summary>
        ///     So sánh 2 giá trị
        /// </summary>
        /// <param name="rootValue"></param>
        /// <param name="compareValue"></param>
        /// <returns></returns>
        public static int CompareToGetMark(this string rootValue, string compareValue)
        {
            int mark = 0;

            if (rootValue.TrimEx() == compareValue.TrimEx())
            {
                //ưu tiên 2 điểm
                mark++;
                mark++;
            }
            else
            {
                if (rootValue.TrimEx() == string.Empty)
                {
                    mark++;
                }
                else
                {
                    return 0;
                }
            }

            return mark;

        }




        /// <summary>
        /// Chia nhỏ list object
        /// Created by: dvthuan 21/05/2014
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="groupSize"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> GetEnumerableOfEnumerables<T>(this IEnumerable<T> enumerable, int groupSize)
        {
            // The list to return.
            var list = new List<T>(groupSize);

            // Cycle through all of the items.
            foreach (T item in enumerable)
            {
                // Add the item.
                list.Add(item);

                // If the list has the number of elements, return that.
                if (list.Count == groupSize)
                {
                    // Return the list.
                    yield return list;

                    // Set the list to a new list.
                    list = new List<T>(groupSize);
                }
            }

            // Return the remainder if there is any,
            if (list.Count != 0)
            {
                // Return the list.
                yield return list;
            }
        }

        /// <summary>
        /// Convert font Unicode to Vni
        /// dvthuan 18/12/2014
        /// </summary>
        /// <param name="vnstr"></param>
        /// <returns></returns>
        public static string UniCodeToVni(this string vnstr)
        {
            var uniCodeToVni = "";
            var temp = "";
            char c;
            for (int i = 0; i < vnstr.Length; i++)
            {
                c = vnstr.SubstringEx(i, 1)[0];

                temp = "";

                switch (c)
                {
                    case (char)97:
                        temp = "a"; break;
                    case (char)(225):
                        temp = "aù"; break;
                    case (char)(224):
                        temp = "aø"; break;
                    case (char)(7843):
                        temp = "aû"; break;
                    case (char)(227):
                        temp = "aõ"; break;
                    case (char)(7841):
                        temp = "aï"; break;
                    case (char)(259):
                        temp = "aê"; break;
                    case (char)(7855):
                        temp = "aé"; break;
                    case (char)(7857):
                        temp = "aè"; break;
                    case (char)(7859):
                        temp = "aú"; break;
                    case (char)(7861):
                        temp = "aü"; break;
                    case (char)(7863):
                        temp = "aë"; break;
                    case (char)(226):
                        temp = "aâ"; break;
                    case (char)(7845):
                        temp = "aá"; break;
                    case (char)(7847):
                        temp = "aà"; break;
                    case (char)(7849):
                        temp = "aå"; break;
                    case (char)(7851):
                        temp = "aã"; break;
                    case (char)(7853):
                        temp = "aä"; break;
                    case (char)(101):
                        temp = "e"; break;
                    case (char)(233):
                        temp = "eù"; break;
                    case (char)(232):
                        temp = "eø"; break;
                    case (char)(7867):
                        temp = "eû"; break;
                    case (char)(7869):
                        temp = "eõ"; break;
                    case (char)(7865):
                        temp = "eï"; break;
                    case (char)(234):
                        temp = "eâ"; break;
                    case (char)(7871):
                        temp = "eá"; break;
                    case (char)(7873):
                        temp = "eà"; break;
                    case (char)(7875):
                        temp = "eå"; break;
                    case (char)(7877):
                        temp = "eã"; break;
                    case (char)(7879):
                        temp = "eä"; break;
                    case (char)(111):
                        temp = "o"; break;
                    case (char)(243):
                        temp = "où"; break;
                    case (char)(242):
                        temp = "oø"; break;
                    case (char)(7887):
                        temp = "oû"; break;
                    case (char)(245):
                        temp = "oõ"; break;
                    case (char)(7885):
                        temp = "oï"; break;
                    case (char)(244):
                        temp = "oâ"; break;
                    case (char)(7889):
                        temp = "oá"; break;
                    case (char)(7891):
                        temp = "oà"; break;
                    case (char)(7893):
                        temp = "oå"; break;
                    case (char)(7895):
                        temp = "oã"; break;
                    case (char)(7897):
                        temp = "oä"; break;
                    case (char)(417):
                        temp = "ô"; break;
                    case (char)(7899):
                        temp = "ôù"; break;
                    case (char)(7901):
                        temp = "ôø"; break;
                    case (char)(7903):
                        temp = "ôû"; break;
                    case (char)(7905):
                        temp = "ôõ"; break;
                    case (char)(7907):
                        temp = "ôï"; break;
                    case (char)(105):
                        temp = "i"; break;
                    case (char)(237):
                        temp = "í"; break;
                    case (char)(236):
                        temp = "ì"; break;
                    case (char)(7881):
                        temp = "æ"; break;
                    case (char)(297):
                        temp = "ó"; break;
                    case (char)(7883):
                        temp = "ò"; break;
                    case (char)(117):
                        temp = "u"; break;
                    case (char)(250):
                        temp = "uù"; break;
                    case (char)(249):
                        temp = "uø"; break;
                    case (char)(7911):
                        temp = "uû"; break;
                    case (char)(361):
                        temp = "uõ"; break;
                    case (char)(7909):
                        temp = "uï"; break;
                    case (char)(432):
                        temp = "ö"; break;
                    case (char)(7913):
                        temp = "öù"; break;
                    case (char)(7915):
                        temp = "uø"; break;
                    case (char)(7917):
                        temp = "öû"; break;
                    case (char)(7919):
                        temp = "öõ"; break;
                    case (char)(7921):
                        temp = "öï"; break;
                    case (char)(121):
                        temp = "y"; break;
                    case (char)(253):
                        temp = "yù"; break;
                    case (char)(7923):
                        temp = "yø"; break;
                    case (char)(7927):
                        temp = "yû"; break;
                    case (char)(7929):
                        temp = "yõ"; break;
                    case (char)(7925):
                        temp = "î"; break;
                    case (char)(273):
                        temp = "ñ"; break;
                    case (char)(65):
                        temp = "A"; break;
                    case (char)(193):
                        temp = "AÙ"; break;
                    case (char)(192):
                        temp = "AØ"; break;
                    case (char)(7842):
                        temp = "AÛ"; break;
                    case (char)(195):
                        temp = "AÕ"; break;
                    case (char)(7840):
                        temp = "AÏ"; break;
                    case (char)(258):
                        temp = "AÊ"; break;
                    case (char)(7854):
                        temp = "AÉ"; break;
                    case (char)(7856):
                        temp = "AÈ"; break;
                    case (char)(7858):
                        temp = "AÚ"; break;
                    case (char)(7860):
                        temp = "AÜ"; break;
                    case (char)(7862):
                        temp = "AË"; break;
                    case (char)(194):
                        temp = "AÂ"; break;
                    case (char)(7844):
                        temp = "AÁ"; break;
                    case (char)(7846):
                        temp = "AÀ"; break;
                    case (char)(7848):
                        temp = "AÅ"; break;
                    case (char)(7850):
                        temp = "AÃ"; break;
                    case (char)(7852):
                        temp = "AÄ"; break;
                    case (char)(69):
                        temp = "E"; break;
                    case (char)(201):
                        temp = "EÙ"; break;
                    case (char)(200):
                        temp = "EØ"; break;
                    case (char)(7866):
                        temp = "EÛ"; break;
                    case (char)(7868):
                        temp = "EÕ"; break;
                    case (char)(7864):
                        temp = "EÏ"; break;
                    case (char)(202):
                        temp = "EÂ"; break;
                    case (char)(7870):
                        temp = "EÁ"; break;
                    case (char)(7872):
                        temp = "EÀ"; break;
                    case (char)(7874):
                        temp = "EÅ"; break;
                    case (char)(7876):
                        temp = "EÃ"; break;
                    case (char)(7878):
                        temp = "EÄ"; break;
                    case (char)(79):
                        temp = "O"; break;
                    case (char)(211):
                        temp = "OÙ"; break;
                    case (char)(210):
                        temp = "OØ"; break;
                    case (char)(7886):
                        temp = "OÛ"; break;
                    case (char)(213):
                        temp = "OÕ"; break;
                    case (char)(7884):
                        temp = "OÏ"; break;
                    case (char)(212):
                        temp = "OÂ"; break;
                    case (char)(7888):
                        temp = "OÁ"; break;
                    case (char)(7890):
                        temp = "OÀ"; break;
                    case (char)(7892):
                        temp = "OÅ"; break;
                    case (char)(7894):
                        temp = "OÃ"; break;
                    case (char)(7896):
                        temp = "OÄ"; break;
                    case (char)(416):
                        temp = "Ô"; break;
                    case (char)(7898):
                        temp = "ÔÙ"; break;
                    case (char)(7900):
                        temp = "ÔØ"; break;
                    case (char)(7902):
                        temp = "ÔÛ"; break;
                    case (char)(7904):
                        temp = "ÔÕ"; break;
                    case (char)(7906):
                        temp = "ÔÏ"; break;
                    case (char)(73):
                        temp = "I"; break;
                    case (char)(205):
                        temp = "Í"; break;
                    case (char)(204):
                        temp = "Ì"; break;
                    case (char)(7880):
                        temp = "Æ"; break;
                    case (char)(296):
                        temp = "Ó"; break;
                    case (char)(7882):
                        temp = "Ò"; break;
                    case (char)(85):
                        temp = "U"; break;
                    case (char)(218):
                        temp = "UÙ"; break;
                    case (char)(217):
                        temp = "UØ"; break;
                    case (char)(7910):
                        temp = "UÛ"; break;
                    case (char)(360):
                        temp = "UÕ"; break;
                    case (char)(7908):
                        temp = "UÏ"; break;
                    case (char)(431):
                        temp = "Ö"; break;
                    case (char)(7912):
                        temp = "ÖÙ"; break;
                    case (char)(7914):
                        temp = "ÖØ"; break;
                    case (char)(7916):
                        temp = "ÖÛ"; break;
                    case (char)(7918):
                        temp = "ÖÕ"; break;
                    case (char)(7920):
                        temp = "ÖÏ"; break;
                    case (char)(89):
                        temp = "Y"; break;
                    case (char)(221):
                        temp = "YÙ"; break;
                    case (char)(7922):
                        temp = "YØ"; break;
                    case (char)(7926):
                        temp = "YÛ"; break;
                    case (char)(7928):
                        temp = "YÕ"; break;
                    case (char)(7924):
                        temp = "Î"; break;
                    case (char)(272):
                        temp = "Ñ"; break;
                    default:
                        temp = c.ToStringEx();
                        break;
                }
                uniCodeToVni = uniCodeToVni + temp;
            }

            return uniCodeToVni;
        }
        /// <summary>
        /// Loại bỏ các ký tự đặc biệt khi tạo file
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <History>dvthuan created 02/02/2015</History>
        //public static string RemoveSpecialCharacters(this string str)
        public static string CheckFileNameValidation(this string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }

        private static Regex ValidEmailRegex = CreateValidEmailRegex();

        private static Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }

        public static bool EmailIsValidMulti(this string emailAddresses)
        {
            var arrEmailDemurage = emailAddresses.Split(',', ';');
            foreach (var emailDemurage in arrEmailDemurage)
            {
                var checkEmail = emailDemurage.TrimEx();
                if (!checkEmail.IsEmpty() && !checkEmail.EmailIsValid())
                {
                    return false;
                }
            }

            return true;
        }

        public static bool EmailIsValid(this string emailAddress)
        {
            bool isValid = ValidEmailRegex.IsMatch(emailAddress);

            return isValid;
        }

        public static bool CheckInputIsEirId(this string inputStr)
        {
            var firstStr = inputStr.SubstringEx(0, 1);
            var restStr = inputStr.SubstringEx(1);

            if (inputStr.Length >= 6 && "PDCSERH-".Contains(firstStr) && restStr.IsDigit())
            {
                return true;
            }

            return false;

        }

        public static bool CheckInputIsContainer(this string inputStr)
        {
            var input = inputStr.RemoveBlank();
            var first4Str = input.SubstringEx(0, 4);
            var restStr = input.SubstringEx(4);

            if (input.Length >= 11 && input.Length <= 12)
            {
                if ((first4Str.IsAlphabet() || first4Str == "----") && restStr.IsDigit())
                {
                    return true;
                }
            }

            return false;

        }

        #endregion

        public static T CheckEnumEx<T>(this object value, bool ignoreCase = true) where T : new()
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException("T must be an Enum");

            try
            {
                return (T)System.Enum.Parse(typeof(T),value.ToString(), ignoreCase);
            }
            catch
            {
                return default(T); // equivalent to (T)0
                                   //return (T)Enum.Parse(typeof(T), "Unknown"));
            }
        }

        #region EXCEPTION

        public static string GetAllErrorMessage(this Exception ex)
        {
            var strError = new StringBuilder();

            var innerEx = ex;

            while (innerEx != null)
            {
                strError.AppendLine("Message:");
                strError.Append(innerEx.Message);
                strError.AppendLine("StackTrace:");
                strError.Append(innerEx.StackTrace);
                strError.AppendLine("");
                innerEx = innerEx.InnerException;
            }

            return strError.ToStringEx();
        }


        #endregion EXCEPTION

        /// <summary>
        /// Helper methods for the lists.
        /// </summary>

        public static List<List<T>> ChunkBy<T>(this IEnumerable<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

        public static bool IsIpAddressEqual(this string ipLocal, List<string> lstIpConfig)
        {
            bool result = false;
            if (lstIpConfig.Count > 0 && !lstIpConfig[0].TrimEx().IsNullOrEmpty())
            {
                foreach (string ipConfig in lstIpConfig.Where(p => p != ""))
                {
                    if (ipConfig == ipLocal || ipConfig == "*.*.*.*" || ipConfig.IsNullOrEmpty())
                        return true;
                    var ipLocalSplit = ipLocal.Split(new char[] { '.' });
                    var ipConfigSplit = ipConfig.Split(new char[] { '.' });
                    if (ipConfigSplit.Count() != 4 || ipLocalSplit.Count() != 4)
                        continue;
                    int count = 0;
                    for (int i = 0; i < ipConfigSplit.Count(); i++)
                    {
                        if (ipConfigSplit[i] == "*" || ipConfigSplit[i] == ipLocalSplit[i])
                            count++;
                        if (count == 4)
                            result = true;
                    }
                    if (result)
                        return result;
                }
            }
            return result;
        }

        /// <summary>
        ///     Lấy danh sách các properties của 1 object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<PropertyInfo> Properties(this object obj)
        {
            System.Type type = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());

            return props.ToList();
        }
   

        /// <summary>
        ///     Xóa khoảng trắng trong object entity framework
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T RemoveWhiteSpace<T>(this T obj)
        {
            if (obj == null)
            {
                return default(T);
            }
            var properties = obj.Properties();
            foreach (var property in properties)
            { 
                if (property.PropertyType == typeof(string))
                {
                    obj.SetObjectProperty(property.Name, property.GetValue(obj, null)
                                                                 .TrimEx());
                }
            }

            return obj;
        }

        /// <summary>
        ///     Set giá trị cho 1 property dynamic
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public static void SetObjectProperty(this object obj,
                                             string propertyName,
                                             string value)
        {
            PropertyInfo propertyInfo = obj.GetType()
                                           .GetProperty(propertyName);
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(obj, value, null);
            }
        }

        public static List<T> RemoveWhiteSpaceForList<T>(this IEnumerable<T> obj)
        {
            if (obj == null)
            {
                return null;
            }

            var list = obj.ToList();

            list.ForEach(c => c.RemoveWhiteSpace());
            return list;
        }

        public static string TrimAll(this string s, char character)
        {
            if (s == null || s.IsEmpty())
                return "";

            return s.TrimEnd(character).TrimStart(character);
        }

        public static string RemoveInvalidCharFileName(this string fileName)
        {
            var invalidFileNameChar = Path.GetInvalidFileNameChars();
            foreach (var c in invalidFileNameChar)
            {
                fileName = fileName.Replace(c.ToString(), "");
            }
            return fileName;
        }

        public static double GetFileSize(this string filePath, ref string size)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = new FileInfo(filePath).Length;
            var order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            size = sizes[order];
            return len;
        }
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek starOfWeek)
        {
            int diff = dt.DayOfWeek - starOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }
        public static int GetWeekOfYear(this DateTime dateTime)
        {
            var dfi = DateTimeFormatInfo.CurrentInfo;
            if (dfi != null)
            {
                var cal = dfi.Calendar;

                return cal.GetWeekOfYear(dateTime, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            }

            return new GregorianCalendar(GregorianCalendarTypes.Localized).GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

        }
        public static bool IsEmptyDataEx(this DataSet poDataSet)
        {
            bool lbEmpty = true;
            if (poDataSet != null && poDataSet.Tables.Count > 0)
            {
                foreach (DataTable loDT in poDataSet.Tables)
                {
                    if (loDT.Rows.Count > 0)
                    {
                        lbEmpty = false;
                    }

                }
            }
            return lbEmpty;
        }
        public static int InListOf<T>(this T input, List<T> arr)
        {
            int retVal = -1;

            if (arr.Count > 0)
            {
                retVal = arr.FindIndex(i => i.Equals(input));
            }

            return retVal;
        }
        public static bool NotNullOrEmpty<T>(this IEnumerable<T> source) => source != null && source.Any();

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source) => source == null || !source.Any();


        /// <summary>
        /// if tháng =4 thì tạo thành 04
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static string GenMounth(this object month)
        {
            if (int.Parse(month.ToString()) < 10)
                return "0" + month;
            return month.ToString();
        }


        /// <summary>
        ///@@dungnv2: Chuẩn hóa lại MST theo quy tắc:
        ///Đối với các hóa đơn có mst có 13 ký tự, thêm dấu - ở giữa ký tự thứ 10 và 11.Sau đó tích điểm vào KHTT với cấu trúc có – 
        ///Ví dụ: hóa đơn trong hệ thống cảng có mst : 1100598642019 , khi tích hợp qua KHTT thì phải dịch ra là 1100598642 - 019
        /// </summary>
        /// <param name="taxCode">Mã số thuế</param>
        /// <returns></returns>
        public static string ToStandardTaxCode(this string taxCode)
        {
            if (taxCode.IsEmptyEx())
                return "";

            taxCode = taxCode.TrimEx();
            if (taxCode.Length > 10 && !taxCode.Contains("-")) //nếu chiều dài MST > 10 và không chứa dấu gạch
            {
                return $"{taxCode.Substring(0, 10)}-{taxCode.Substring(10)}";
            }

            return taxCode;
        }


        public static bool HasData<T>(this IEnumerable<T> source) => source != null && source.Any();

        //DDThanh add check and replace speccial character 
        //public static string ReplaceSpecialCharacterString(this string str)
        //{
        //    return Regex.Replace(str, @"[^0-9a-zA-Z]", "");
        //}
        /// <summary>
        /// Kiểm tra ký tự lạ có trong số seal?
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsSpecialCharacterString(this string str, string pattern = "[^a-zA-Z0-9]")
        {
            //return Regex.IsMatch(str, "[^a-zA-Z0-9\\-\\*]");
            return false;
        }

        public static string ToCombineString(this IEnumerable<string> fromList, string combinestring = " ")
        {
            var returnStr = fromList.Aggregate("", (current, s) => current.TrimEx() + (s.TrimEx() + combinestring));

            if (combinestring.Length > 0)
            {
                returnStr = returnStr.RemoveLastStr(combinestring.Length);
            }
            return returnStr;
        }

        public static IEnumerable<DataRow> AsEnumerableEx(this DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                yield return table.Rows[i];
            }
        }

        #region List Funcs
        public static void Move<T>(this List<T> list, int oldIndex, int newIndex)
        {

            // exit if possitions are equal or outside array
            if ((oldIndex == newIndex) || (0 > oldIndex) || (oldIndex >= list.Count) || (0 > newIndex) ||
                (newIndex >= list.Count)) return;
            // local variables
            var i = 0;
            T tmp = list[oldIndex];
            // move element down and shift other elements up
            if (oldIndex < newIndex)
            {
                for (i = oldIndex; i < newIndex; i++)
                {
                    list[i] = list[i + 1];
                }
            }
            // move element up and shift other elements down
            else
            {
                for (i = oldIndex; i > newIndex; i--)
                {
                    list[i] = list[i - 1];
                }
            }
            // put element from position 1 to destination
            list[newIndex] = tmp;
        }

        public static void MoveUp<T>(this List<T> list, T objectInList)
        {
            int oldIndex, newIndex;
            oldIndex = list.IndexOf(objectInList);
            newIndex = oldIndex - 1;
            list.Move(oldIndex, newIndex);
        }

        public static void MoveDown<T>(this List<T> list, T objectInList)
        {
            int oldIndex, newIndex;
            oldIndex = list.IndexOf(objectInList);
            newIndex = oldIndex + 1;
            list.Move(oldIndex, newIndex);
        }

        public static void MoveTo<T>(this List<T> list, T objectFromInList, T objectToInList)
        {
            int oldIndex, newIndex;
            oldIndex = list.IndexOf(objectFromInList);
            newIndex = list.IndexOf(objectToInList);
            list.Move(oldIndex, newIndex);
        }

        #endregion

        /// <summary>
        /// Convert color to H
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string ToHex(this Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public static bool IsContentSingleQuote(this string str)
        {
            return str?.Count(c => c == '\'') > 0;
        }

        public static string StandardizedVesLocation(this string obj)
        {
            var length = obj.Length;

            if (length < 5)
                throw new Exception($"Vị trí trên tàu không hợp lệ ({obj}-Length:{length})");
            if (length == 6)
            {
                return obj;
            }
            else if (length == 5)
            {
                obj = $"0{obj}";
            }
            else if (length > 6)
                obj = obj.Substring(length - 6, 6);
            return obj;
        }

        public static bool IsShipmentGetOut(this string obj)
        {
            if (string.IsNullOrEmpty(obj))
                return false;
            if (Strings.Left(obj, 1).ToString() != "3")//Cont Tạm tái xuất có tờ khai hải quan đầu 3
                return false;
            return true;
        }

        /// <summary>
        ///     Will get the string value for a given enums value, this will
        ///     only work if you assign the StringValue attribute to
        ///     the items in your enum.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
   

        /// <summary>
        /// Kiem tra khong phai la gia tri null?
        /// Qui dinh DateTime = {31/12/1900} la gia tri null, empty
        /// </summary>
        public static bool IsNotNull(this DateTime poCheck)
        {
            return poCheck.Year > 1900;
        }

        /// <summary>
        /// Loại bỏ thông tin gio phut giay trong DataTime
        /// </summary>
        /// <param name="poDateTime"></param>
        /// <returns></returns>
        /// <history>
        /// Create by thhung, 25/05/2011
        /// </history>
        public static DateTime GetDate(this DateTime poDateTime)
        {
            return new DateTime(poDateTime.Year, poDateTime.Month, poDateTime.Day);
        }

        public static DateTime ToBeginDate(this DateTime poDateTime)
        {
            return new DateTime(poDateTime.Year, poDateTime.Month, poDateTime.Day, 0, 0, 0);
        }
        public static DateTime ToEndDate(this DateTime poDateTime)
        {
            return new DateTime(poDateTime.Year, poDateTime.Month, poDateTime.Day, 23, 59, 59);
        }
      
        public static string RandomString(int size)
        {
            Guid g = Guid.NewGuid();
            //string GuidString = Convert.ToBase64String(g.ToByteArray());
            string guidString = g.ToString().ToUpper();
            guidString = guidString.Replace("-", "");
            guidString = guidString.Replace("+", "");

            if (size <= guidString.Length)
            {
                return guidString.Substring(0, size).ToUpper();
            }

            return guidString;
        }
        public static string ToReplace(this string stringReplace) => stringReplace.Replace("\r\n", "").Replace("\n", "").Replace("\t", "").TrimEx().DeleteSingleQuote();
    }

}