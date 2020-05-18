using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace HtmlPageLoad
{
    public partial class Form1 : Form
    {
        List<string> strList = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 1; i < 130; i++)
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load("https://tamilrockers.ws/index.php/forum/114-tamil-dubbed-movies-multi-lang-bd-hd-tc-cam/page-" + i.ToString());
                extractLink(document);
            }
            File.WriteAllLines(@"C:\Users\Subash\Downloads\Movies.txt", strList);
        }

        

        private void extractLink(HtmlDocument source)
        {
            HtmlNodeCollection anchorList = source.DocumentNode.SelectNodes("//span");
            foreach (var item in anchorList)
            {
                string strText = ((HtmlNode)item).InnerText;
                if (((HtmlNode)item).Attributes.Contains("itemprop"))
                {
                    string strattr = ((HtmlNode)item).Attributes["itemprop"].Value;
                    if (!string.IsNullOrEmpty(strText))
                    {
                        if (!strList.Contains(strText.Trim()) && strattr == "name")
                            strList.Add(strText);
                    }
                }
            }
           
        }
    }
}
