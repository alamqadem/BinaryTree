using System;

namespace MidTerm
{
	public class Interval : IComparable
	{
		readonly int low;
		readonly int high;

		public Interval (int low, int high)
		{
			this.low = low;
			this.high = high;
		}

		public int CompareTo(Object other)
		{
			if (other == null)
				throw new ArgumentException ("Cannot compare with null object");

			Interval otherInterval = other as Interval;
			if (otherInterval == null)
				throw new ArgumentException ("Cannot compare with not Interval object");

			if (this.low == otherInterval.low)
				return this.high - otherInterval.high;

			return this.low - otherInterval.low;
		}

		public bool Intersects(Interval interval)
		{
			return this.high >= interval.low && interval.high >= this.low;
		}
	}
}