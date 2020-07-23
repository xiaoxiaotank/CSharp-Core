using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Csharp.Core.IO._FileStream
{
    class Program
    {
        // 需求:
        //  读/写：默认支持读写，通过 FileAccess 设置只读或只写
        //      文件存在：
        //          截断（将文件大小重置为0）：FileMode.Truncate
        //          原样：FileMode.Open
        //      文件不存在：FileMode.CreateNew
        //      不确定文件是否存在：
        //          如果存在：
        //              截断（将文件大小重置为0）：FileMode.Create
        //              原样：
        //                  同时支持读写：FileMode.OpenOrCreate / File.OpenWrite
        //                  仅支持写（追加）：FileMode.Append
        //  只读：FileMode.Open() / File.OpenRead() ，文件不存在时会抛异常



        static void Main(string[] args)
        {
            // 打开或新建文件
            using var fs = new FileStream("test.txt", FileMode.OpenOrCreate);

            Console.WriteLine($"{nameof(fs.CanRead)}: {fs.CanRead}");
            Console.WriteLine($"{nameof(fs.CanWrite)}: {fs.CanWrite}");
            Console.WriteLine($"{nameof(fs.CanSeek)}: {fs.CanSeek}");
            // 网络流支持超时设置，文件流不支持。如果设置了超时时间，那么在Read/Write超时时会抛异常
            Console.WriteLine($"{nameof(fs.CanTimeout)}: {fs.CanTimeout}");

            //------------------------- Write ---------------------------------
            var bytes = Encoding.Default.GetBytes("\nHello World");
            // 将 bytes 从索引 0 开始，写入 length（往后的长度不能超过数组长度）个byte到文件指定位置
            fs.Position = fs.Length;
            fs.Write(bytes, 0, bytes.Length);
            
            // 如果想要写入单个字节，则使用 fs.WriteByte(value);

            //----------------------- Read ----------------------------------
            var buffer = new byte[1024 * 1024];
            // 从指定位置开始读，将读取的内容记录到 从 buffer 的索引 0 开始，最大 length（往后的长度不能超过数组长度）个 byte
            fs.Position = 0;
            var readedLength = fs.Read(buffer, 0, buffer.Length);
            Console.WriteLine($"读取到了 {readedLength} 个字节，内容：\n{Encoding.Default.GetString(buffer[..readedLength])}");
            Console.WriteLine($"是否已读取到末尾：{fs.Position >= fs.Length}");

            // 当离开Main方法时，会自动关闭流Dispose，内部会自动调用 Flush、Close
        }

        void Mark()
        {
            // 补充

            #region FileStream的创建
            var fsReadWrite = File.Open("", FileMode.OpenOrCreate);
            var fsRead = File.OpenRead("");
            var fsWrite = File.OpenWrite("");
            var fsTxtRead = File.OpenText("");
            // FileShare：文件共享选项，默认允许其他进程读取该文件
            // 内部缓冲区大小默认为 4KB，这里设置为 1024B = 1KB 
            var fs1 = new FileStream("", FileMode.Open, FileAccess.ReadWrite, FileShare.Read, 1024);
            #endregion

            #region 一次性读到内存
            File.ReadAllBytes("");
            File.ReadAllText("");
            // 返回的是数组
            File.ReadAllLines("");
            #endregion

            // 带有延迟加载的按行读取读取
            File.ReadLines("");

            #region 一次性写入到文件
            // 重写（删除原文件内容）
            File.WriteAllBytes("", new byte[1024]);
            File.WriteAllText("", "");
            File.WriteAllLines("", new string[1024]);
            // 追加到原文件末尾
            File.AppendAllText("", "");
            File.AppendAllLines("", Enumerable.Empty<string>());
            #endregion

            
        }
    }
}
