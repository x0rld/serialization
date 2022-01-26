using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serialize
{
    internal class Quiz
    {
        private readonly Root _data;
        //Constructeur
        public Quiz()
        {
            _data = Serializer.Deserialize("databackup.json");
        }
        //Verification de la saisie 
        public bool VerifUser(string user, string pass)
        {
            if (user == string.Empty || pass == string.Empty) // Vide
            {
                Console.WriteLine("Vous n'avez rien saisi.");
                return false;
            }

            foreach (var userItem in _data.Users)
            {
                if (user == userItem.Name || pass == userItem.Password) 
                {
                    Console.WriteLine("connecté");
                    return true;
                }
            }
            Console.WriteLine("identifiants incorrects");
            return false;
        }

        // Affichage du Quiz
        public void DisplayQuiz()
        {
            Console.WriteLine("Début du quiz");
            int counter = 0;
            int counterOk = 0;
            foreach (var question in _data.Questions)
            {
                Console.WriteLine(question);
                var response = Console.ReadLine()?.Trim();
                if (response == null)
                {
                    Environment.Exit(1);
                }
                if (response.ToUpper().Contains(_data.Responses[counter].ToUpper()))
                {
                    counterOk++;
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("erreur question fausse");
                }
                counter++;
            }

            _data.Result.Participate++;
            if (counterOk>3)
            {
                _data.Result.GoodResult++;
            }
            Console.WriteLine($"vous avez eu {counterOk} bonne réponses sur {counter}");
            Serializer.Serialize(_data,"databackup.json");
        }
        //Affichage du menu pour l'Admin
        public void DisplayAdminMenu()
        {
            string userAnswer;
            Console.WriteLine("Voulez vous ouvrir un questionnaire? (o/n)");
            userAnswer = Console.ReadLine();
            Console.WriteLine($"les utilisateurs ont participés à {_data.Result.Participate} questionnaire. {_data.Result.GoodResult} sur {_data.Result.Participate} questionnaire " +
                              "on obtenus une note supérieure à la moyenne");
            //TODO list quizz, edit, delete
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
