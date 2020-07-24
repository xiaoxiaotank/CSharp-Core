using System;
using System.IO;

namespace CSharp.Core.IO._BufferedStream
{
    class Program
    {
        // BufferedStream：用于装饰或包装另一个具有缓冲功能的流
        static void Main(string[] args)
        {
            using var fs = File.OpenRead("test.txt");
            // 1KB
            using var bs = new BufferedStream(fs, 1024);
            bs.ReadByte();
            // 可以看到 fs 的位置已经前进了 1024（如果长度足够），这就表明fs已经将部分流缓存到了bs中
            Console.WriteLine(fs.Position);
        }
    }
}
