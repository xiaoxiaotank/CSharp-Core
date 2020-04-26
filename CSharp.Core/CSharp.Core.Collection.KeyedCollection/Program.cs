using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace CSharp.Core.Collection.KeyedCollection1
{
    /// <summary>
    /// 意义：用于基本集合在Insert、Set、Remove、Clear等操作时的扩展
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 非泛型
            _ = new MyDictionary();
        }
    }

    /// <summary>
    /// 提供了一些虚方法以进行重写
    /// </summary>
    class MyDictionary : DictionaryBase
    {
        protected override object OnGet(object key, object currentValue)
        {
            return base.OnGet(key, currentValue);
        }

        protected override void OnInsert(object key, object value)
        {
            base.OnInsert(key, value);
        }

        protected override void OnInsertComplete(object key, object value)
        {
            base.OnInsertComplete(key, value);
        }

        protected override void OnSet(object key, object oldValue, object newValue)
        {
            base.OnSet(key, oldValue, newValue);
        }

        protected override void OnSetComplete(object key, object oldValue, object newValue)
        {
            base.OnSetComplete(key, oldValue, newValue);
        }

        protected override void OnRemove(object key, object value)
        {
            base.OnRemove(key, value);
        }

        protected override void OnRemoveComplete(object key, object value)
        {
            base.OnRemoveComplete(key, value);
        }

        protected override void OnClear()
        {
            base.OnClear();
        }

        protected override void OnClearComplete()
        {
            base.OnClearComplete();
        }
    }

    /// <summary>
    /// 提供了一些虚方法以进行重写
    /// 
    /// 实质：数组 + 散列表
    /// </summary>
    class MyKeyedCollection<TKey, TItem> : KeyedCollection<TKey, TItem>
    {
        protected override TKey GetKeyForItem(TItem item)
        {
            throw new NotImplementedException();
        }

        protected override void InsertItem(int index, TItem item)
        {
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, TItem item)
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
