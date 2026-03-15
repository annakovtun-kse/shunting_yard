namespace Algorithms
{
    using System;
    using System.Collections.Generic;

    public class ArrayList<T>
    {
        private T[] _array = new T[10];
        private int _pointer = 0;

        public void Add(T element)
        {
            if (_pointer == _array.Length)
            {
                var extendedArray = new T[_array.Length * 2];
                for (var i = 0; i < _array.Length; i++)
                {
                    extendedArray[i] = _array[i];
                }

                _array = extendedArray;
            }
            
            _array[_pointer] = element;
            _pointer += 1;
        }

        public void Remove(T element)
        {
            for (var i = 0; i < _pointer; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_array[i], element))
                {
                    for (var j = i; j < _pointer - 1; j++)
                    {
                        _array[j] = _array[j + 1];
                    }

                    _pointer -= 1;
                    return;
                }
            }
        }
        
        public void RemoveAt(int index)
        {
            bool indexInvalid = index < 0 || index >= _pointer;
            if (indexInvalid)
            {
                Console.WriteLine("Incorrect index");
            }
            else
            {
                for (var j = index; j < _pointer - 1; j++)
                {
                    _array[j] = _array[j + 1];
                }
                _pointer -= 1;
            }
        }

        public T GetAt(int index)
        {
            return _array[index];
        }

        public int Count()
        {
            return _pointer;
        }

        public float Max()
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(double) || 
                typeof(T) == typeof(float) || typeof(T) == typeof(decimal))
            {
                float currMax = Convert.ToSingle(_array[0]);
                
                for (var i = 1; i < _pointer; i++)
                {
                    float currentElement = Convert.ToSingle(_array[i]);
                    
                    if (currentElement > currMax)
                    {
                        currMax = currentElement;
                    }
                }

                return currMax;
            }
            else
            {
                throw new InvalidOperationException("Only numerical types");
            }
        }

        public int GetIndex(T element)
        {
            return _array.IndexOf(element);
        }
        }
    }