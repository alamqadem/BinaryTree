using System;
using System.Collections;
using System.Collections.Generic;

namespace MidTerm
{
	public class EmptyBinaryTree<T> : BinaryTree<T>
	{
		public T GetValue ()
		{
			return null;
		}

		public BinaryTree<T> Insert(T key) 
		{
			return new NonEmptyBinaryTree<T> (key);
		}

		public BinaryTree<T> Delete(T key)
		{
			return this;
		}

		public ISet<T> Search(T key)
		{
			return new HashSet<T> ();
		}

		public BinaryTree<T> GetMinimum()
		{
			return null;
		}

		public BinaryTree<T> GetMaximum ()
		{
			return null;
		}

		public BinaryTree<T> GetPredecessor()
		{
			return null;
		}

		public BinaryTree<T> GetSuccessor()
		{
			return null;
		}

		public IEnumerator getEnumerator()
		{
			return new EmptyBinaryTreeEnumerator ();
		}
	}


	public class EmptyBinaryTreeEnumerator : IEnumerator {

		public bool MoveNext() 
		{ return false; }

		public void Reset()
		{}

		object IEnumerator.Current 
		{
			get 
			{
				return null;
			}
		}
	}	
}

