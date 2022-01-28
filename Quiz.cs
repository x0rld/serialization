using serialize.JSON;
namespace serialize;

internal class Quiz
{
    private readonly Root _data;

    private bool _isAdmin;

    public Quiz()
    {
        Hash.HashIfNotSecure();
        _data = Serializer.Deserialize("databackup.json");
    }

    public bool VerifUser(string user, string pass)
    {
        if (user == string.Empty || pass == string.Empty)
        {
            Console.WriteLine("Vous n'avez rien saisi.");
            return false;
        }
        // Comparaison entre les données du json et les données rentrées par l'utilisateur
        if (_data.Users.Any(userItem => user == userItem.Name ||
                                        Hash.ComparePAsswordHash(pass, userItem.Password)))
        {
            if (user == "Admin")
            {
                _isAdmin = true;
            }

            Console.WriteLine("connecté");
            return true;
        }

        Console.WriteLine("identifiants incorrects");
        return false;
    }

    public void StartQuiz()
     {
         Console.WriteLine("Début du quiz");
         var counter = 0;
         var counterOk = 0;
         var userResponses = new List<string>();
         foreach (var question in _data.Questions)
         {
             Console.WriteLine(question);
             var response = Console.ReadLine()?.Trim();
             if (response == null) Environment.Exit(1);
 
             if (response.ToUpper().Contains(_data.Responses[counter].ToUpper()))
             {
                 userResponses.Add(response);
                 counterOk++;
                 Console.Clear();
             }
             else
             {
                 userResponses.Add(response);
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
         _data.UserResponses.Add(userResponses);
         Console.WriteLine($"vous avez eu {counterOk} bonne réponses sur {counter}");
         Serializer.Serialize(_data,"databackup.json");
    }

        public void DisplayAdminMenu()
        {
            if (!_isAdmin)
            {
                Console.WriteLine("vous n'êtes pas admin");
                return;
            }
            Console.WriteLine($"les utilisateurs ont participés à {_data.Result.Participate} questionnaire." +
                              $" {_data.Result.GoodResult} sur {_data.Result.Participate} questionnaire " +
                             "on obtenus une note supérieure à la moyenne");
            Console.WriteLine("Voulez vous ouvrir un questionnaire? (o/n)");
            var userAnswer = Console.ReadLine()?.Trim();
            if (userAnswer == "o")
            {
                DisplayUserResponsesList();
            }
            else
            {
                Console.WriteLine("Tapez A pour ajouter des questions, D pour supprimer des questions");
                userAnswer = Console.ReadLine()?.Trim();
                if (userAnswer == "D")
                    RemoveQuestion();
                else if (userAnswer == "A")
                   AddQuestions();   
            }
        }

    private void DisplayUserResponsesList()
    {
        if (!_isAdmin)
        {
            Console.WriteLine("vous n'êtes pas admin");
            return;
        }
        var counter = 0;
        foreach (var _ in _data.UserResponses)
        {
            Console.WriteLine("questionnaire " + counter);
            counter++;
        }
        int number;
        do
        {
            Console.WriteLine("écrire le numéro du questionnaire à afficher");
        } while (!int.TryParse(Console.ReadLine(), out number) && number <= counter);
        Console.WriteLine("les réponses sont: ");
            foreach (var data in _data.UserResponses[number])
            {
                Console.WriteLine($"{data}");
            }
    }
    
    private void AddQuestions()
    {
        if (!_isAdmin)
        {
            Console.WriteLine("vous n'êtes pas admin");
            return;
        }
        string? again;
        do
        {
            Console.WriteLine("Taper la question à ajouter");
            var newQuestion = Console.ReadLine()?.Trim();
            string? newResponse;
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
    
    private void RemoveQuestion()
    {
        var counter = 0;
        foreach (var question in _data.Questions)
        {
            counter++;
            Console.WriteLine($"{counter} {question}");
        }
        int number;
        do
        {
            Console.WriteLine("Saisissez le numéro de la supprimer.");
        } while (!int.TryParse(Console.ReadLine(),out number) && number <= counter );
        _data.Questions.RemoveAt(number - 1);
        _data.Responses.RemoveAt(number - 1);
        Serializer.Serialize(_data, "databackup.json");
    }
}   