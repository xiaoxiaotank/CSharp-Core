using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp.Core.Collection.IReadOnlyList1
{
    /// <summary>
    /// 提供了随机Index
    /// </summary>
    class Program
    {
        /// <summary>
        /// 需要注意的是 仅提供了泛型版本的 IReadOnlyList<T>
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
        }
    }

    class MyReadonlyList<T> : IReadOnlyList<T>
    {
        public T this[int index] => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
