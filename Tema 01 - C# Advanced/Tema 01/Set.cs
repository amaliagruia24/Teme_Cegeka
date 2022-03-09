using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_01
{
    class Set<T> : IEnumerable<T>
    {
        public List<T> List;

        public Set()
        {
            this.List = new List<T>();
        }

        /*
        * Inserts an item in the list.
        */
        public void Insert(T item)
        {
            if (List.Contains(item))
            {
                throw new Exception("Set can not contain duplicate item.");
            } else
            {
                List.Add(item);
            }
        }

        /*
        * Removes an item from the list.
        */
        public void Remove(T item)
        {
            if (!List.Contains(item)) {
                throw new Exception("Can not remove non-existing items.");
            } else
            {
                List.Remove(item);
            }
            
        }

        /*
        * Checks if the item is already in the list.
        */
        public bool Contains(T item) 
        {
            if (List.Contains(item))
            {
                return true;
            }
            return false;
        }

        /*
         * Returns an object of the class Set, containing the concatenation 
         * of two lists.
         */
        public Set<T> Merge(Set<T> other)
        {
            List<T> mergedList = new List<T>();
            mergedList.AddRange(List);
            
            foreach (T item in other)
            {
                mergedList.Add(item);
            }

            Set<T> merged = new Set<T>();
            foreach (T item in mergedList)
            {
                try
                {
                    merged.Insert(item);
                }
                catch (Exception)
                {
                    Console.WriteLine("Duplicates not allowed");
                }
            }

            return merged;


        }

        /*
        * Returns an object of the class Set, containing only items 
        * that meet a condition.
        */
        public Set<T> Filter(Func<T, bool> lambdaFunction)
        {
            Set<T> subset = new Set<T>();
            var filteredList = List.Where(lambdaFunction).ToList();

            foreach (T item in filteredList)
            {
               try
               {
                    subset.Insert(item);
               }
               catch(Exception)
               {
                    Console.WriteLine("Duplicates not allowed.");
               }
            }

            return subset;

        }

        /*
        * Method used to print the items in the current set.
        */
        public void PrintItems()
        {
            foreach (T item in List)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

      
    }
}
