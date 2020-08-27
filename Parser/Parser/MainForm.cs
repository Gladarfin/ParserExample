using Parser.Core;
using Parser.Site;
using Parser.Func;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Parser
{
    public partial class MainForm : Form
    {
        readonly ParserWorker<SitePage> parser;
        public MainForm()
        {
            InitializeComponent();
            parser = new ParserWorker<SitePage>(new SiteParser());
            parser.OnComplete += Parser_OnComplete;
            parser.OnNewData += Parser_OnNewData;
            EndPage.Minimum = 1;
            EndPage.Maximum = 1000;            
        }

        private void Parser_OnNewData(object arg1, SitePage arg2)
        {
            for (int i=0; i<10;i++)
            {
                var p = arg2.Posts[i];
                ParserDataList.AppendText(p.Date+"\t"+ p.Title+"\n"+p.Description+"\n"+p.DownloadLink+"\n\n");
            }
        }

        private void Parser_OnComplete(object obj)
        {
            MessageBox.Show("Parsing is done");
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            parser.ParserSettings = new SiteSettings((int)EndPage.Value);
            parser.StartParser();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            parser.AbortParser();
        }

        /// <summary>
        /// Определяем, закончил ли пользователь печатать, если задержка между нажатиями клавиш 2 секунды, то запускаем поиск
        /// </summary>
        /// <param name="str">Передаем уже напечатанную строку в метод</param>
        /// <returns></returns>
        public static async Task<bool> GetIdle(string str)
        {
            var tmp = str;
            await Task.Delay(2000);
            return tmp == str;
        }

        /// <summary>
        /// Убираем заливку при новом поиске
        /// </summary>
        private void ClearTextBox()
        {
            ParserDataList.SelectionStart = 0;
            ParserDataList.SelectAll();
            ParserDataList.SelectionBackColor = Color.White;
        }

        /// <summary>
        /// Изменение текста в строке поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Search_TextChanged(object sender, EventArgs e)
        {
            var search = new SearchInfo();
            if (await GetIdle(Search.Text))
            {
                ClearTextBox();
                search.SearchInTextBox(Search.Text, ParserDataList);
            }

        }
    }
}
