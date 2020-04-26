using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace CSharp.Core.Collection1.Collection1
{
    /// <summary>
    /// 意义：用于基本集合在Insert、Set、Remove、Clear等操作时的扩展
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 非泛型 1.0引入的
            _ = new MyCollection();
            // 泛型
            _ = new MyCollection<int>();
        }
    }

    /// <summary>
    /// 提供了一些虚方法以进行重写
    /// </summary>
    class MyCollection : CollectionBase
    {
        protected override void OnInsert(int index, object value)
        {
            base.OnInsert(index, value);
        }

        protected override void OnInsertComplete(int index, object value)
        {
            base.OnInsertComplete(index, value);
        }

        protected override void OnSet(int index, object oldValue, object newValue)
        {
            base.OnSet(index, oldValue, newValue);
        }

        protected override void OnSetComplete(int index, object oldValue, object newValue)
        {
            base.OnSetComplete(index, oldValue, newValue);
        }

        protected override void OnRemove(int index, object value)
        {
            base.OnRemove(index, value);
        }

        protected override void OnRemoveComplete(int index, object value)
        {
            base.OnRemoveComplete(index, value);
        }
    }

    /// <summary>
    /// 提供了一些虚方法以进行重写
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyCollection<T> : Collection<T>
    {
        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, T item)
        {
            base.SetItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            base.ClearItems();
        }
    }
}
