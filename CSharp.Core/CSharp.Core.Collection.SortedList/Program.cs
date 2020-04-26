using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp.Core.Collection.SortedList1
{
    /// <summary>
    /// 内部实质是：两个数组（二分查找，检索性能很高，但是插入性能很差）
    /// 
    /// 泛型版可通过 Key 和 Index 访问元素
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            SortedList sortedList1 = new SortedList();
            SortedList<int, string> sortedList2 = new SortedList<int, string>();

            _ = sortedList1["key"];

            _ = sortedList2[1];
            _ = sortedList2.Keys[0];
            _ = sortedList2.Values[0];
        }
    }
}
