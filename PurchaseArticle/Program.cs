using System;

namespace PurchaseArticle
{
    /// <summary>
    /// The main menu is located here.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Opens the Main menu
        /// </summary>
        public static void Main(string[] args)
        {
            bool restart = true;
            ArticleUserInput article = new ArticleUserInput();

            do
            {
                Console.WriteLine("Select \"return\" to return at any point.");
                Console.WriteLine("=========================================");
                Console.WriteLine("1 - Show all Articles");
                Console.WriteLine("2 - Add more Articles");
                Console.WriteLine("3 - Modify Articles");
                Console.WriteLine("4 - Purchase Articles");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("=========================================");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        article.ShowAllArticles();
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.Clear();
                        article.CreateArticle();
                        Console.WriteLine();
                        break;
                    case "3":
                        Console.Clear();
                        article.EditArticle();
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.Clear();
                        article.PurchaseArticles();
                        Console.WriteLine();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Not a valid option");
                        break;
                }
            } while (restart != false);
        }
    }
}
