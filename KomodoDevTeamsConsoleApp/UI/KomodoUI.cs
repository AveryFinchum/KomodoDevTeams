using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeamsConsoleApp.UI
{
    internal class Program
    {
        //private readonly StreamingContentRepository _repo = new StreamingContentRepository();
        private readonly KomodoConsole _console;

        public Program(IConsole console) => _console = console;


        public void Run()
        {
            SeedContent();
            _console.startUp();
            RunMenu();
        }

        private void SeedContent()
        {
            _console.Clear();
            if(_console.BoolQuestion("Would you like to start the repositories with seed content?"))
            {
                //seedContent();
            }
        }

        private void RunMenu()
        {

            bool continueToRun = true;
            while (continueToRun)
            {
                _console.Clear();
                _console.WriteLine("Enter the number of the option you would like\n" +
                    "1. Show all Conternt \n" +
                    "2. Get content by title\n" +
                    "3. Get content by minimum star rating\n" +
                    "4. Add content to directory\n" +
                    "5. Update conternt in directory\n" +
                    "6. Remove conternt in directory\n" +
                    "7. Exit");

                string userInput = _console.ReadLine();
                switch (userInput)
                {
                    case "1"://ShowAllContent();
                    case "show":
                        ShowAllContent();
                        break;
                    case "2"://GetContentByTitle();
                        GetContentByTitle();
                        break;
                    case "3":
                        GetContentByMinimumStarRating();
                        break;
                    case "4":
                        AddContent();
                        break;
                    case "5":
                        UpdateContent();
                        break;
                    case "6":
                        RemoveContent();
                        break;
                    case "7":
                    case "e":
                    case "exit":
                        continueToRun = false;
                        break;
                    default:
                        _console.WriteLine("Please enter a valid number between 1 and 7:");
                        KomodoConsole.ReadKey();
                        break;
                }
            }
        }

        private void AddContent()
        {
            _console.Clear();

            StreamingContent content = new StreamingContent();

            //Title
            _console.Write("Please enter a title: ");
            content.Title = _console.ReadLine();

            //Description
            _console.Write("Please enter a descritpion: ");
            content.Description = _console.ReadLine();

            //Stars
            _console.Write("Please enter a Star Rating: ");
            content.StarRating = double.Parse(_console.ReadLine());

            //Maturity
            _console.WriteLine("Select maturity rating:\n" +
            "1.  G\n" +
            "2.  PG\n" +
            "3.  PG13\n" +
            "4.  R\n" +
            "5.  NC_17\n" +
            "6.  TV_Y\n" +
            "7.  TV_G\n" +
            "8.  TV_PG\n" +
            "9.  TV_14\n" +
            "10. TV_MA");
            string stringRating = _console.ReadLine();
            content.MaturityRating = (MaturityRating)int.Parse(stringRating);

            //Genre
            _console.WriteLine("Select a Genre:\n" +
                "1. Horror" +
                "2. Drama" +
                "3. Fantasy" +
                "4. Action" +
                "5. Comedy" +
                "6. SciFi" +
                "7. Romance");

            string genreInput = _console.ReadLine();
            int genreID = int.Parse(genreInput);

            content.GenereType = (GenereType)genreID;

            if (_repo.AddContentToDirectory(content))
            {
                _console.WriteLine("Success!");
                _console.ReadKey();
            }
            else
            {
                _console.WriteLine("big fail...");
                _console.ReadKey();
            }

        }

        private void ShowAllContent()
        {
            _console.Clear();
            List<StreamingContent> listOfContent = _repo.GetContents();
            foreach (StreamingContent content in listOfContent)
            {
                DisplayContent(content);
            }
            AnyKey();
        }

        private void GetContentByTitle()
        {
            _console.Clear();
            _console.Write("enter a title: ");

            string title = _console.ReadLine();
            StreamingContent content = _repo.GetContentByTitle(title);
            if (content != null)
            {
                DisplayContent(content);
            }
            else
            {
                _console.WriteLine("Couldnt find any content by that title.");
            }
            AnyKey();
        }
        private void GetContentByMinimumStarRating()
        {
            _console.Clear();
            _console.WriteLine("Please enter a minimum star rating: ");
            string ratingRaw = _console.ReadLine();
            double rating = double.Parse(ratingRaw);
            List<StreamingContent> listOfContent = _repo.GetStarRatingMyMinimum(rating);
            foreach (StreamingContent content in listOfContent)
            {
                DisplayContent(content);
            }
            AnyKey();
        }

        private void UpdateContent()
        {
            _console.Clear();
            _console.WriteLine("Please enter the title of the movie you wish to update: ");
            StreamingContent oldContent = _repo.GetContentByTitle(_console.ReadLine());

            if (oldContent != null)
            {
                //Title
                _console.Write("Please enter a title: ");
                string title = _console.ReadLine();
                if (title != "")
                    oldContent.Title = title;

                //Description
                _console.Write("Please enter a descritpion: ");
                string disc = _console.ReadLine();
                if (disc != "")
                    oldContent.Description = disc;
                //Stars
                _console.Write("Please enter a Star Rating: ");
                string star = _console.ReadLine();
                if (star != "")
                    oldContent.StarRating = double.Parse(star);


                //Maturity
                _console.WriteLine("Select maturity rating:\n" +
                "1.  G\n" +
                "2.  PG\n" +
                "3.  PG13\n" +
                "4.  R\n" +
                "5.  NC_17\n" +
                "6.  TV_Y\n" +
                "7.  TV_G\n" +
                "8.  TV_PG\n" +
                "9.  TV_14\n" +
                "10. TV_MA");
                string stringRating = _console.ReadLine();
                if (stringRating != "")
                    oldContent.MaturityRating = (MaturityRating)int.Parse(stringRating);

                //Genre
                _console.WriteLine("Select a Genre:\n" +
                    "1. Horror" +
                    "2. Drama" +
                    "3. Fantasy" +
                    "4. Action" +
                    "5. Comedy" +
                    "6. SciFi" +
                    "7. Romance");

                string genreInput = _console.ReadLine();
                int genreID = int.Parse(genreInput);

                oldContent.GenereType = (GenereType)genreID;

                if (_repo.AddContentToDirectory(oldContent))
                {
                    _console.WriteLine("Success!");
                    _console.ReadKey();
                }
                else
                {
                    _console.WriteLine("big fail...");
                    _console.ReadKey();
                }
            }
            else
            {
                _console.WriteLine("No content by that title found");
            }


        }

        private void DisplayContent(StreamingContent content)
        {
            _console.WriteLine($"Title: {content.Title} " +
                   $"Description: {content.Description} " +
                   $"Genre: {content.GenereType} " +
                   $"Maturity Rating; {content.MaturityRating} " +
                   $"Star Rating: {content.StarRating} ");
        }


        private void RemoveContent()
        {
            _console.Clear();

            List<StreamingContent> contentList = _repo.GetContents();
            int count = 0;
            foreach (StreamingContent content in contentList)
            {
                count++;
                _console.WriteLine($"{count}. {content.Title}");
            }
            _console.WriteLine("what content do you want to remove: ");

            int targetId = int.Parse(_console.ReadLine());
            int targetIndex = targetId - 1;
            if (targetIndex >= 0 && targetIndex < contentList.Count())
            {
                StreamingContent desiredContent = contentList[targetIndex];

                if (_repo.DeleteExistingContent(desiredContent))
                {
                    _console.WriteLine($"{desiredContent.Title} deleted successfully.");
                }
                else
                {
                    _console.WriteLine("Something went wrong");
                }
            }
            else
            {
                _console.WriteLine("No content by that ID");
            }
            AnyKey();

        }

        private void SeedDevList()
        {
            _repo.AddContentToDirectory(new Show("Prisoner", "Really smart guys get locked away or eaten by a ball.", 5, MaturityRating.PG13, GenereType.SciFi));
            _repo.AddContentToDirectory(new StreamingContent("F&FX", "Family must drive really fast to save the world", 5, MaturityRating.TV_14, GenereType.Action));
            _repo.AddContentToDirectory(new StreamingContent("NYSMNYD", "pretending pretentous person posits profiting.", 2.5, MaturityRating.TV_14, GenereType.Action));
        }
        private void SeedDevTeamList()
        {
            _repo.AddContentToDirectory(new Show("Prisoner", "Really smart guys get locked away or eaten by a ball.", 5, MaturityRating.PG13, GenereType.SciFi));
            _repo.AddContentToDirectory(new StreamingContent("F&FX", "Family must drive really fast to save the world", 5, MaturityRating.TV_14, GenereType.Action));
            _repo.AddContentToDirectory(new StreamingContent("NYSMNYD", "pretending pretentous person posits profiting.", 2.5, MaturityRating.TV_14, GenereType.Action));
        }


        private void AnyKey()
        {
            _console.WriteLine("/n/nPress any key to continue");
            _console.ReadKey();
        }




    }
}
