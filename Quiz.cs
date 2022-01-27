namespace serialize
{
    internal class Quiz
    {
        private readonly Root _data;

        private bool _isAdmin;

        //Constructeur
        public Quiz()
        {
            Hash.HashIfNotSecure();
            _data = Serializer.Deserialize("databackup.json");
        }

        //Verification de la saisie 
        public bool VerifUser(string user, string pass)
        {
            if (user == string.Empty || pass == string.Empty) 
            {
                Console.WriteLine("Vous n'avez rien saisi.");
                return false;
            }

            foreach (var userItem in _data.Users)
            {
                if (user == userItem.Name || Hash.ComparePAsswordHash(pass,userItem.Password))
                {
                    if (user == "Admin")
                    {
                        _isAdmin = true;
                    }

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
            if (counterOk > 3)
            {
                _data.Result.GoodResult++;
            }

            Console.WriteLine($"vous avez eu {counterOk} bonne réponses sur {counter}");
            Serializer.Serialize(_data, "databackup.json");
        }

        //Affichage du menu pour l'Admin
        public void DisplayAdminMenu()
        {
            if (!_isAdmin)
            {
                Console.WriteLine("vous n'êtes pas admin");
                return;
            }

            Console.WriteLine(
                $"les utilisateurs ont participés à {_data.Result.Participate} questionnaire. {_data.Result.GoodResult} sur {_data.Result.Participate} questionnaire " +
                "on obtenus une note supérieure à la moyenne");
            AddQuestions();
        }

        public void ListQuestions()
        {
            if (!_isAdmin)
            {
                Console.WriteLine("vous n'êtes pas admin");
                return;
            }

            int counter = 0;
            foreach (var question in _data.Questions)
            {
                Console.WriteLine($"{counter}: ${question}");
                counter++;
            }
        }

        private void AddQuestions()
        {
            if (!_isAdmin)
            {
                Console.WriteLine("vous n'êtes pas admin");
                return;
            }

            string? again = string.Empty;
            do
            {
                Console.WriteLine("Taper la question à ajouter");
                var newQuestion = Console.ReadLine()?.Trim();
                var newResponse = string.Empty;
                do
                {
                    Console.WriteLine("Taper la réponse à ajouter (un mot)");
                    newResponse = Console.ReadLine()?.Trim();
                } while (newResponse?.Split(" ").Length > 1);

                if (newQuestion == null || newResponse == null)
                {
                    Console.WriteLine("erreur d'entrée standard");
                    Environment.Exit(1);
                }

                _data.Questions.Add(newQuestion);
                _data.Responses.Add(newResponse);
                Console.WriteLine("questions ajoutée, voulez vous en ajouter encore ? o/n ");
                again = Console.ReadLine()?.Trim();
            } while (again == "o");

            Serializer.Serialize(_data, "databackup.json");
        }
    }
}