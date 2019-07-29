using System;
/*
    Insertion Sort implementation for objects implementing IComprable interface,
    used in a Unity project for demonstration purposes.
*/
public class InsertionSort
{
    // Constructor, sorts the array parameter upon
    // instantiation.
    public InsertionSort(IComparable[] objectsToSort) 
    {
        Sort(objectsToSort);
    }
    public void Sort(IComparable[] objects)
    {
        // To store the object being sorted
        // with each loop iteration.
        IComparable objToSort;
        // Loop through the entire array.
        for (int i = 0; i < objects.Length; i++)
        {
            // Set the secondary itearator to the
            // current index.
            int j = i;
            // Store the element to be sorted.
            objToSort = objects[j];
            // While we are still within the array bounds, and the object
            // we're sorting is less than the object to its left...
            while (j > 0 && objToSort.CompareTo(objects[j - 1]) < 0)
            {    
                // Move every element forward, position to its right
                objects[j] = objects[j - 1];
                // Decrement j as we're traversing the array in reverse.
                j--;
            }
            // We've found the correct position for the object
            // place it and continue iterating through the array
            // through the outer loop.
            objects[j] = objToSort;   
            
        }
    }
}

