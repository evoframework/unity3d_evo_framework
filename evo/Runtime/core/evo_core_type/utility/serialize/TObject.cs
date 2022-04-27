using System.Collections;
using System.IO;
namespace Evo
{
    public class TObject
    {
        public IEObject parent;

        public bool isUpdate;

        public int size;

        public MemoryStream memoryStream;

        public string name;

        /*
        public virtual byte[] ToBinary(){
            return null;
        }

        public virtual void FromBinary(){

        }*/
    }
}