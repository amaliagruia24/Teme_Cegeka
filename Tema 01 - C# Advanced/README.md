# Tema 01 - C# Advanced

In this homework, I implemented the Set collection using generics. The main property of a set is that it doesn't contain duplicates. I made a class for creating set objects, this class is Set.cs. For creating a set, I used a list of generics as a class field. All the operations were done using this list, but making sure the set's property is handled. The class Set implements the interface IEnumerable to support the use of foreach, we need it to iterate through the collection. 

Here are some of the class methods: Insert, Remove, Merge, Filter, Contains and PrintItems. I used the Insert and the Remove methods to add/remove a specific element, given as a parameter. The Merge method is used to concatenate to my set another set. Also, the Filter method takes as a parameter a lambda function and returns a subset of the current instance of the Set class, all element having a specific property given by the lambda function.

To make sure that the set doesn't contain duplicates, I used exceptions. For example, everytime we try to add an item that already exists or try to remove an element not existing in the list, an exception is thrown. This exception is catched in the Main method, of the Program.cs file, where the methods are used.

In the Main method, I created objects of the newly created class Set and tested all the implemented methods to make sure everything works fine. I also tested the cases where exceptions were thrown.
