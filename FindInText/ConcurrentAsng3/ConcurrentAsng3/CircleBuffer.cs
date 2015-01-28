using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ConcurrentAsng3
{
    //Klass Circle buffer som används av Writer, Reader Modifier och FrmMain
    public class CircleBuffer
    {

        //Enum som har de tre läge status kan vara i Status array
        private enum Status
        {
            Empty,
            Checked,
            New,
        }
        //Variabel strArray som kommer håller temporary strings som fylls av write, kollas av modify, och läses av read 
        private string[] strArr;
        //Variable Max som tar hand om antalet strings det finns från richtextbox
        private int max;
        //Variabel writepos som är modulo av sig själv och längden av strArr. Bestäms var i strArry nya strings sätts in, modifies och reads
        private int writePos;
        private int modifyPos;
        private int readPos;
        //Variabel Status som är array av enum status
        private Status[] status;
        //Variabel rtxBox som håller data från richtextbox i GUI
        private RichTextBox rtxBox;
        //Variabel findstring som är strängen vi vill leta efter
        private string findstring;
        //Variabel replacestring som är strängen vi vill ersätta findstring med
        private string replacestring;
        //Variabel för antalet replacements vi gör i buffern
        private int nbrReplacements;
        //Variabel List som är en lista av strings, fylls av strings från temparray
        private List<string> tempList;
        //Variabel lista som är lista av strings, kommer innehåller output fråån buffer
        private List<string> modifiedlist;
        //Variabel array som håller strings från rtxBox
        private string[] tempArray;

        private delegate void Marker();

        //Variabel semephor som kontrollerar när write, read och modify metoder kan köras
        public static Semaphore threadPool;

        /// <summary>
        /// Konstuktör för CircleBuffer klassen, skapa instans av alla variabler och arrays och listor. instansiera semephoren och kalla metod Prepare the string
        /// array som gör en array av alla strings i rich text box. 
        /// </summary>
        /// <param name="elements">Längden på buffer arrayn</param>
        /// <param name="rt">Richtextboxen innehål</param>
        /// <param name="find">String som ska hittas</param>
        /// <param name="replace">Stringen som ska ersätta find string</param>
        public CircleBuffer(int elements, RichTextBox rt, string find, string replace)
        {
            nbrReplacements = 0;
            modifiedlist = new List<string>();
            threadPool = new Semaphore(0, 3);
            status = new Status[elements];
            rtxBox = rt;
            tempArray = new string[elements];
            strArr = new string[elements];
            tempList = new List<string>();
            PreparethestringArray();
            writePos = 0;
            modifyPos = 0;
            readPos = 0;
            replacestring = replace;
            findstring = find;
            threadPool.Release();
            //For loop som gör alla position i status array till empty 
            for (int i = 0; i < status.Length; i++)
            {
                status[i] = Status.Empty;
            }
        }

        /// <summary>
        /// Metod som läga en string från richtextbox texten i position i i temparray. När den är klar så blir max den antalet av strings som finns
        /// </summary>
        private void PreparethestringArray()
        {

            tempArray = rtxBox.Text.Split(' ');

            for (int i = 0; i < tempArray.Length; i++)
            {
                tempList.Add(tempArray[i]);
            }
            max = tempList.Count;
        }

        /// <summary>
        /// Metod som gör writepos till writepos module strArays längd. Värje gång den kallas så blir writepos +1 till 9 sen börja om på 0 och loopa så
        /// </summary>
        public void AdvanceModulWrite()
        {
            writePos = (writePos + 1) % strArr.Length;
        }
        public void AdvanceModuleModify()
        {
            modifyPos = (modifyPos + 1) % strArr.Length;
        }
        public void AdvanceModuleRead()
        {
            readPos = (readPos + 1) % strArr.Length;
        }

        /// <summary>
        /// Metod att skriva, om write postionen är emtpy så fylls den med senast string i templist, advancemodulewrite and gå vidare, om det fanns värde annat från empty så returneras false
        /// uppdatera status till new
        /// </summary>
        public bool write()
        {
            threadPool.WaitOne();
            if (status[writePos] == Status.Empty)
            {

                strArr[writePos] = tempList[0];
                status[writePos] = Status.New;
                AdvanceModulWrite();

                tempList.RemoveAt(0);
                threadPool.Release();
                return true;

            }
            threadPool.Release();
            return false;
        }



        /// <summary>
        /// Metod modify som ska gå in i strAray och kolla all strings efter findstring och gör alla till checked i status array. om modify positionen är inte new så returneras false
        /// uppdatera satus till checked
        /// </summary>
        public bool Modify()
        {

            threadPool.WaitOne();
            if (status[modifyPos] == Status.New)
            {
                if (findstring == strArr[modifyPos])
                {
                    if (replacestring != "")
                    {
                        strArr[modifyPos] = replacestring;
                        nbrReplacements += 1;
                    }
                }
                status[modifyPos] = Status.Checked;
                AdvanceModuleModify();
                threadPool.Release();
                return true;
            }

            threadPool.Release();
            return false;

        }

        /// <summary>
        /// Metod som read ifrån strArray. Om readpostionen är checked så returnera true efter att lägga till modified list, annars return flase
        /// </summary>
        public bool Read()
        {
            threadPool.WaitOne();
            if (status[readPos] == Status.Checked)
            {
                modifiedlist.Add(strArr[readPos]);
                status[readPos] = Status.Empty;
                AdvanceModuleRead();
                threadPool.Release();
                return true;
            }

            threadPool.Release();
            return false;
            


        }

        /// <summary>
        /// Property som gör att andra klasser kan hämta modified list
        /// </summary>
        public List<string> ModifiedList
        {
            get { return modifiedlist; }
        }
        /// <summary>
        /// Property som gör att andra klasser kan hämta nbrReplacements
        /// </summary>
        public int NbrReplacements
        {
            get { return nbrReplacements; }
        }
        /// <summary>
        /// Property for Max
        /// </summary>
        public int MAX
        {
            get { return max; }
        }
    }
}

