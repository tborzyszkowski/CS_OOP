using System;

namespace TDD2
{
	public class Stack<T>
	{
		private T[] _storage;
		private int _topIndex;
		public bool IsEmpty => _topIndex == 0;
		public Stack()
		{
			_storage = new T[10];
			//_topIndex = -1;
		}
		public void Push(T element)
		{
			if (_topIndex >= _storage.Length)
			{
				T[] newArray = new T[_storage.Length * 2];
				for (int i = 0; i < _storage.Length; i++)
					newArray[i] = _storage[i];
				_storage = newArray;
			}
			_storage[_topIndex++] = element;
		}
		public T Pop()
		{
			if (_topIndex - 1 < 0)
				throw new InvalidOperationException();
			return _storage[--_topIndex];
			//return default(T);
		}

		public T Peek()
		{
			if (_topIndex == 0)
				throw new InvalidOperationException();
			return _storage[_topIndex - 1];
			//return default(T);
		}
	}
}
