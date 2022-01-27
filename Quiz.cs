using System.Text.Json;

namespace serialize;

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
        int counter = 0;
        int counterOk = 0;
        var userResponses = new List<string>();
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
        if (counterOk > 3)
        {
            _data.Result.GoodResult++;
        }
        _data.UserResponses.Add(userResponses);
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
    }

    private void DisplayUserResponsesList()
    {
        if (!_isAdmin)
        {
            Console.WriteLine("vous n'êtes pas admin");
            return;
        }
        var counter = 0;
        foreach (var userResponse in _data.UserResponses)
        {
            Console.WriteLine("questionnaire " + counter);
        }
        Console.WriteLine("écrire le numéro du questionnaire à afficher");
        var numberString = Console.ReadLine()?.Trim();
        if (int.TryParse(numberString, out var number))
        {
            Console.WriteLine("les réponses sont: ");
            foreach (var data in _data.UserResponses[number])
            {
                Console.WriteLine($"{data}");
            }
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