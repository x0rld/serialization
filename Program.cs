using System.Text.Json;
namespace serialize;
internal class Program
{
    private static void Main(string[] args)
    {

        string? username;
        string? password;
        var myQuiz = new Quiz();
        do
        {
            Console.WriteLine("se connecter :");
            username = Console.ReadLine()?.Trim();
            Console.WriteLine("mot de passe :");
            password = Console.ReadLine();
            if (username == null || password == null)
            {
                Environment.Exit(1);
            }
        } while (!myQuiz.VerifUser(username, password));
        //Si l'utilisateur est connecté, on vérifie maintenant s'il s'agit de l'admin ou d'un user.
        if (username != "Admin") // User car != admin
        {
            myQuiz.StartQuiz();
        }
        else // Admin
        {
            myQuiz.DisplayAdminMenu();
        }
    }
}






