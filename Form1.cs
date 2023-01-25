using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;

namespace IPv6ShortenderExtender
{
    public partial class Form1 : Form
    {
        // selecta razmake
        //private static readonly Regex sWhitespace = new Regex(@"\s+");
        // stari regex koji radi ako je manje od 4 nule u segmentu
        //private static readonly Regex sLeadingZeros = new Regex(@"((?<=(^|:))0{1,3})(?!($|:))");

        // selecta prve 3 nule svakog segmenta
        private static readonly Regex sLeadingZeros = new Regex(@"((?<=(^|:))0{1,3})");
        // selecta same nule
        private static readonly Regex sSoloZeros = new Regex(@"(:{1,2})?(?<=(^|:))0(:{1,2})?");

        // selecta ::
        private static readonly Regex sDoubleColon = new Regex(@"::");
        // selecta sve nizove dvotocki (:) koji su duzi od ::
        private static readonly Regex sMultipleColon = new Regex(@":{3,}");

        private bool shortenMode = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            bool isIPv6AddressValid = IsIPv6AddressValid(InputTextBox.Text, out string errorMessage);

            if (!isIPv6AddressValid)
            {
                ErrorMessageLabel.Text = errorMessage;
                ErrorMessageLabel.Visible = true;
                OutputTextBox.Text = "";
                return;
            }

            ErrorMessageLabel.Visible = false;

            if (shortenMode) OutputTextBox.Text = ShortenIPv6(InputTextBox.Text);
            else OutputTextBox.Text = ExpandIPv6(InputTextBox.Text);
        }

        private string ShortenIPv6(string IPv6Address)
        {
            IPv6Address = ExpandIPv6(IPv6Address);

            IPv6Address = sLeadingZeros.Replace(IPv6Address, "");
            IPv6Address = sSoloZeros.Replace(IPv6Address, "s");

            string longestSequence = FindLongestSequence(IPv6Address, 's');

            if (longestSequence != "")
            {
                Regex sLongestSequence = new Regex(longestSequence);
                IPv6Address = sLongestSequence.Replace(IPv6Address, "::", 1);
            }

            IPv6Address = AddZerosBack(IPv6Address, 's');

            return IPv6Address.ToLower();
        }

        private string FindLongestSequence(string input, char c)
        {
            int longestSequence = 0;
            int currentSequence = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == c)
                {
                    currentSequence++;
                    longestSequence = Math.Max(longestSequence, currentSequence);
                }
                else currentSequence = 0;
            }

            return new string(c, longestSequence);
        }

        private string AddZerosBack(string input, char c)
        {
            string result = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == c && (i > 0 ? result[result.Length - 1] != ':' : true)) result += ":0:";
                else if (input[i] == c) result += "0:";
                else result += input[i];
            }

            if (input.Substring(0, 2) == "::") return "::" + result.Trim(':');

            if (input.Substring(input.Length - 2, 2) == "::" ) return result.Trim(':') + "::";

            return result.Trim(':');
        }

        private string ExpandIPv6(string IPv6Address)
        {
            string[] hexGroups = IPv6Address.Split(':');
            string[] expandedHexGroups = new string[8];

            int i = 0;
            // za slucajeve di je :: na pocetku/kraju ili je samo ::
            int excessEmptySegments = hexGroups.Where(s => s == "").Count() - 1;

            for (i = 0; i < excessEmptySegments; i++)
            {
                int excessSegmentIndex = Array.IndexOf(hexGroups, "");
                hexGroups = hexGroups.Where((s, idx) => idx != excessSegmentIndex).ToArray();
            }

            int missingSegmentIndex = Array.IndexOf(hexGroups, "");

            if (missingSegmentIndex != -1)
            {
                foreach (string s in hexGroups) Console.WriteLine(s);

                int missingSegmentsAmount = 9 - hexGroups.Length;

                string[] missingSegments = Enumerable.Repeat("0000", missingSegmentsAmount).ToArray();

                string[] firstArray = hexGroups.Take(missingSegmentIndex).ToArray();
                string[] secondArray = hexGroups.Skip(missingSegmentIndex + 1).ToArray();

                hexGroups = firstArray.Concat(missingSegments).Concat(secondArray).ToArray();
            }

            i = 0;
            foreach (string s in hexGroups)
            {
                if (s.Length > 0 && s.Length < 4) expandedHexGroups[i] = new string('0', 4 - s.Length) + s;
                else expandedHexGroups[i] = hexGroups[i];

                i++;
            }

            return string.Join(":", expandedHexGroups);
        }

        private void DeleteInputButton_Click(object sender, EventArgs e)
        {
            InputTextBox.Text = "";
            OutputTextBox.Text = "";
        }

        private void CopyOutputButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(OutputTextBox.Text);
        }

        private bool IsIPv6AddressValid(string IPv6Address, out string errorMessage)
        {
            errorMessage = null;

            int IPv6AddressLength = IPv6Address.Length;

            char[] allowedChars =
                { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', ':' };

            IPv6Address = IPv6Address.ToLower();
            string[] hexGroups = IPv6Address.Split(':');

            MatchCollection doubleColonMatches = sDoubleColon.Matches(IPv6Address);

            bool doubleColonAtEnds = (IPv6Address[0] == ':' && IPv6Address[1] == ':') ||
                (IPv6Address[IPv6AddressLength - 1] == ':' && IPv6Address[IPv6AddressLength - 2] == ':');

            if (!IPv6Address.All(c => allowedChars.Contains(c)))
            {
                errorMessage = "IPv6 adresa ne sadrži pravilne heksadekadske znamenke!";
                return false;
            }

            foreach (string s in hexGroups)
            {
                if (s.Length > 4)
                {
                    errorMessage = "Neki segmenti su pre dugi!";
                    return false;
                }
            }

            if ((hexGroups.Length > 8 && !doubleColonAtEnds) || (hexGroups.Length > 9 && doubleColonAtEnds))
            {
                errorMessage = "IPv6 adresa ima previše segmenata!";
                return false;
            }

            if (doubleColonMatches.Count == 0 && hexGroups.Length < 8)
            {
                errorMessage = "IPv6 adresa ima premalo segmenata!";
                return false;
            }
            
            if ((IPv6Address[0] == ':' && IPv6Address[1] != ':') ||
                (IPv6Address[IPv6AddressLength - 1] == ':' && IPv6Address[IPv6AddressLength - 2] != ':'))
            {
                errorMessage = "IPv6 adresa ne može započinjati ili završavati sa \":\"!";
                return false;
            }

            if (sMultipleColon.IsMatch(IPv6Address))
            {
                errorMessage = "Ne može biti više od 2 ':' za redom!";
                return false;
            }

            if (doubleColonMatches.Count > 1)
            {
                errorMessage = "Može biti samo 1 \"::\"!";
                return false;
            }

            return true;
        }

        private void SwitchModeButton_Click(object sender, EventArgs e)
        {
            // duga <=> kratka
            shortenMode = !shortenMode;

            if (shortenMode)
            {
                SwitchModeLabelLeft.Text = "Duga";
                SwitchModeLabelRight.Text = "Kratka";
                OutputLabel.Text = "Skraćena IPv6 adresa:";
                ConvertButton.Text = "SKRATI";
                return;
            }

            SwitchModeLabelLeft.Text = "Kratka";
            SwitchModeLabelRight.Text = "Duga";
            OutputLabel.Text = "Produžena IPv6 adresa:";
            ConvertButton.Text = "PRODUŽI";
            return;
        }
    }
}
