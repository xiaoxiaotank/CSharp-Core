using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Core.Collection.Array1
{
    /// <summary>
    /// Array 是一个抽象类，实现了非泛型IList、ICollection、IEnumerable
    /// 
    /// CLR不允许对象的大小超过2GB（无论32为还是64位），
    /// 所以虽然数组理论上可以有2^64个元素，但是太大了
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 通过语法糖声明的数组都继承于 Array，并且隐式实现了 IList<T>
            var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // 所有的数组类型都继承于 Array
            Array numberArray = numbers;
            foreach (var item in numberArray)
            {
                // 由于对象不支持泛型，所以item的类型为 object
            }
            // Array虽然没有实现泛型 IList<T>，但是本身自带泛型静态方法
            foreach (int item in Array.AsReadOnly(numbers))
            {
                // 通过Array静态方法将其转为泛型
            }

            // 所有的数组类型（特别是泛型）都能转换为相应的 IList 或 IList<T>
            IList numberList1= numberArray;
            IList<int> numeberList2 = numbers;
            IList numberList3 = numbers;

            var task = TestArrayResizeAsync(numbers);

            // 注意：如果 newSize 和 oldSize 一样，则该方法并未做任何事
            Array.Resize(ref numbers, 9);
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = 100 + i;
            }

            task.Wait();

            Array destArray = Array.CreateInstance(typeof(int), numbers.Length + 1);
            // 原子操作，如果失败则回滚
            Array.ConstrainedCopy(numbers, 0, destArray, 0, numbers.Length);

#warning 数组虽然实现了 IList，但是不支持 Add 和 Remove
            //((IList)numbers).Add(1);
            //((IList)numbers).Remove(2);
        }

        private static async Task TestArrayResizeAsync(int[] numbers)
        {
            await Task.Delay(1000);
            Console.WriteLine("虽然下方已经调用了 Resize 方法，但是当前使用的 internalNumebers 仍是以前的数组，因为 Resize 内部创建了一个新数组，number 指针指向了新数组");
            Array.ForEach(numbers, Console.WriteLine);
        }
    }
}
