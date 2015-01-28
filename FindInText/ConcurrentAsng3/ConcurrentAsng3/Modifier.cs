using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentAsng3
{
    class Modifier
    {
        //Object av circlebuffer
        CircleBuffer cBuff;
        /// <summary>
        /// Initializes a new instance of the <see cref="Modifier"/> class.
        /// </summary>
        /// <param name="c">The c.</param>
        public Modifier(CircleBuffer c)
        {
            cBuff = c;
        }
        /// <summary>
        /// Metod som kalla metod modify från circlebuffer klassen, en for loop för värje element i MAX
        /// </summary>
        public void modifyArray()
        {
            for (int i = 0; i < cBuff.MAX;)
            {
                cBuff.Modify();
                if(cBuff.Modify())
                {
                    i++;
                }
               
            }

        }
    }
}
