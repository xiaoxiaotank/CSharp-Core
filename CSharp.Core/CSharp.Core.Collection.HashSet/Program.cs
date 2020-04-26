using System;
using System.Collections.Generic;

namespace CSharp.Core.Collection.HashSet1
{
    /// <summary>
    /// 散列特点：
    ///     1. Contains 方法内使用散列查找，性能很高
    ///     2. 元素都是独一无二的，因此可以通过该数据结构去重
    ///     3. 无法随机访问
    ///     4. 适合进行交、并、补、差等操作
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 实质是：只存储键的散列表
            HashSet<int> hashSet = new HashSet<int>();
            // 实质是：红/黑树
            SortedSet<int> sortedSet = new SortedSet<int>();
        }
    }
}
