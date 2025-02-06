// See https://aka.ms/new-console-template for more information
Console.WriteLine("PLaying with integers and discovering doubles & floats");
double coolDouble = 3.14d;
//int coolInt = coolDouble; // This will not work
int coolInt = (int)coolDouble; // This will work
Console.WriteLine($"coolDouble: {coolDouble}");
Console.WriteLine($"coolInt: {coolInt}");
//Learned that casting is made with (type)variableName

int coolInt2 = 5;
int coolInt3 = 10;
int quotient = coolInt2 / coolInt3;
Console.WriteLine($"coolInt2 / coolInt3 = {quotient}");
//Learned that in interger calculs, the result is trimed to lowest decimal if the result is a decimal.

double coolDouble2 = 5f;
//Its possible to cast a float into a double, its impossible to cast a double into a float

//float coolFloat2 = 5d;

//This wont work.

double coolDouble5 = 10;

//Important:
//If you want to divide two integers and get a double, you need to cast one of the integers to a double Or use variables names as i guess the compiler uses the types of the variables to guess the return type.
//This will work
double result = coolDouble2 / coolDouble5;
Console.WriteLine($"coolDouble3 / coolDouble4 = {result}");

//This wont work (the result will be trimed
double result2 = 5 / 10;
Console.WriteLine($"5 / 10 = {result2}");

//This will work because i casted one of the two integers to a double so the result returned is automatically casted into a double.
double result3 = 5d / 10;
Console.WriteLine($"5 / 10 = {result3}");


//This will work because i casted one of the two integers to a double and the second one to a float, as the float can be casted to double this is fine..
double result4 = 5f / 10d;
Console.WriteLine($"5f / 10d = {result4}");

//This will not work because i casted one of the two integers to a double the double cannot be casted to a float. I guess the return type is the biggest one of the two.(int64/double)
//float result5 = 5f / 10d;
//Console.WriteLine($"5f / 10d = {result5}");
