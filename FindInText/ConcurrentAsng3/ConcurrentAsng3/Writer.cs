using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcurrentAsng3
{
    //Klass som används av FrmMain
    class Writer
    {
        //Object av circlebuffer
        CircleBuffer cbuffer;
        /// <summary>
        /// Konstruktör som gör cbuffer till this.cbuffer, skapa writer klassen
        /// </summary>
        /// <param name="cbuffer">The cbuffer.</param>
        public Writer(CircleBuffer cbuffer)
        {
            this.cbuffer = cbuffer;
        }

        /// <summary>
        /// Metod som kalla metod write från circle buffer klass, en for loop för värje element i MAX
        /// </summary>
        public void startwrtiting()
        {
            for (int i = 0; i < cbuffer.MAX;)
            {     
                    if(cbuffer.write())
                    {
                        i++;
                    }            
            }
        }
    }
}
