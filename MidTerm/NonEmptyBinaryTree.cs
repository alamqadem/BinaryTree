using System;
using System.Collections;

namespace MidTerm
{

	enum Side {LEFT, RIGHT};

	/**
	 * @class{BinaryTree}: 
	 * 
	 * 
	 **/
	public class BinaryTree<T> : ICollection
		where T : IComparable<T>
	{
		readonly T value;
		BinaryTree<T> leftSubTree;
		BinaryTree<T> rightSubTree;

		/**
		 * @pre-conditions:
		 * 
		 * @function BinaryTree
		 * 
		 * @argument{value}: the key of this node of the tree
		 * @argument{leftSubTree}: the left subtree
		 * @argument{rightSubTree}: the right subtree
		 * 
		 * @effect: instanciate the class with the value and the two subtrees
		 * 
		 * @post-conditions:
		 **/
		public BinaryTree (T value, BinaryTree<T> leftSubTree, BinaryTree<T> rightSubTree)
		{
			this.value = value;
			this.leftSubTree = leftSubTree;
			this.rightSubTree = rightSubTree;
		}

		BinaryTree<T> getChild(Side side) 
		{
			if (side == Side.LEFT)
				return leftSubTree;

			if (side == Side.RIGHT)
				return rightSubTree;

			return null;
		}

		BinaryTree<T> setChild(Side side, BinaryTree<T> child)
		{
			if (side == Side.LEFT)
				leftSubTree = child;
			else if (side == Side.RIGHT)
				rightSubTree = child;
			else
				return null;

			return child;
		}

		Side getChildSide(BinaryTree<T> child)
		{
			if (leftSubTree == child)
				return Side.LEFT;

			if (rightSubTree == child)
				return Side.RIGHT;

			return null;
		}

		public IEnumerator GetEnumerator()
		{
			return null;
		}

		public BinaryTree<T> Search(T key)
		{
			int compareResult = key.CompareTo (this.value);

			if (compareResult < 0 && leftSubTree != null)
				return leftSubTree.Search (key);
			
			if (compareResult > 0 && rightSubTree != null)
				return rightSubTree.Search (key);

			if (compareResult == 0)
				return this;

			return null; // value not found
		}

		public BinaryTree<T> GetMinimum() 
		{
			if (leftSubTree == null)
				return this;
			
			return leftSubTree.GetMinimum();
		}

		public BinaryTree<T> GetMaximum()
		{
			if (rightSubTree == null)
				return this;
			
			return rightSubTree.GetMaximum();
		}

		public BinaryTree<T> GetSuccessor()
		{
			if (rightSubTree == null)
				return null;

			return rightSubTree.GetMinimum();
		}

		public BinaryTree<T> GetPredecessor()
		{
			if (leftSubTree == null)
				return null;
			
			return leftSubTree.GetMaximum();
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
			if (getChild (side) != null)
				return this.getChild(side).Insert(newValue);
			
			this.setChild (side, new BinaryTree<T> (newValue, null, null));

			return this;
		}

		public BinaryTree<T> Delete(T key)
		{
			int compareResult = key.CompareTo (this.value);

			if (compareResult == 0)
				return this.DeleteMyValue ();

			if (leftSubTree == null && rightSubTree == null)
				return null;

			if (compareResult < 0 && leftSubTree != null) 
				this.leftSubTree = leftSubTree.Delete (key);

			if (compareResult > 0 && rightSubTree != null) 
				this.rightSubTree = rightSubTree.Delete (key);

			return this;
		}

		protected BinaryTree<T> DeleteMyValue()
		{
			if (this.leftSubTree == null)
				return this.rightSubTree;

			if (this.rightSubTree == null)
				return this.leftSubTree;

			BinaryTree<T> replacementOfDeleted = this.rightSubTree.GetMinimum ();

			// copy the key to be substituted
			BinaryTree<T> result = new BinaryTree<T> (replacementOfDeleted.value, 
								                       this.leftSubTree, 
														this.rightSubTree);

			// delete recursively the key used for the substitutio from the right subtree
			result.rightSubTree.Delete (replacementOfDeleted.value);

			return result;
		}
	}
}

