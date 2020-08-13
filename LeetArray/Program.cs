using System;
using System.Collections.Generic;


namespace LeetArray
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] nums1 = new int[] { -4, -1, 0, 3, 10 };
      SortArrayByParity(nums1);
      Console.WriteLine(string.Join("  ", nums1));
    }

    public static int[] SortedSquares(int[] A)
    {
      if (A == null || A.Length == 0) return null;

      int left = 0;
      int right = A.Length - 1;
      int index = A.Length - 1;
      while (left < right)
      {
        if (Math.Abs(A[left]) < Math.Abs(A[right]))
        {
          A[index] = A[right] * A[right];
          right--;
        }
        else
        {
          A[index] = A[left] * A[left];
          left++;
        }
        index--;
      }



      return A;
    }

    public static int[] SortArrayByParity(int[] A)
    {
      int fast = 0, slow = 0;
      while (fast < A.Length)
      {
        if (A[fast] % 2 == 0)
        {
          int temp = A[slow];
          A[slow] = A[fast];
          A[fast] = temp;
        }
        if (A[slow] % 2 == 0) { slow++; }

        fast++;
      }
      return A;
    }

    public static void MoveZeroes(int[] nums)
    {
      int fast = 0, slow = 0;
      while (fast < nums.Length)
      {

        if (nums[fast] != 0)
        {
          int temp = nums[slow];
          nums[slow] = nums[fast];
          nums[fast] = temp;
        }
        if (nums[slow] != 0) { slow++; }


        fast++;
      }
    }
    public static int[] ReplaceElements(int[] arr)
    {

      int max = -1;
      int a = 0;
      for (int index = arr.Length - 1; index >= 0; index--)
      {
        a = arr[index];
        arr[index] = max;
        if (max < a) max = a;
      }


      return arr;
    }


    public static bool ValidMountainArray(int[] A)
    {
      if (A.Length <= 2) return false;
      int i = 0;
      int j = A.Length - 1;
      while (i < j)
      {
        if (A[i + 1] > A[i]) i++;
        else if (A[j - 1] > A[j]) j--;
        else break;
      }
      return i != 0 && j != A.Length - 1 && i == j;
    }

    public static bool CheckIfExistSet(int[] arr)
    {
      HashSet<int> numbers = new HashSet<int>();
      foreach (int a in arr)
      {
        if (numbers.Contains(a * 2) || (a % 2 == 0 && numbers.Contains(a / 2))) return true;
        numbers.Add(a);
      }
      return false;
    }

    public static bool CheckIfExist(int[] arr)
    {
      if (arr.Length < 2 || arr.Length > 500) return false;
      for (int x = 0; x < arr.Length; x++)
      {
        for (int j = x + 1; j < arr.Length; j++)
        {
          if (arr[x] == 2 * arr[j] || arr[j] == 2 * arr[x])
          {
            return true;
          }
        }
      }
      return false;
    }
    public static void MergeSorted(int[] nums1, int m, int[] nums2, int n)
    {
      int i = 0, j = 0, k = 0;
      while (i < nums1.Length && j < nums2.Length)
      {
        if (nums2[j] < nums1[j])
        {
          nums1[k] = nums2[j];
        }
      }


    }

    public static int RemoveDuplicates(int[] nums)
    {
      int length = 1;
      for (int index = 1; index < nums.Length; index++)
      {
        if (nums[index - 1] != nums[index])
        {
          nums[length] = nums[index];
          length++;
        }
      }


      return length;
    }

    public static int RemoveElement(int[] nums, int val)
    {
      int length = nums.Length;
      for (int x = nums.Length - 1; x >= 0; x--)
      {
        if (nums[x] == val)
        {

          ShiftLeft(nums, x);
          length--;
        }


      }


      return length;
    }

    public static void ShiftLeft(int[] nums, int position)
    {
      if (position != nums.Length - 1)
      {
        for (int i = position + 1; i < nums.Length; i++)
        {
          // Shift each element one position to the left
          nums[i - 1] = nums[i];
        }

      }
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

