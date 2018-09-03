using System.Collections.Generic;
using System.Linq;

namespace SchrodyWebApp.Extensions
{
	public static class ArrayExtensions
	{
		/// <summary>
		/// Splits an array into several smaller arrays.
		/// </summary>
		/// <typeparam name="T">The type of the array.</typeparam>
		/// <param name="array">The array to split.</param>
		/// <param name="size">The size of the smaller arrays.</param>
		/// <returns>An array containing smaller arrays.</returns>
		public static IEnumerable<IEnumerable<T>> Split<T>(this T[] array, int size)
		{
			for (var i = 0; i < (float) array.Length / size; i++)
			{
				yield return array.Skip(i * size).Take(size);
			}
		}

		public static IEnumerable<T> SwapRowsAndColumns<T>(this T[] array)
		{
			int len = array.Length;
			int mid = len / 2;
			for (int i = 0; i < mid; ++i)
			{
				yield return array[i];
				if (i + mid < len)
					yield return array[i + mid];
			}
		}
	}
}
