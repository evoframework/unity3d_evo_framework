
using System.Collections;
using System.IO;

namespace Evo
{
    public class TString : TObject
    {
        protected string value;

        public TString()
        {
        }


        public TString(string value)
        {
            Value = value;
        }

        public string Value
        {

            set
            {
                //isUpdate = true;

                this.value = value;

                if (parent != null)
                {
                    //	parent.DoUpdate();
                }

                /*if (memoryStream == null) {
                        memoryStream = new MemoryStream ();
                    }

                    byte[] stringBytes = System.Text.Encoding.UTF8.GetBytes (value);
                    size = stringBytes.Length;
                    //memoryStream.Capacity = size;

                    memoryStream.Seek (0, SeekOrigin.Begin);
                    memoryStream.Write (stringBytes, 0, size);
                    memoryStream.Flush ();

                } else {
                    size=0;
                    //memoryStream.Capacity = 0;
                }*/

            }

            get
            {

                return this.value;

                /*	if (memoryStream != null) {

                    //	byte[] array = new byte[size];
                    //	memoryStream.Seek (0,SeekOrigin.Begin);
                    //	memoryStream.Read(array,0,size);

                    return System.Text.Encoding.UTF8.GetString (memoryStream.ToArray ());
                }*/



            }

        }



    }

}
