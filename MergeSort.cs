using System;
/*
    Merge Sort implementation for objects implementing IComprable interface,
    used in a Unity project for demonstration purposes.
*/
public class MergeSort
{
    // Constructor, sorts the array parameter upon
    // instantitiate.
    public MergeSort(IComparable[] objectsToSort) 
    {
        Sort(objectsToSort);
    }
    // Sort method bifurcates the array parameter and 
    // calls itself recursively.
    public void Sort(IComparable[] objects) 
    {    
        // Cache the array length.
        int arrLen = objects.Length;
        // If there's only one object, left in the array, return.
        if (arrLen < 2)
            return;
        
        // Partioning point of the array.
        int midPoint = arrLen / 2;
        
        // Copy everything from objects[0] to objects[midPoint] into a new array.
        IComparable[] left = new IComparable[midPoint];
        Array.Copy(objects, 0, left, 0, midPoint);

        // Copy everything from objects[midPoint] to objects[objects.Length] into a new array.
        IComparable[] right = new IComparable[objects.Length - midPoint];
        Array.Copy(objects, midPoint, right, 0, arrLen - midPoint);
        
        // Recursively call the sort method on the newly partitioned array halves.
        Sort(left);
        Sort(right);
        // Merge the sorted arrays into one.
        Merge(left, right, objects);
    }
    
    // Merge method combines sorted arrays into single resulting array sorted
    // in descending order.
    void Merge(IComparable[] left, IComparable[] right, IComparable[] merged)
    {
        // Initialize iterators for the left, right, and merged arrays.
        int iLeft = 0;
        int iRight = 0; 
        int iMerge = 0;

        // While we haven't traversed the entirety of at least one of the two sub-arrays...
        while (iLeft < left.Length && iRight < right.Length) {
            // Compare the values at the respective iterator index to find the 
            // smaller value. Copy that value to the result array and increment
            // the iterator for the array whose value we copied.
            // Change comparison to >= of ascending order.
            if (left[iLeft].CompareTo(right[iRight]) <= 0) {
                merged[iMerge] = left[iLeft];
                iLeft++;
            }
            else {
                merged[iMerge] = right[iRight];
                iRight++;
            }
            // For copied value, increment the iterator for
            // the merged array.
            iMerge++;
        }
        // Upon reaching the end of either the left OR right array, copy the remaining values from the array we haven't fully traversed
        // into the merged array. These values are already sorted, so we'll copy everything from the current iterator position, all the way to the end.
        //
        // * Array.Copy is called on both arrays, despite one having been fully traversed. By using the iterator position as the beginning index of the copy, the fully traversed
        // * array will have no values copied over.
        Array.Copy(left, iLeft, merged, iMerge, left.Length - iLeft);
        Array.Copy(right, iRight, merged, iMerge, right.Length - iRight);
    }
    
}

