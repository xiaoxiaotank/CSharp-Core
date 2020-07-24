using System;
using System.IO;

namespace CSharp.Core.IO._MemoryStream
{
    class Program
    {
        // 内部使用数组进行存储，这在一定程度上与使用流的目的（每次以一定量的数据按照序列读取到内存）相违背
        // 但是仍有用途：随机访问一个不可查找的流
        
        static void Main(string[] args)
        {
            using var ms = new MemoryStream();
            Stream sourceStream = null;
            sourceStream.CopyTo(ms);

            // 这样就可以随机访问了
            var array = ms.ToArray();

            // 这样获取的是ms中用来存储数据的数组，更加高效，不过这个数组的长度要比流的实际长度长一些
            var array2 = ms.GetBuffer();
        }
    }
}
