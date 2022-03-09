using System;


namespace Tema_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Set<int> mySet = new Set<int>();
            Set<int> merged = new Set<int>();
            Set<int> filtered = new Set<int>();

            try
            {
                mySet.Insert(1);
                mySet.Insert(2);
                mySet.Insert(3);
                mySet.Insert(4);
                mySet.Insert(5);
                mySet.Insert(3);
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + '\n');
            }
            
            Console.WriteLine("After creating the set: ");
            mySet.PrintItems();

            try
            {
                mySet.Remove(1);
                mySet.Remove(6);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + '\n');
            }
          
            Console.WriteLine("After removing: ");
            mySet.PrintItems();
            

            if (mySet.Contains(1))
            {
                Console.WriteLine("Yes, the list contains 1.");
            } else
            {
                Console.WriteLine("No, the list does not contain 1. ");
            }

            try
            {
                Set<int> anotherSet = new Set<int>();
                anotherSet.Insert(7);
                anotherSet.Insert(2);
                anotherSet.Insert(8);

                merged = mySet.Merge(anotherSet);
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine("Merged list is: ");
            merged.PrintItems();
            


            filtered = mySet.Filter(x => x > 3);
            Console.WriteLine("Filtered list is: ");
            filtered.PrintItems();


        }
    }

}


