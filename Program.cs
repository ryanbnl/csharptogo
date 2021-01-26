using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpClient
{
    // extern char* HelloWorld(char* hello);
    class Program
    {
        [DllImport(
            "helloworld.dll",
            CharSet = CharSet.Unicode,
            CallingConvention = CallingConvention.Cdecl)]
        //[return: MarshalAs(UnmanagedType.LPStr)]
        static extern IntPtr HelloWorld();

        static void Main(string[] args)
        {
            Console.WriteLine("Calling C Go");

            var x = Marshal.PtrToStringAnsi(HelloWorld());

            Console.WriteLine("Answer " + x);

            Console.WriteLine("Go called");
        }
    }
}