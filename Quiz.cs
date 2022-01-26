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

        public Quiz(string user, string password)
        {
            Username = _username;
            Password = _password;
        }




        //Verification de la saisie 
        public bool VerifUser(string user, string pass)
        {
            if (user == "" || pass == "")
            {
                Console.WriteLine("Vous n'avez rien saisi.");
                return false;
            }
            else if (user != Username || pass != Password)
            {
                Console.WriteLine("Mauvais identifiant ou mot de passe");
                return false;
            }
            else return true;
        }

        public void DisplayQuiz()
        {

        }
            
       

    }
}
