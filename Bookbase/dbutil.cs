using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.Linq.Mapping;


namespace ReadCrossref
{
    class dbutil
    {
        /// <span class="code-SummaryComment"><summary></span>
        /// Gets the length limit for a given field on a LINQ object ... or zero if not known
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><remarks></span>
        /// You can use the results from this method to dynamically 
        /// set the allowed length of an INPUT on your web page to
        /// exactly the same length as the length of the database column.  
        /// Change the database and the UI changes just by
        /// updating your DBML and recompiling.
        /// <span class="code-SummaryComment"></remarks></span>
        public static int GetLengthLimit(object obj, string field)
        {
            int dblenint = 0;   // default value = we can't determine the length

            Type type = obj.GetType();
            PropertyInfo prop = type.GetProperty(field);
            // Find the Linq 'Column' attribute
            // e.g. [Column(Storage="_FileName", DbType="NChar(256) NOT NULL", CanBeNull=false)]
            object[] info = prop.GetCustomAttributes(typeof(ColumnAttribute), true);
            // Assume there is just one
            if (info.Length == 1)
            {
                ColumnAttribute ca = (ColumnAttribute)info[0];
                string dbtype = ca.DbType;

                if (dbtype.StartsWith("NChar") || dbtype.StartsWith("NVarChar") || dbtype.StartsWith("Char") || dbtype.StartsWith("VarChar"))
                {
                    int index1 = dbtype.IndexOf("(");
                    int index2 = dbtype.IndexOf(")");
                    string dblen = dbtype.Substring(index1 + 1, index2 - index1 - 1);
                    int.TryParse(dblen, out dblenint);
                }
            }
            return dblenint;
        }

        /// <span class="code-SummaryComment"><summary></span>
        /// If you don't care about truncating data that you are setting on a LINQ object, 
        /// use something like this ...
        /// <span class="code-SummaryComment"></summary></span>
        public static void SetAutoTruncate(object obj, string field, string value)
        {
            int len = GetLengthLimit(obj, field);
            if (len == 0)
                throw new ApplicationException("Field '" + field +
          "'does not have length metadata");

            Type type = obj.GetType();
            PropertyInfo prop = type.GetProperty(field);
            if (value.Length > len)
            {
                prop.SetValue(obj, value.Substring(0, len), null);
            }
            else
                prop.SetValue(obj, value, null);
        }

        public static string RemoveDiacritics(string s) //from https://stackoverflow.com/questions/249087/how-do-i-remove-diacritics-accents-from-a-string-in-net
        {
            string normalizedString = null;
            StringBuilder stringBuilder = new StringBuilder();
            normalizedString = s.Normalize(NormalizationForm.FormD);
            int i = 0;
            char c = '\0';

            for (i = 0; i <= normalizedString.Length - 1; i++)
            {
                c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().ToLower();
        }

        public static int LevenshteinDistance(string src, string dest)
        {
            //From http://www.codeproject.com/Articles/36869/Fuzzy-Search
            //License CPOL (http://www.codeproject.com/info/cpol10.aspx)

            int[,] d = new int[src.Length + 1, dest.Length + 1];
            int i, j, cost;
            char[] str1 = src.ToCharArray();
            char[] str2 = dest.ToCharArray();

            for (i = 0; i <= str1.Length; i++)
            {
                d[i, 0] = i;
            }
            for (j = 0; j <= str2.Length; j++)
            {
                d[0, j] = j;
            }
            for (i = 1; i <= str1.Length; i++)
            {
                for (j = 1; j <= str2.Length; j++)
                {

                    if (str1[i - 1] == str2[j - 1])
                        cost = 0;
                    else
                        cost = 1;

                    d[i, j] =
                        Math.Min(
                            d[i - 1, j] + 1,              // Deletion
                            Math.Min(
                                d[i, j - 1] + 1,          // Insertion
                                d[i - 1, j - 1] + cost)); // Substitution

                    if ((i > 1) && (j > 1) && (str1[i - 1] ==
                        str2[j - 2]) && (str1[i - 2] == str2[j - 1]))
                    {
                        d[i, j] = Math.Min(d[i, j], d[i - 2, j - 2] + cost);
                    }
                }
            }

            return d[str1.Length, str2.Length];
        }

        public static int CountOccurenceOfValue(List<int> list, int valueToFind)
        //From https://www.codeproject.com/Tips/69400/Count-number-of-occurences-of-a-value-in-a-List-us
        {
            return ((from temp in list where temp.Equals(valueToFind) select temp).Count());
        }

        public static int CountOccurenceOfString(List<string> list, string valueToFind)
        //From https://www.codeproject.com/Tips/69400/Count-number-of-occurences-of-a-value-in-a-List-us
        {
            return ((from temp in list where temp.Equals(valueToFind) select temp).Count());
        }

        public static string bkbdate(DateTime? dt)
        {
            if (dt == null)
                return "???";
            else
            {
                return ((DateTime)dt).ToString("yyMMdd");
            }
        }

        public static string bkbyear(int? year)
        {
            if (year == null)
                return "-1";
            else
                return ((int)year % 100).ToString();
        }

        public static string bkbprice(int? price)
        {
            if (price == null)
                return "???";
            else
                return ((int)price).ToString();
        }

    }
}
