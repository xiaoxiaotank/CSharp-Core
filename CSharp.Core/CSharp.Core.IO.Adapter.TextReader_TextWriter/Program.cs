using System;
using System.IO;
using System.Text;

namespace CSharp.Core.IO.Adapter.TextReader_TextWriter
{
    class Program
    {
        // 文本适配器（TextWriter / TextReader，抽象类）用于扩展IO中文本处理的功能，包括两种实现：
        //      StreamWriter / StreamReader: 用于包装流，底层采用流式处理
        //      StringWriter / StringReader: 不用于包装流，而是包装一个字符串或StringBuilder，用来处理字符串的

        // 所有适配器在关闭时，默认会同时关闭基流，通过设置 levelOpen = true 来阻止关闭基流

        static void Main(string[] args)
        {
            #region Stream 处理流
            #region 灵活的 writer，但是代码较多
            using (var fsw = File.OpenWrite("test.txt"))
            // 编码方式不指定的情况下默认为 UTF8
            using (var sw = new StreamWriter(fsw))
            {
                sw.BaseStream.Position = sw.BaseStream.Length;
                sw.WriteLine();
                sw.Write("Haha ");
                sw.WriteLine("Hello World");
            }
            #endregion

            #region 新增或重写文件的 writer，简洁
            //using (var sw = File.CreateText("test.txt"))
            //{

            //}
            #endregion

            #region 在文件末尾新增的 writer，简洁
            // 1.
            using (var sw = File.AppendText("test.txt"))
            {
                sw.WriteLine("End");
            }
            // 2.
            File.AppendAllText("test.txt", "!!!!!");
            #endregion

            #region Reader 原始写法
            using (var fsr = File.OpenRead("test.txt"))
            using (var sr = new StreamReader(fsr))
            {
                // peek不会导致指针前移，如果流指针已经到达末尾，会返回 -1
                Console.WriteLine($"Peek:{(char)sr.Peek()}");
                // 如果流指针已经到达末尾，会返回 null
                Console.WriteLine(sr.ReadLine());
                Console.WriteLine(sr.ReadToEnd());
            }
            #endregion

            #region Reader 简便写法
            using (var sw = File.OpenText("test.txt"))
            {
                Console.WriteLine(sw.ReadLine());
                Console.WriteLine(sw.ReadToEnd());
            }
            #endregion 
            #endregion

            #region String 处理字符串
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                sw.WriteLine("String Writer");
            }
            Console.WriteLine(sb);

            var s = "Hello World\r\nHi xiaoxiaotank";
            using (var sr = new StringReader(s))
            {
                Console.WriteLine(sr.ReadLine());
                Console.WriteLine(sr.ReadLine());
            }
            #endregion

            #region Binary 处理二进制
            using (var ms = new MemoryStream())
            {
                using (var bw = new BinaryWriter(ms, Encoding.UTF8, true))
                {                    
                    // 可以直接写基元类型，而不需要转换成byte
                    bw.Write("哈哈哈，我终于可以直接传递了");
                    bw.Write("xiaoxiaotank");
                    bw.Write(18);
                }

                ms.Position = 0;
                using (var br = new BinaryReader(ms))
                {
                    Console.WriteLine(br.ReadString());
                    Console.WriteLine($"Name: {br.ReadString()}");
                    Console.WriteLine($"Age: {br.ReadInt32()}");
                }
            }
            #endregion
        }
    }
}
