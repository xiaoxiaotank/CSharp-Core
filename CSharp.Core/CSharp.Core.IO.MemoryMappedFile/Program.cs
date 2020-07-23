using System;

namespace CSharp.Core.IO._MemoryMappedFile
{
    class Program
    {
        // 如果要执行数百万次的 stream.Position 的修改，则使用 MemoryMappedFile 更合适
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
