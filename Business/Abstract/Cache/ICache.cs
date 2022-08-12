using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Cache
{
    public interface ICache
    {
        //DC= Distributed Cache IMC =In Memory Cache
        void DCSetString(string key, string value);
        void DCSetList(string key); 
        string DCGetValue(string key);

        void IMCSetString(string key, string value);
        void IMCSetObject(string key, object value);
        T IMCGetValue<T>(string key);
    }
   
   
}
