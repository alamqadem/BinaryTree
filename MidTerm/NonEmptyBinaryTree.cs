using System;
using System.Collections;
using System.Collections.Generic;

namespace MidTerm
{

	enum Side {LEFT, RIGHT};

	/**
	 * @class{BinaryTree}: 
	 * 
	 * 
	 **/
	public class NonEmptyBinaryTree<T> : BinaryTree<T>
		where T : IComparable<T>
	{
		readonly T value;
		BinaryTree<T> leftSubTree;
		BinaryTree<T> rightSubTree;

		public NonEmptyBinaryTree (T value, NonEmptyBinaryTree<T> leftSubTree, NonEmptyBinaryTree<T> rightSubTree)
		{
			this.value = value;
			this.leftSubTree = (leftSubTree != null) ?  leftSubTree : EMPTY;
			this.rightSubTree = (rightSubTree != null) ? rightSubTree : EMPTY;
		}

		public NonEmptyBinaryTree(T value)
		{
			this(value, EMPTY, EMPTY);
		}

		public T GetValue ()
		{
			return value;
		}

		public BinaryTree<T> Insert(T newValue)
		{
			if (newValue.CompareTo (this.value) < 0)
				return InsertAux (newValue, Side.LEFT);
			else
				return InsertAux (newValue, Side.RIGHT);
		}

		protected BinaryTree<T> InsertAux(T newValue, Side side)
		{
			BinaryTree<T> temp = this.getChild(side).Insert(newValue);

			this.setChild (side, temp);

			return this;
		}

		public ISet<T> Search(T key)
		{
			HashSet<T> result = new HashSet<T> ();

			int compareResult = key.CompareTo (this.value);

			if (compareResult < 0)
				result.Add(leftSubTree.Search (key));

			if (compareResult == 0)
				result.Add(this);
			
			if (compareResult >= 0)
				result.Add(rightSubTree.Search (key));

			return result;
		}

		public BinaryTree<T> Delete(T key)
		{
			int compareResult = key.CompareTo (this.value);

			if (compareResult == 0)
				return this.DeleteMyValue ();

			if (compareResult < 0) 
				this.leftSubTree = leftSubTree.Delete (key);

			if (compareResult >= 0) 
				this.rightSubTree = rightSubTree.Delete (key);

			return this;
		}

		protected BinaryTree<T> DeleteMyValue()
		{
			if (this.leftSubTree == EMPTY)
				return this.rightSubTree;

			if (this.rightSubTree == EMPTY)
				return this.leftSubTree;

			BinaryTree<T> replacementOfDeleted = this.rightSubTree.GetMinimum ();

			// copy the key to be substituted
			NonEmptyBinaryTree<T> result = new NonEmptyBinaryTree<T> (replacementOfDeleted.GetValue(), 
				this.leftSubTree, 
				this.rightSubTree);

			// delete recursively the key used for the substitutio from the right subtree
			result.rightSubTree.Delete (replacementOfDeleted.GetValue());

			return result;
		}

		public IEnumerator GetEnumerator()
		{
			return new NonEmptyBinaryTreeEnumerator(this);
		}
			
		public BinaryTree<T> GetMinimum() 
		{
			if (leftSubTree == EMPTY)
				return this;
			
			return leftSubTree.GetMinimum();
		}

		public BinaryTree<T> GetMaximum()
		{
			if (rightSubTree == EMPTY)
				return this;
			
			return rightSubTree.GetMaximum();
		}

		public BinaryTree<T> GetSuccessor()
		{
			if (rightSubTree == EMPTY)
				return null;

			return rightSubTree.GetMinimum();
		}

		public BinaryTree<T> GetPredecessor()
		{
			if (leftSubTree == EMPTY)
				return null;
			
			return leftSubTree.GetMaximum();
		}

		NonEmptyBinaryTree<T> getChild(Side side) 
		{
			if (side == Side.LEFT)
				return leftSubTree;

			if (side == Side.RIGHT)
				return rightSubTree;

			return null;
		}

		NonEmptyBinaryTree<T> setChild(Side side, NonEmptyBinaryTree<T> child)
		{
			if (side == Side.LEFT)
				leftSubTree = child;
			else if (side == Side.RIGHT)
				rightSubTree = child;
			else
				return null;

			return child;
		}
	}
}

