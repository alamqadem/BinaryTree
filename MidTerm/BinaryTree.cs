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

		ResultAndParent SearchKeyAndParent(T key)
		{
			return this.SearchParentOfAux (key, null);
		}

		struct ResultAndParent {
			public readonly BinaryTree<T> result;
			public readonly BinaryTree<T> parent;

			public ResultAndParent(BinaryTree<T> result, BinaryTree<T> parent)
			{
				this.result = result;
				this.parent = parent;
			}
		}

		ResultAndParent SearchParentOfAux(T key, BinaryTree<T> lastParent)
		{
			int compareResult = key.CompareTo (this.value);

			if (compareResult == 0)
				return new ResultAndParent(this, lastParent);
			
			if (compareResult < 0 && leftSubTree != null)
				return leftSubTree.SearchParentOfAux (key, this);

			if (compareResult > 0 && rightSubTree != null)
				return rightSubTree.SearchParentOfAux (key, this);

			return null;
		}

		bool isChildOf(BinaryTree<T> parent)
		{
			return this == parent.leftSubTree || this = parent.rightSubTree;
		}

		Side getChildSide(BinaryTree<T> child)
		{
			if (leftSubTree == child)
				return Side.LEFT;

			if (rightSubTree == child)
				return Side.RIGHT;

			return null;
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
				return getChild (side).Insert (newValue);
			
			setChild (side, new BinaryTree<T> (newValue, null, null));
			return this;
		}

		BinaryTree<T> DeleteSearch(T key, BinaryTree<T> parent)
		{
			int compareResult = key.CompareTo (this.value);

			if (compareResult == 0)
				return parent.DeleteChild (parent.getChildSide (this));

			if (compareResult < 0 && leftSubTree != null)
				return leftSubTree.DeleteSearch (key, this);

			if (compareResult > 0 && rightSubTree != null)
				return rightSubTree.DeleteSearch (key, this);

			return null;
		}

		BinaryTree<T> DeleteChild(Side sideOfChildToDelete)
		{
			BinaryTree<T> toDelete = this.getChild (sideOfChildToDelete);

			if (toDelete.leftSubTree == null)
				return this.setChild (sideOfChildToDelete, toDelete.rightSubTree);

			if (toDelete.rightSubTree == null)
				return this.setChild (sideOfChildToDelete, toDelete.leftSubTree);

			BinaryTree<T> replacementOfDeleted = toDelete.rightSubTree.GetMinimum ();

			if (
		}

		public BinaryTree<T> Delete(T key)
		{
			ResultAndParent searchRes = SearchKeyAndParent (key);

			BinaryTree<T> toDelete = searchRes.result;
			BinaryTree<T> parentOfDeleted = searchRes.parent;

			if (toDelete.leftSubTree == null)
				parentOfDeleted.setChild( parentOfDeleted.ge
				

			return null;
		}
			
	}
}

