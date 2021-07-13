using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vend2000
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] array;
        private int index = -1;
        private int capacity = 2;

        public int Count => index + 1;

        public MyList()
        {
            array = new T[capacity];
        }

        public void Add(T item)
        {
            if (Count == capacity)
            {
                DoubleArraySize();
            }

            index++;
            array[index] = item;
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public T? Remove()
        {
            if (Count == 0)
            {
                return default;
            }

            var itemToReturn = array[index];
            index--;
            return itemToReturn;
        }

        public T? First()
        {
            if (Count == 0)
            {
                return default;
            }

            return array[0];
        }

        public T? Last()
        {
            if (Count == 0)
            {
                return default;
            }

            return array[index];
        }

        private void DoubleArraySize()
        {
            capacity *= 2;
            var tempArray = new T[capacity];
            for (var i = 0; i < index; i++)
            {
                tempArray[i] = array[i];
            }

            array = tempArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return array.Cast<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return array.GetEnumerator();
        }
    }
}
