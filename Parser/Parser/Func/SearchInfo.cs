using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Parser.Func
{
    class SearchInfo
    {
        public void SearchInTextBox(string searchString, RichTextBox textBox)
        {
            var words = searchString.Split(' ');

            foreach (var word in words)
            {
                int startIndex = 0;

                while (startIndex < textBox.TextLength)
                {
                    int wordStartIndex = textBox.Find(word, startIndex, RichTextBoxFinds.None);
                    if (wordStartIndex == -1)
                        return;
                    textBox.SelectionStart = wordStartIndex;
                    textBox.SelectionLength = word.Length;
                    textBox.SelectionBackColor = Color.DarkOrange;

                    startIndex = wordStartIndex + word.Length;
                }
            }

        }
    }
}
