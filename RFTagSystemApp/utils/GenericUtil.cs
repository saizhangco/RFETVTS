using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFTagSystemApp.utils
{
    class GenericUtil
    {
        public static string Generic_ConvertToGuid(int id)
        {
            int _id = id;
            int tmp = 0;
            string retValue = "";
            for( int i=0; i<4; i++ )
            {
                tmp = _id % 16;
                retValue = "" + ((char)(tmp > 9 ? tmp - 10 + 'A' : tmp + '0')).ToString() + retValue;
                tmp /= 16;
            }
            return retValue;
        }
    }
}
