using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Core.IO._PipeStream
{
    class Program
    {
        // 管道：很适合在同一台计算机进行进程间的通信（IPC），这样它就不依赖任何网络传输，也不会有防火墙问题
        //      当然也支持不同计算机进程间通信

        static void Main(string[] args)
        {
            #region 匿名管道（速度更快）：支持在同一台计算机中的父进程和子进程之间进行单向通信
            using var anonymousPipeServerStream = new AnonymousPipeServerStream();
            using var anonymousPipeClientStream = new AnonymousPipeClientStream(PipeDirection.InOut, "");
            #endregion

            #region 命名管道（更加灵活）：允许同一台计算机的任意两个进程之间，或不同计算机（使用Windows网络）的两个进程间进行双向通信
            // 注意哦，默认是双向通信，但是要求通信为一问一答，不能客户端与服务端同时发送或接受

            #region Write Byte / Read Byte
            var namedPipeServerTask = Task.Run(() =>
            {
                using var namedPipeServerStream = new NamedPipeServerStream("pipe1");
                namedPipeServerStream.WaitForConnection();
                namedPipeServerStream.WriteByte(100);
                Console.WriteLine(namedPipeServerStream.ReadByte());
            });

            var namedPipeClientTask = Task.Run(() =>
            {
                using var namedPipeClientStream = new NamedPipeClientStream("pipe1");
                namedPipeClientStream.Connect();
                Console.WriteLine(namedPipeClientStream.ReadByte());
                namedPipeClientStream.WriteByte(200);
            });

            Task.WhenAll(namedPipeServerTask, namedPipeClientTask).Wait();
            #endregion

            #region Write Message / Read Message
            namedPipeServerTask = Task.Run(() =>
            {
                using var namedPipeServerStream = new NamedPipeServerStream("pipe1", PipeDirection.InOut, 1, PipeTransmissionMode.Message);
                namedPipeServerStream.WaitForConnection();
                namedPipeServerStream.Write(Encoding.UTF8.GetBytes("Hello Client"));
                Console.WriteLine(ReadMessage(namedPipeServerStream));
            });

            namedPipeClientTask = Task.Run(() =>
            {
                using var namedPipeClientStream = new NamedPipeClientStream("pipe1");
                namedPipeClientStream.Connect();
                // 必须在 Connect 之后设置
                namedPipeClientStream.ReadMode = PipeTransmissionMode.Message;
                Console.WriteLine(ReadMessage(namedPipeClientStream));
                namedPipeClientStream.Write(Encoding.UTF8.GetBytes("Hello Server"));
            });

            Task.WhenAll(namedPipeServerTask, namedPipeClientTask).Wait();
            #endregion

            #endregion
        }

        /// <summary>
        /// 要求 ReadMode = PipeTransmissionMode.Message
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static string ReadMessage(PipeStream s)
        {
            using var ms = new MemoryStream();
            // 4KB
            var buffer = new byte[0x1000];

            do
            {
                ms.Write(buffer, 0, s.Read(buffer, 0, buffer.Length));
            }
            while (!s.IsMessageComplete);

            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}
