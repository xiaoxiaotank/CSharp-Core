using System;
using System.IO;
using System.IO.Compression;

namespace CSharp.Core.IO.Compression
{
    class Program
    {
        // DeflateStream 与 GZipStream
        //  区别：GZipStream会在开头和结尾处写入额外的协议信息，其中包括检测错误的CRC

        static void Main(string[] args)
        {
            var data = new byte[1024];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(i % 10 + 1);
            }

            #region 关闭 ms 的写法
            var ms = new MemoryStream();
            using (var ds = new DeflateStream(ms, CompressionMode.Compress))
            {
                // 将data压缩后写入ms
                ds.Write(data);
            }

            var compressedData = ms.ToArray();
            Console.WriteLine(compressedData.Length);

            data = new byte[1024];
            using (ms = new MemoryStream(compressedData))
            using (var ds = new DeflateStream(ms, CompressionMode.Decompress))
            {
                ds.Read(data, 0, data.Length);
            }
            #endregion


            #region 不关闭 ms 的写法
            using (ms = new MemoryStream())
            {
                using (var ds = new DeflateStream(ms, CompressionMode.Compress, true))
                {
                    // 将data压缩后写入ms
                    ds.Write(data);
                }
                Console.WriteLine(ms.Length);

                data = new byte[1024];
                ms.Position = 0;
                using (var ds = new DeflateStream(ms, CompressionMode.Decompress))
                {
                    ds.Read(data, 0, data.Length);
                }

            }
            #endregion
        }
    }
}
