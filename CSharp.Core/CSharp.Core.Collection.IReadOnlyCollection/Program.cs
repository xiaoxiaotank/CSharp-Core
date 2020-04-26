using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp.Core.Collection.IReadOnlyCollection1
{
    /// <summary>
    /// 提供了Count
    /// </summary>
    class Program
    {
        /// <summary>
        /// 需要注意的是 仅存在泛型版本的IReadOnlyCollection<T>
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
        }
    }

    class MyReadOnlyCollection<T> : IReadOnlyCollection<T>
    {
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
