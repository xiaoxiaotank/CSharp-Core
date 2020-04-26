using System;
using System.Collections;

namespace CSharp.Core.Collection.BitArray1
{

#warning 与 Array 类没有任何关系，

    /// <summary>
    /// 实现了ICollection, IEnumerable, ICloneable
    /// 数组中的每一个元素只占一个 bit，使用 0 和 1 表示，即 true 和 false
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 默认大小是 4 byte，即 32 bit，采用小端
            // 1000 0000 0000 0000 0000 0000 0000 0000
            BitArray bitArray1 = new BitArray(new[] { 1 });
            // 0010 0000 0000 0000 0000 0000 0000 0000
            BitArray bitArray2 = new BitArray(new[] { 4 });

            // 需要注意的是，正确结果应倒序输出，才是自然语言规则（大端）
            var bitArray = bitArray1.Or(bitArray2);
            for (int i = bitArray.Count - 1; i >= 0; i--)
            {
                Console.Write(Convert.ToByte(bitArray[i]));
            }
        }
    }
}
