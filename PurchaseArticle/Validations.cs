using PurchaseArticle.ArticleServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseArticle
{
    /// <summary>
    /// User Input Validations
    /// </summary>
    class Validations
    {
        /// <summary>
        /// Yes/no validation
        /// </summary>
        /// <returns>the yes or no choice</returns>
        public string YesNo()
        {
            string choose = Console.ReadLine().ToLower();

            BackToMainMenu(choose);
            while (choose != "yes" && choose != "no")
            {
                Console.Write("Invalid input. Please try again: ");
                choose = Console.ReadLine().ToLower();
            }

            return choose;
        }

        /// <summary>
        /// The word can not be empty
        /// </summary>
        /// <returns> word that is being inspected </returns>
        public string CheckIfNullOrEmpty()
        {
            string word = Console.ReadLine();
            while (string.IsNullOrEmpty(word))
            {
                Console.Write("The input cannot be empty. Please try again: ");
                word = Console.ReadLine();
            }

            return word;
        }

        /// <summary>
        /// Checks if the article name already exists
        /// </summary>
        /// <returns>The article name</returns>
        public string CheckIfArticleExists()
        {
            using (ArticleServiceClient wcf = new ArticleServiceClient())
            {
                List<Article> allArticls = wcf.GetAllArticles().ToList();
                string word = Console.ReadLine().ToLower();

                for (int i = 0; i < allArticls.Count; i++)
                {
                    if (allArticls[i].Name.ToLower() == word)
                    {
                        Console.Write("This article name already exists. Please try again: ");
                        BackToMainMenu(word);
                        word = Console.ReadLine().ToLower();
                        i = -1;
                    }
                    else if (string.IsNullOrEmpty(word))
                    {
                        Console.Write("The input cannot be empty. Please try again: ");
                        BackToMainMenu(word);
                        word = Console.ReadLine().ToLower();
                        i = -1;
                    }
                }

                return word;
            }
        }

        /// <summary>
        /// Valid number int input with a max value
        /// </summary>
        /// <param name="maxValue">Max value that the user can input</param>
        /// <returns>a valid positive number</returns>
        public int ValidMaxPositiveNumber(int maxValue)
        {
            string s = Console.ReadLine();
            BackToMainMenu(s);
            bool b = Int32.TryParse(s, out int Num);
            while (!b || Num < 1 || Num > maxValue)
            {
                Console.Write($"The value cannot be below 1 or above {maxValue}. Please try again: ");
                s = Console.ReadLine();
                b = Int32.TryParse(s, out Num);
            }
            return Num;
        }

        /// <summary>
        /// Valid positive int input
        /// </summary>
        /// <returns>a valid positive number</returns>
        public int ValidPositiveNumber()
        {
            string s = Console.ReadLine();
            BackToMainMenu(s);
            bool b = Int32.TryParse(s, out int Num);
            while (!b || Num < 1)
            {
                Console.Write("Invalid input. Please try again: ");
                s = Console.ReadLine();
                b = Int32.TryParse(s, out Num);
            }
            return Num;
        }

        /// <summary>
        /// Valid positive Double input
        /// </summary>
        /// <returns>a valid positive Double</returns>
        public double ValidPositiveDouble()
        {
            string s = Console.ReadLine();
            BackToMainMenu(s);
            bool b = double.TryParse(s, out double Num);
            while (!b || Num < 1)
            {
                Console.Write("Invalid input. Please try again: ");
                s = Console.ReadLine();
                b = double.TryParse(s, out Num);
            }
            return Num;
        }

        /// <summary>
        /// Returns the user back to the main menu
        /// </summary>
        /// <param name="input">input that returns the user</param>
        public void BackToMainMenu(string input)
        {
            if (input.ToLower() == "return")
            {
                Program.Main(null);
            }
        }
    }
}
