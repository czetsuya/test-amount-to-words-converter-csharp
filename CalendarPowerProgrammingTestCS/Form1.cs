using System;
using System.Text;
using System.Windows.Forms;

namespace CalendarPowerProgrammingTestCS
{
    public partial class Form1 : Form
    {
        //ones
        private readonly string[] _ones = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        //tens
        private readonly string[] _tens = new string[] { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        //thousand, million, billion
        private readonly string[] _billions = new string[] { "", "thousand", "million", "billion" };

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnConvertClick(object sender, EventArgs e)
        {
            if (txtInput.Text.Length > 0 && txtInput.Text.Contains("."))
            {
                var words = txtInput.Text.Split('.');
                var dollars = AddDollarsOrCentsWord(Int2Words(words[0]), true);
                var cents = AddDollarsOrCentsWord(Int2Words(words[1]), false);

                //removed the unnecessary comma if exact value
                dollars = dollars.Replace(", D", " D");

                txtMemo.Text = String.Format("{0} AND {1}", dollars, cents);
            }
            else
            {
                MessageBox.Show("Input must only contain number and dot", "Invalid input");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private String Int2Words(string word)
        {
            var sb = new StringBuilder();
            if (word.Length == 1)
            {
                return _ones[Convert.ToInt16(word)];
            }

            //group the input
            word = PadSpace(word);

            var groups = word.Split(' ');
            var length = groups.Length;
            for (var i = 0; i < length; i++)
            {
                sb.Append(ThreeDigitToWord(length - 1 - i, groups[i]));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Convert a 3 digit number to string.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string ThreeDigitToWord(int group, string value)
        {
            var sb = new StringBuilder();
            var threeDigitStringValue = new StringBuilder();
            int word = Convert.ToInt16(value);

            var onesValue = 0;
            if (value.Length == 3)
            {
                var hundredValue = word / 100;
                var tensValue = (word % 100) / 10;
                onesValue = word % 100 % 10;
                if (hundredValue != 0)
                    threeDigitStringValue.Append(_ones[hundredValue] + " hundred ");
                if (tensValue != 0)
                    threeDigitStringValue.Append(_tens[tensValue] + " ");
            }
            else if (value.Length == 2)
            {
                var tensValue = (word % 100) / 10;
                onesValue = word % 100 % 10;
                if (tensValue != 0)
                    threeDigitStringValue.Append(_tens[tensValue] + " ");
            }
            else if (value.Length == 1)
            {
                onesValue = Convert.ToInt16(value);
            }

            if (onesValue != 0)
                threeDigitStringValue.Append(_ones[onesValue]);

            if (group == 0)
            { //ones
                if(threeDigitStringValue.Length != 0)
                    sb.Append(threeDigitStringValue);
            }
            else
            { //tens, thousand, million, billion
                if (threeDigitStringValue.Length != 0)
                    sb.Append(threeDigitStringValue + " " + _billions[group] + ", ");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Add space every 3 digits.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private static string PadSpace(string word)
        {
            if (word.Length <= 3)
                return word;
            var paddedWord = "";
            var length = word.Length;
            for (var i = 0; i < length; i++)
            {
                if (i != 0)
                {
                    if (i % 3 == 0)
                        paddedWord = ' ' + paddedWord;
                }

                paddedWord = word[length - 1 - i] + paddedWord;
            }
            return paddedWord;
        }

        /// <summary>
        /// Add dollar/s or cent/s prefix.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="isDollar"></param>
        /// <returns></returns>
        private static string AddDollarsOrCentsWord(string word, bool isDollar)
        {
            var newWord = "";
            word = word.Trim();
            if (isDollar)
            {
                if (word.Equals("one"))
                {
                    newWord = word + " DOLLAR";
                }
                else
                {
                    newWord = word + " DOLLARS";
                }
            }
            else
            {
                if (word.Equals("one"))
                {
                    newWord = word + " CENT";
                }
                else
                {
                    newWord = word + " CENTS";
                }
            }
            return newWord;
        }
    }
}
