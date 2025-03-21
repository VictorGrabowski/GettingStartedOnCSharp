// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
// int number = 8;
// switch (number) {

//Pas besoin de break partout dans ce cas là
switch(1){
    //Possibilité de rentrer dans un case via plusieurs valeurs du switch en les empilants
    case 1:
    case 2:
        Console.WriteLine("One or two");
        break;
    case 3:
        Console.WriteLine("three");
    case 4:
        Console.WriteLine("four");
        //Ici , Sans break, Le code ne compile que si la valeur dans le switch n'as aucune chance de rentrer dans le case.
    case 8:
        Console.WriteLine("eight");
        break;
    //Le code compilera dans ce cas là car on a un break dans une valeur possible du switch case.
    default:
        Console.WriteLine("Valeur par défaut");
}
//Pas besoin de "default" case, si on n'entre dans aucun des cases, ça ne pose pas de soucis.
string dayOfTheWeek = "Dimanche";
string DayPhrase = dayOfTheWeek switch
{
    "Vendredi" => "Nous sommes vendredi",
    "Samedi" => "Le temps est bon",
    "Dimanche" => "Le ciel est bleu",
    _ => "Je sais pas quel jour on est"
};

//J'ai appris qu'on était pas obligé de mettre une valeur possible "_".
//Si on n'en met pas:
//ça ne souligne pas d'erreur dans le linter reSharper, et pourtant ça soulève une erreur lors de l'execution (après la compilation).
//Si on en met une:
//ça compile sans soucis et lorsqu'on sort du switch, si la valeur de dayOfTheWeek est trouvée dans le switch, ça retourne la valeur à sa droite, sinon, la valeur à droite de "_".
Console.WriteLine("DayPhrase pour "+ dayOfTheWeek+ " : " + DayPhrase);