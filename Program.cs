using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpClient
{
    // extern char* HelloWorld(char* hello);
    class Program
    {
        private struct GoString
        {
            public IntPtr p;
            public long n;
        }

        [DllImport("helloworld.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr HelloWorld();

        [DllImport("helloworld.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr HelloGalaxy();

        [DllImport("helloworld.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr GenerateIssuerNonceB64();
        
        [DllImport("helloworld.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr Issue(GoString issuerPkXml, GoString issuerSkXml, GoString issuerNonceB64, GoString commitmentsJson);
        
        static void Main(string[] args)
        {
            TestHelloWorld();
            Console.WriteLine("");
            TestHelloGalaxy();
            Console.WriteLine("");
            TestGetIssuerNonce();
            Console.WriteLine("");
            TestIssue();
        }

        private static void TestHelloWorld()
        {
            Console.WriteLine("Calling Go.HelloWorld");
            var result = Marshal.PtrToStringAnsi(HelloWorld());
            Console.WriteLine("Answer: " + result);
        }

        private static void TestHelloGalaxy()
        {
            Console.WriteLine("Calling Go.HelloGalaxy");
            var result = Marshal.PtrToStringAnsi(HelloGalaxy());
            Console.WriteLine("Answer: " + result);
        }

        private static void TestGetIssuerNonce()
        {
            Console.WriteLine("Calling Go.GenerateIssuerNonceB64");
            var result = Marshal.PtrToStringAnsi(GenerateIssuerNonceB64());
            Console.WriteLine("Answer: " + result);
        }

        private static void TestIssue()
        {
            Console.WriteLine("Calling Go.Issue");

            var issuerPkXml = ToGoString("PkXml");
            var issuerSkXml = ToGoString("SkXml");
            var issuerNonceB64 = ToGoString("NONCE");
            var commitmentsJson = ToGoString("{ commitments: true }");
            
            var result = Marshal.PtrToStringAnsi(Issue(issuerPkXml, issuerSkXml, issuerNonceB64, commitmentsJson));

            Console.WriteLine("Answer: " + result);
        }

        private static GoString ToGoString(string str)
        {
            return new GoString
            {
                p = Marshal.StringToHGlobalAnsi(str),
                n = str.Length
            };
        }
    }
}