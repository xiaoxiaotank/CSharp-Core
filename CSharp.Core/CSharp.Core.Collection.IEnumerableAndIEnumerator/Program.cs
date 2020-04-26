using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CSharp.Core.Collection.IEnumerableAndIEnumerator
{
    /// <summary>
    /// 仅提供迭代访问
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            EnumCharOfStringDemo();

            EnumItemOfArrayDemo();

            AutoDisposableByForeach();
        }

        private static void EnumCharOfStringDemo()
        {
            // string 实现了 IEnumerable 和 IEnumerable<char>
            string s = "Hello World";

            // 获取一个全新的枚举器。 
            // string中的枚举器为 CharEnumerator，其实现了 IEnumerator
            // 显示实现了泛型和非泛型的 GetEnumerator，实际上调用的都是string自己创建的 GetEnumerator 方法
            var enumerator = s.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            // 约等价于

            foreach (var c in s)
            {
                Console.WriteLine(c);
            }
        }

        private static void EnumItemOfArrayDemo()
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // 特殊的：数组返回的 Enumerator 是非泛型的，因为要避免破坏C#2.0之前的代码（之前不支持泛型）
            var nongenericEnumerator = numbers.GetEnumerator();
            while (nongenericEnumerator.MoveNext())
            {
                // 注意由于是非泛型，所以 Current 是 object 类型
                Console.WriteLine(nongenericEnumerator.Current);
            }

            /*--------------------------------------------------------------------------------------*/

            // 可以这样来使数组返回泛型 IEnumerator<int>
            var genericEnumerator = ((IEnumerable<int>)numbers).GetEnumerator();
            while (genericEnumerator.MoveNext())
            {
                Console.WriteLine(genericEnumerator.Current);
            }

            // 约等价于

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        private static void AutoDisposableByForeach()
        {
            // IEnumerator<T> 实现了 IDisposable 接口
            // foreach 语法糖可以确保 Enumerator 正确 Dispose

            var list = new List<int>();
            foreach (var item in list)
            {

            }

            // 等价于

            using var enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {

            }
        }

    }

    /// <summary>
    /// 标准实现方式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyCollection<T> : IList<T>, IEnumerable<T>
    {
        #region IList 相关
        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

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
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        #endregion

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public struct Enumerator : IEnumerator<T>
        {
            private readonly MyCollection<T> _list;
            private int _index;
            private T _current;

            internal Enumerator(MyCollection<T> list)
            {
                _list = list;
                _index = 0;
                _current = default;
            }

            public bool MoveNext()
            {
                _current = _list[_index];
                _index++;
                return true;
            }

            public T Current => _current!;

            object IEnumerator.Current => Current;

            public void Reset()
            {
                _index = 0;
                _current = default;
            }

            public void Dispose()
            {
            }

        }
    }

    /// <summary>
    /// 简洁实现方式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyCollectionSlim<T> : IEnumerable<T>
    {
        private readonly List<T> _list = new List<T>();

        IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _list)
            {
                // 编译器监测到该语句会生成一个隐藏的 Enumerator
                yield return item;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
