using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Använder Threading att skapa nya tråder
using System.Threading;
//Använder IO att använder stream writer och file.readalltext
using System.IO;

namespace ConcurrentAsng3
{
    //Klass mainform
    public partial class FrmMain : Form
    {
        public FrmMain()
        {

            InitializeComponent();
        }
        //Skapa object av Writer, Reader och Modify
        Writer writer;
        Reader reader;
        Modifier modify;
        //Skapa tråd för att instansiar med writer, reader och modify
        Thread wr;
        Thread rd;
        Thread md;
        //Skapa object av Circlebuffer
        CircleBuffer c;
        //Variabel int 
        int x;

        /// <summary>
        /// När man trycker på Find knappen så skapas ny object av circle buffer med parameter, nya object av reader writer och modify
        /// tidigare skapad tråd blir fyllt med metoder från klasserna och tråderna startas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            CircleBuffer circleBuf = new CircleBuffer(10, rchTextboxSource, txtFind.Text.Trim(), txtReplacewith.Text);
            writer = new Writer(circleBuf);
            reader = new Reader(circleBuf);
            modify = new Modifier(circleBuf);

            wr = new Thread(new ThreadStart(writer.startwrtiting));
            rd = new Thread(new ThreadStart(reader.startReading));
            md = new Thread(new ThreadStart(modify.modifyArray));

            wr.Start();
            rd.Start();
            md.Start();

            c = circleBuf;
           
            //While loop som skapa en mellan rum så alla tråderna hinner vara färdig innan output richtextbox börja fylls av modified list från circlebuffer
           while(c.ModifiedList.Count != c.MAX)  
           {
               x += 1;
           }
            //En for loop som fyller rchtextboxDestionation med modified listens strängar
           for (int i = 0; i < c.ModifiedList.Count; i++)
           {
               rchTextBoxDestination.Text = rchTextBoxDestination.Text + c.ModifiedList[i] + " ";
           }
            //Om man söker efter en ord och vill replace med en annan ord så highlight orden som blir replaced.
            if(txtReplacewith.Text != string.Empty && txtFind.Text.Trim() != string.Empty)
            {
                SearchAndHighlight(txtReplacewith.Text.Trim(), rchTextBoxDestination);
            }

            SearchAndHighlight(txtFind.Text.Trim(), rchTextboxSource);
            //Label nummer blir lika med antalet replacements gjort
           lblNumber.Text = c.NbrReplacements.ToString();

            //Visa användaren output taben för att visa resiltat
           tabControl1.SelectedIndex = 1;
        }

       /// <summary>
       /// Metod för att highlightar ord i richtextbox
       /// </summary>
       /// <param name="searchText">String som man vill highlight</param>
        private void SearchAndHighlight(string searchText, RichTextBox rch)
        {
            if (searchText.Length > 0)
            {
                int index = -1;
                int searchStart = 0;
                while ((index = rch.Find(searchText, searchStart, RichTextBoxFinds.WholeWord)) > -1)
                {
                    rch.Select(index, searchText.Length);
                    rch.SelectionBackColor = Color.Yellow;
                    searchStart = index + searchText.Length;
                    if(rch.TextLength <= searchStart)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Metod när man trycker på Clear All, alla fält blir clear och man återvönder till source tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            rchTextBoxDestination.Clear();
            rchTextboxSource.Clear();
            lblNumber.ResetText();
            txtFind.Clear();
            txtReplacewith.Clear();
        }

        /// <summary>
        /// Metod att ladda in en fil, man ladda in bara text filer. Filens address sparas i string och sen körs File.ReadallText metoden som läsa inn
        /// texten från file och sätts in i source richtextbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Open Text File";
            openFileDialog1.Filter = "TXT files|*.txt";
            openFileDialog1.InitialDirectory = @"C:\";
            DialogResult Result = openFileDialog1.ShowDialog();
            string file = openFileDialog1.FileName;

            rchTextboxSource.Text = File.ReadAllText(file);
        }

        /// <summary>
        /// Metod när man trycker på create. Skapa ny fil blir .txt filtyp. Ny streamwrite och skriva till filen det 
        /// som är i richtextboxen. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "TXT files|*.txt";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string filename = savefile.FileName;
                StreamWriter writer = new StreamWriter(filename, false);
                
                writer.Write(rchTextBoxDestination.Text);
                writer.Flush();
            }
        }
    

    }
}
