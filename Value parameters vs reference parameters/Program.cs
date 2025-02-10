
//Passing value parameters only pass the value of the variable.
//This means that the original variable is not changed.
//Demo below:

Console.WriteLine("This is a demo of value parameters vs reference parameters");
Console.WriteLine("This shows that passing value parameters by VALUE in a method DOES NOT change the original variable");

//Declaring a string in the global scope
string myString = "Hello world!";
//Modifying the string in a method
void DoSomething(string myString)
{
    //This is not the global scope
    //This is a local scope
    //The global variable myString will not be changed
    myString = "Goodbye world!";
}

//Printing the myString's value before and after the method call
Console.WriteLine("Before: " + myString);
DoSomething(myString);
Console.WriteLine("After: " + myString);
//The two outputs will be the same:
//Before: Hello world!
//After: Hello world!


Console.WriteLine("This shows that passing value parameters by REFERENCE in a method DO change the original variable");
//Now let's learn how to pass them by reference!
//(This is done by using the ref keyword)
//This will allow us to modify the original variable
//Demo below:

//Declaring a string in the global scope
string myNewString = "Hello world!";

//Declaring a method that takes a string by reference

void DoSomethingByReference(ref string myNewString)
{
    //this is a local scope
    //but because we passed the variable by reference
    //the variable in the global scope will be changed
    myNewString = "Goodbye world!";
}

//Printing the myNewString's value before and after the method call
Console.WriteLine("Before: " + myNewString);
DoSomethingByReference(ref myNewString);
Console.WriteLine("After: " + myNewString);
//The two outputs will be different:
//Before: Hello world!
//After: Goodbye world!

//Protip: remember the ref keyword. It must be added to the declaration of the method AND to the call of the method.