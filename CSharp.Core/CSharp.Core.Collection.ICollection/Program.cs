using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp.Core.Collection.ICollection1
{
    /// <summary>
    /// 提供Count、Add、Remove、Clear、Contains
    /// </summary>
    class Program
    {
        /// <summary>
        /// 需要注意的是 
        ///     ICollection<T> 并没有实现 ICollection
        ///     两者之间的定义相差巨大
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
           
        }

        private static void ErrorImplementICollection()
        {
            var collection = new ErrorCollection<int>();
            string[] objs = new string[collection.Count];
            // 很显然，int 类型的集合复制给 string[]， 这破坏了静态类型安全性
            collection.CopyTo(objs, 0);
        }
    }

#warning 错误的Collection实现方式
    class ErrorCollection<T> : ICollection<T>, ICollection
    {
        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
        }

        public void CopyTo(Array array, int index)
        {
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
