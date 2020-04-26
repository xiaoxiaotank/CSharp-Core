using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp.Core.Collection.IList1
{
    /// <summary>
    /// 提供随机Add、随机Remove、随机Index
    /// </summary>
    class Program
    {
#warning 不能同时实现 IList<T> 和 IList 接口，会破坏静态类型安全性（参考ICollection）

        /// <summary>
        /// 需要注意的是 
        ///     IList<T> 并没有实现 IList
        ///     两者之间的定义相差较大
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
        }

    }

    /// <summary>
    /// List<T>类实现了泛型和非泛型的IList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyList<T> : IList<T>, IList
    {
        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        object IList.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsFixedSize => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        int IList.Add(object value)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        void IList.Remove(object value)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
