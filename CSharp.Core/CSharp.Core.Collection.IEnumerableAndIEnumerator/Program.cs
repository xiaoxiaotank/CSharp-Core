using System;
using System.Collections;

namespace CSharp.Core.Collection.IEnumerableAndIEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // string 实现了 IEnumerable
            string s = "Hello World";
            // 获取一个全新的枚举器。 string中的枚举器为 CharEnumerator，其实现了 IEnumerator
            var enumerator = s.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
    }
}
