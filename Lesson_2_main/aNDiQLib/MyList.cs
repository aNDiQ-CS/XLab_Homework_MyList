using System.Reflection.Metadata.Ecma335;

namespace aNDiQLib
{
    public class MyList<T>
    {
        private T[] _list = new T[4];
        private int _count = 0;
        private int _capacity = 4;

        public MyList() 
        {
            _list = new T[4];
            _count = 0;
        }

        public void Add(T item)
        {
            // TODO: Исключений лучше избегать, они затратны
            try
            {
                _list[_count++] = item;
            }
            catch (IndexOutOfRangeException)
            {                
                ResizeMyList();
                _list[_count-1] = item;                
            }
        }

        public override string ToString()
        {
            if (_count == 0) return "[]";
            
            string s = "[";
            for (int i = 0; i < _count-1; i++)
            {
                s += _list[i] + ", ";
            }       
            
            return s + _list[_count-1] + "]";
        }

        /*
         * In this example I use only x2, like in original
         * But I added doubling down if we delete from MyList
         */
        private void ResizeMyList()
        {
            int capacity;
            capacity = (_count <= _capacity / 2) ? Math.Max(_capacity / 2, 4) : _capacity * 2;

            Console.WriteLine("\n!!!");
            Console.WriteLine("MyArray was resized! That's because you're trying to Add or Remove an item!");
            Console.WriteLine("It will have new capacity: " + _capacity + "->" + capacity);

            _capacity = capacity;
            T[] tempList = new T[capacity];
            for (int i = 0; i < _list.Length; i++)
            {
                tempList[i] = _list[i];
            }
            _list = tempList;

            Console.WriteLine("Count: " + _count);
            Console.WriteLine("Capacity: " + _capacity);
            Console.WriteLine("!!!\n");
        }

        public void Insert(T item, int index)
        {
            if (index > _count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            _count++;
            if (_count >= _capacity)
            {
                ResizeMyList();
            }

            // TODO: упростить, под Arrays лучше
            T[] tempList = new T[_capacity];
            for (int i = 0; i < index; i++)
            {
                tempList[i] = _list[i];
            }
            tempList[index] = item;
            for (int i = index + 1; i < _count; i++) 
            {
                tempList[i] = _list[i - 1];
            }
            _list = tempList;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);            
            if (index < 0)
            {
                return false;
            }
            else
            {
                RemoveAt(index);
                return true;
            }
        }

        public void RemoveAt(int index)
        {
            _count--;

            T[] tempList = new T[_count];
            for (int i = 0; i < index; i++)
            {
                tempList[i] = _list[i];
            }
            for (int i = index; i < _count; i++)
            {
                tempList[i] = _list[i+1];
            }
            
            _list = tempList;
            
            CheckResizeOptimization();
        }

        private void CheckResizeOptimization()
        {
            if (_count <= _capacity / 2)
            {
                ResizeMyList();
            }
        }

        public void Clear()
        {
            _count = 0;
            _capacity = 4;
            _list = new T[_capacity];
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }
        
        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (item != null && item.Equals(_list[i]))
                {                    
                    return i;
                }
            }
            return -1;
        }
        
        public T this[int i]
        {
            get => _list[i];             //TODO: Возможна ошибка, переписать под i > 0 && i < _count
            set => _list[i] = value;
        }
    }
}


