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

        [DllImport(
            "helloworld.dll",
            CharSet = CharSet.Unicode,
            CallingConvention = CallingConvention.Cdecl)]
        //[return: MarshalAs(UnmanagedType.LPStr)]
        static extern IntPtr HelloGalaxy();

        static void Main(string[] args)
        {
            Console.WriteLine("Calling Go.HelloWorld");
            var x = Marshal.PtrToStringAnsi(HelloWorld());
            Console.WriteLine("Answer " + x);

            Console.WriteLine("");

            Console.WriteLine("Calling Go.HelloGalaxy");
            var y = Marshal.PtrToStringAnsi(HelloGalaxy());
            Console.WriteLine("Answer " + y);
        }
    }
}