using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp.Core.Collection.IList1
{
    class Program
    {
#warning 不能同时实现 IList<T> 和 IList 接口，会破坏静态类型安全性（参考ICollection）

        /// <summary>
        /// 需要注意的是 
        ///     IList<T> 并没有实现 IList
        ///     两者之间的定义相差巨大
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
        }

    }
}
