using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serialize
{
    internal class Quiz
    {
        private string _username;
        public string Username { get { return _username; } set { _username = value; } }
        private string _password;
        public string Password { get { return _password; } set { _password = value; } }

        //Constructeur
        public Quiz(string user, string password)
        {
            Username = user;
            Password = password;
        }

        //Verification de la saisie 
        public bool VerifUser(string user, string pass)
        {
            Console.WriteLine(user);
            Console.WriteLine(pass);
            if (user == "" || pass == "") // Vide
            {
                Console.WriteLine("Vous n'avez rien saisi.");
                return false;
            }
            else if (user != Username || pass != Password) 
            {
                Console.WriteLine("Mauvais identifiant ou mot de passe");
                return false;
            }
            else
            {
                Console.WriteLine("connecté");
                return true;
            }
        }

        // Affichage du Quiz
        public void DisplayQuiz()
        {
            Console.WriteLine("Début du quiz");

        }
        //Affichage du menu pour l'Admin
        public void DisplayAdminMenu()
        {
            string userAnswer;
            Console.WriteLine("Voulez vous ouvrir un questionnaire? (o/n)");
            userAnswer = Console.ReadLine();
            while(userAnswer != "o" || userAnswer != "n")
            {
                Console.WriteLine("Nous n'avons pas comprix votre choix");
                userAnswer = Console.ReadLine();
            }
        /*    if (userAnswer == "o")
                DisplayAdminListQuiz();*/
        }


        //Affichage de la liste des questionnaires.
   /*     public void DisplayAdminListQuiz()
        {
            //Liste

            Console.WriteLine("Voulez")
        }
   */



    }
}
