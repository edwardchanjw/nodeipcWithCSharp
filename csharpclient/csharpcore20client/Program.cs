using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Basic
{
    class Program
    {



        static void Main(string[] args)
        {

            try
            {

                try
                {
                    var pipe = new NamedPipeClientStream(".", "tmp-app.world", PipeDirection.InOut, PipeOptions.None);

                    pipe.Connect();

                    String s = "{ \"type\": \"message\", \"data\": { \"foo\": \"bar\" } } --";
                    byte[] msg = Encoding.UTF8.GetBytes(s);
                    pipe.Write(msg, 0, msg.Length);

                }
                catch (Exception e)
                {
                    Console.WriteLine("{0}", e.Message);
                }


            }
            catch (TimeoutException oEX)
            {
                Debug.WriteLine(oEX.Message);
            }


        }
    }
}
