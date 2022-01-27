using System.Text.Json;
namespace serialize;
internal class Program
{
    private static void Main(string[] args)
    {
        string username;
        string password;
        Quiz myQuiz = new Quiz();
            Console.WriteLine("se connecter :");
            username = Console.ReadLine();
            Console.WriteLine("mot de passe :");
            password = Console.ReadLine();
            bool isconnected = myQuiz.VerifUser(username, password);
            //Si l'utilisateur est connecté, on vérifie maintenant s'il s'agit de l'admin ou d'un user.
            if (isconnected)
            {
                if (username != "Admin") // User car != admin
                    myQuiz.DisplayQuiz();
                else // Admin
                {
                    myQuiz.DisplayAdminMenu();
                }
            }
        /*
         *    Root data = Serializer.Deserialize(string path);
         *    data.Users pout les utilisateurs
         * Menu/mdp 
         */
    }

    //Affichage du menu




}






