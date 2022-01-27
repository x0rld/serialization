using System.Text.Json;
namespace serialize;
internal class Program
{
    private static void Main(string[] args)
    {
     
        
        Quiz myQuiz = new Quiz();
            Console.WriteLine("se connecter :");
            var username = Console.ReadLine()?.Trim();
            Console.WriteLine("mot de passe :");
            var password = Console.ReadLine();
            if (username == null || password == null)
            {
                Environment.Exit(1);
            }
            //Si l'utilisateur est connecté, on vérifie maintenant s'il s'agit de l'admin ou d'un user.
            if (myQuiz.VerifUser(username, password))
            {
                if (username != "Admin") // User car != admin
                    myQuiz.StartQuiz();
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






