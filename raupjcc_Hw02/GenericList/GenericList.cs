using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _GenericList
{
    public class GenericList<X>: IGenericList<X>
    {
        private X[] _internalStorage;
        private int storageSize;
        private int maxSize;

        public GenericList()
        {
            _internalStorage = new X[4];
            storageSize = 0;
            maxSize = 4;
        }

        public GenericList(int initialSize)
        {
            if (initialSize >= 0)
            {
                _internalStorage = new X[initialSize];
                storageSize = 0;
                maxSize = initialSize;
            }
            else
            {
                _internalStorage = new X[-1 * initialSize];
                storageSize = 0;
                maxSize = -1 * initialSize;
            }

        }
        // IEnumerable <X> implementation
        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(X x)
        {
            if (storageSize == maxSize)
            {
                X[] newArray = new X[2 * maxSize];
                for (int i = 0; i < maxSize; i++)
                {
                    newArray[i] = _internalStorage[i];
                }
                maxSize = 2 * maxSize;
                _internalStorage = newArray;
            }
            storageSize++;
            _internalStorage[storageSize-1] = x;
            return;
        }
        public bool RemoveAt(int index)
        {
            if (index >= storageSize || index < 0)
            {
                throw new System.IndexOutOfRangeException();
            }
            storageSize--;
            for (int i = index; i < storageSize; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            return true;
        }
        public bool Remove(X x)
        {
            int index = IndexOf(x);
            return RemoveAt(index);
        }
        public X GetElement(int index)
        {
            if (index >= storageSize || index < 0)
            {
                throw new System.IndexOutOfRangeException();
            }
            return _internalStorage[index];
        }
        public int IndexOf(X x)
        {
            int index = -1;
            for (int i = 0; i < storageSize; i++)
            {
                if (_internalStorage[i].Equals(x))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public void Clear()
        {
            storageSize = 0;
            return;
        }
        public int Count
        {
            get { return storageSize; }
        }
        public bool Contains(X item)
        {
            if (IndexOf(item) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}