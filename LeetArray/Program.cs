using System;

namespace LeetArray
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] nums1 = new int[] { 0 };
      int[] nums2 = new int[15];


      // Merge(nums1, nums1.Length, nums2, nums2.Length);
      // Console.WriteLine(string.Join("\n", nums1));
      Console.WriteLine(nums2.Length);



    }

    public static void Merge(int[] nums1, int m, int[] nums2, int n)
    {
      if (nums2.Length == 0)
      {
        return;
      }
      if (nums1.Length == 1)
      {
        nums1[0] = nums2[0];
        return;
      }
      nums2.CopyTo(nums1, nums2.Length);
      mergeSort(nums1, new int[nums1.Length], 0, nums1.Length - 1);

    }

    public static void mergeSort(int[] array, int[] temp, int leftStart, int rightEnd)
    {
      if (leftStart >= rightEnd) return;

      int middle = (leftStart + rightEnd) / 2;

      mergeSort(array, temp, leftStart, middle);
      mergeSort(array, temp, middle + 1, rightEnd);
      mergeHalves(array, temp, leftStart, rightEnd);

    }

    public static void mergeHalves(int[] array, int[] temp, int leftStart, int rightEnd)
    {
      int leftEnd = (rightEnd + leftStart) / 2;
      int rightStart = leftEnd + 1;
      int size = rightEnd - leftStart + 1;

      int left = leftStart;
      int right = rightStart;
      int index = leftStart;

      while (left <= leftEnd && right <= rightEnd)
      {
        if (array[left] <= array[right])
        {
          temp[index] = array[left];

          left++;
        }
        else
        {
          temp[index] = array[right];
          right++;
        }
        index++;
      }

      Array.Copy(array, left, temp, index, leftEnd - left + 1);
      Array.Copy(array, right, temp, index, rightEnd - right + 1);
      Array.Copy(temp, leftStart, array, leftStart, size);

    }

    public static void Shift(int[] arr, int start)
    {
      for (int i = arr.Length - 1; i > start; i--)
      {
        arr[i] = arr[i - 1];
      }
    }



    public static void DuplicateZeros(int[] arr)
    {
      int zero = 0;

      foreach (int element in arr)
      {
        if (element == 0) zero++;
      }

      for (int i = arr.Length - 1, j = arr.Length + zero - 1; i < j; --i, --j)
      {

        if (j < arr.Length) arr[j] = arr[i];
        if (arr[i] == 0)
          if (--j < arr.Length) arr[j] = arr[i];

      }

    }

    public static int[] sortedSquares(int[] A)
    {
      if (A == null || A.Length == 0) return null;
      int l = 0;
      int r = A.Length - 1;
      int[] result = new int[A.Length];
      int index = A.Length - 1;
      while (l <= r)
      {
        if (Math.Abs(A[l]) < Math.Abs(A[r]))
        {
          result[index] = A[r] * A[r];
          r--;
        }
        else
        {
          result[index] = A[l] * A[l];
          l++;
        }

        index -= 1;
      }


      return result;
    }

    public static int FindNumbers(int[] nums)
    {
      int sum = 0;
      foreach (int number in nums)
      {
        if ((Math.Floor(Math.Log10(number) + 1) % 2) == 0) sum += 1;

      }
      return sum;
    }



    public static int findMax(int[] nums)
    {
      int max = 0;
      int sum = 0;
      foreach (int element in nums)
      {
        if (element == 1) sum += 1;
        else sum = 0;
        if (sum > max) max = sum;


      }

      return max;
    }

  }



  public class DVD
  {
    public string name;
    public int releaseYear;
    public string director;

    public DVD(string name, int releaseYear, string director)
    {
      this.name = name;
      this.releaseYear = releaseYear;
      this.director = director;
    }

    public override string ToString()
    {
      return this.name + ", directed by " + this.director + ", realeased in " + this.releaseYear;
    }
  }
}

