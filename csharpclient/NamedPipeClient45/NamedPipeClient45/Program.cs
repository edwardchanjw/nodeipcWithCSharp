using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace NamedPipeClient45
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool GetNamedPipeClientProcessId(IntPtr Pipe, out uint ClientProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool GetNamedPipeServerProcessId(IntPtr Pipe, out uint ClientProcessId);

        public static uint getNamedPipeClientProcID(NamedPipeServerStream pipeServer)
        {
            UInt32 nProcID;
            IntPtr hPipe = pipeServer.SafePipeHandle.DangerousGetHandle();
            if (GetNamedPipeClientProcessId(hPipe, out nProcID))
                return nProcID;
            return 0;
        }

        public static uint getNamedPipeServerProcID(NamedPipeClientStream pipeServer)
        {
            UInt32 nProcID;
            IntPtr hPipe = pipeServer.SafePipeHandle.DangerousGetHandle();
            if (GetNamedPipeServerProcessId(hPipe, out nProcID))
                return nProcID;
            return 0;
        }



        static void Main(string[] args)
        {

            try
            {

                try
                {
                    var pipe = new NamedPipeClientStream(".", "tmp-app.world", PipeDirection.InOut, PipeOptions.None);

                    pipe.Connect();

                    uint result = new uint();
                    //getNamedPipeClientProcID(, out result);
                    //Process activeProcess = Process.GetProcessById(result);
                    

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
