using ConsoleApp.Services;

var menu = new Menu();
menu.FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";

Console.WriteLine("**************************");
Console.WriteLine("Välkommen till Adressboken ");
Console.WriteLine("**************************");
Console.WriteLine();

while (true)
{
    menu.WelcomeMenu();
}