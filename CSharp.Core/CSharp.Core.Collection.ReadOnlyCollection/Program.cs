using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CSharp.Core.Collection.ReadOnlyCollection1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class MyReadOnlyCollection<T> : ReadOnlyCollection<T>
    {
        public MyReadOnlyCollection(IList<T> list) : base(list)
        {

        }

        
    }
}
