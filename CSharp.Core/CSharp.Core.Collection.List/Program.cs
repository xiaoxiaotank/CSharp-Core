using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.Core.Collection.List1
{
    /// <summary>
    /// List 和 ArrayList 内部其实都是维护了一个数组，当容量不足时，会创建一个更大容量的数组来替换，并将之前的元素复制进来
    ///     newSize = oldSize * 2
    ///     在未指定初始size的情况下，初始size = 0，添加1个元素后，size = 4
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 仅实现了 IList，在使用反射时，使用 ArrayList 比 List 性能更高
            ArrayList arrayList = new ArrayList() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // 实现了 IList 和 IList<T>
            List<int> list = arrayList.Cast<int>().ToList();

            // 在 list 元素有序的情况下，使用 BinarySearch 查找效率很高
            var index = list.BinarySearch(2);
            // 转换元素
            var strList = list.ConvertAll(item => item.ToString());

        }
    }
}
