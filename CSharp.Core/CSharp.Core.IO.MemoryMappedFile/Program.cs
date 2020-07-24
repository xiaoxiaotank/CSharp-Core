using System;
using System.IO;
using System.IO.MemoryMappedFiles;

namespace CSharp.Core.IO._MemoryMappedFile
{
    class Program
    {
        // MemoryMappedFile 适用于：
        //      频繁进行随机访问，如要执行数百万次的 stream.Position 的修改

        static void Main(string[] args)
        {
            using var mmf = MemoryMappedFile.CreateFromFile("test.txt");
            using var accessor = mmf.CreateViewAccessor();
            // 在 position = 10 的位置写入
            accessor.Write(10, 9999);
            Console.WriteLine(accessor.ReadInt32(10));

            // “name”：为该块内存命名，其他进程可以通过指定名称来共享使用该内存
            //using var mmf2 = MemoryMappedFile.CreateFromFile("test1.txt", FileMode.OpenOrCreate, "name");

            // 1024：将文件扩容到1024B
            //using var mmf3 = MemoryMappedFile.CreateFromFile("test2.txt", FileMode.OpenOrCreate, "name", 1024);

            #region 共享内存块（也是文件，只不过位于内存，而不是磁盘）
            using var mmfShare1 = MemoryMappedFile.CreateNew("map name", 1024);
            using var accessorShare1 = mmfShare1.CreateViewAccessor();
            accessorShare1.Write(0, 12345);

            // 要求 mapName必须存在
            using var mmfShare2 = MemoryMappedFile.OpenExisting("map name");
            using var accessorShare2 = mmfShare2.CreateViewAccessor();
            Console.WriteLine(accessorShare2.ReadInt32(0));
            #endregion


        }
    }
}
