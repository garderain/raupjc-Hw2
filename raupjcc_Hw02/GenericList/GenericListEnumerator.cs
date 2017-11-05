using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _GenericList
{
    public class GenericListEnumerator<X>: IEnumerator<X>
    {
        private GenericList<X> _sentlist;
        private int _pointer;
        private X _item;
        public GenericListEnumerator(GenericList<X> sentList)
        {
            _sentlist = sentList;
            _pointer = -1;
        }
        public void Dispose()
        {
        }
        public bool MoveNext()
        {
            _pointer++;
            if (_pointer >= _sentlist.Count)
            {
                return false;
            }
            _item = _sentlist.GetElement(_pointer);
            return true;

        }
        public void Reset()
        {
            _pointer = -1;
        }

        public X Current
        {
            get
            {
                return _item;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

    }
}