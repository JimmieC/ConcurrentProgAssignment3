using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentAsng3
{
    class Reader
    {
        //Object av circlebuffer
        CircleBuffer cbuffer;
        /// <summary>
        /// Konstuktör för reader som gör parameter c till cbuffer.
        /// </summary>
        /// <param name="c">The c.</param>
        public Reader(CircleBuffer c)
        {
            cbuffer = c;
        }

        /// <summary>
        /// Metod som kaller metod Read från circlebuffer, en for loop för värje element i MAX
        /// </summary>
        public void startReading()
        {
            for (int i = 0; i < cbuffer.MAX;)
            {
                if(cbuffer.Read())
                {
                    i++;
                }
            }
            
        }
    }
}
