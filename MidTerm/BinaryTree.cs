using System;
using System.Collections;
using System.Collections.Generic;

namespace MidTerm
{
	public abstract class BinaryTree<T> : ICollection
		where T : IComparable<T>
	{
		public readonly static BinaryTree<T> EMPTY = new EmptyBinaryTree<>();

		/**
		 * Return the value in the root of the tree
		 **/
		abstract public T GetValue ();

		/**
		 * Insert the key in the tree and return the modified tree
		 **/
		abstract public BinaryTree<T> Insert(T key);

		/**
		 * Delete the key from the tree and return the modified tree
		 **/
		abstract public BinaryTree<T> Delete(T key);

		/**
		 * Search the key in the tree and return the set of trees
		 * that the kay as the value of the root
		 **/
		abstract public ISet<T> Search(T key);

		/**
		 * Find and return the tree whose root value is the minimum
		 * in the treee
		 **/
		abstract public BinaryTree<T> GetMinimum ();
		 
		/**
		 * Find and return the tree whose root value is the maximum
		 * in the tree
		 **/
		abstract public BinaryTree<T> GetMaximum ();

		/**
		 * Find and return the tree whose root value is the immediate predecessor 
		 * of the value of this tree
		 **/
		abstract public BinaryTree<T> GetPredecessor();

		/**
		 * Find and return the tree whose root value is the immediate successor 
		 * of the value of this tree
		 **/
		abstract public BinaryTree<T> GetSuccessor();
	}
}

