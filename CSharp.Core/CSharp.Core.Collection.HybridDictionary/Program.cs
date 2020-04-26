using System;
using System.Collections.Specialized;

namespace CSharp.Core.Collection.HybridDictionary1
{
    /// <summary>
    /// 实质：ListDictionary + HashTable
    /// 意义：当 ListDictionary 元素达到一定大小后将其转换为 HashTable，保证良好性能
    /// </summary>
    class Program
    {
        /// <summary>
        /// 非泛型
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            HybridDictionary hybridDictionary = new HybridDictionary();
        }
    }
}
