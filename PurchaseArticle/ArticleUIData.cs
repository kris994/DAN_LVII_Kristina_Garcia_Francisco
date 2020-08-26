using PurchaseArticle.ArticleServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseArticle
{
    class ArticleUIData
    {
        /// <summary>
        /// Shows all articles in the file
        /// </summary>
        /// <returns>The total amount of articles</returns>
        public int ShowAllArticles()
        {
            int counter = 0;
            using (ArticleServiceClient wcf = new ArticleServiceClient())
            {
                foreach (var item in wcf.GetAllArticles())
                {
                    Console.WriteLine($"{++counter}. {item.Name} - {item.Price} rsd, Amount: {item.Amount}");
                }               
            }
            return counter;
        }

        public void CreateArticle()
        {
            Validations val = new Validations();
            Console.Write("Please enter the article name: ");
            string name = val.CheckIfArticleExists();

            Console.Write("Please enter the article amount: ");
            int amount = val.ValidPositiveNumber();

            Console.Write("Please enter the article price: ");
            double price = val.ValidPositiveDouble();

            Article article = new Article()
            {
                Name = name,
                Amount = amount,
                Price = price
            };

            using (ArticleServiceClient wcf = new ArticleServiceClient())
            {
                article = wcf.SaveArticleToFile(article);
            }

            // Notification
            if (article == null)
            {
                Console.WriteLine("Failed to create an article.");
            }
            else
            {
                Console.WriteLine($"Successfully created an article {article.Name}");
            }
        }

        public void EditArticle()
        {
            int count = ShowAllArticles();

            Validations val = new Validations();
            Console.Write("\nSelect an article number: ");
            int number = val.ValidMaxPositiveNumber(count);

            Console.Write("Choose the new price: ");
            double price = val.ValidPositiveDouble();

            Article changedArticle = new Article();

            using (ArticleServiceClient wcf = new ArticleServiceClient())
            {
                List<Article> allArticles = wcf.GetAllArticles().ToList();

                Article article = new Article()
                {
                    Name = allArticles[number - 1].Name,
                    Amount = allArticles[number - 1].Amount,
                    Price = price
                };

                changedArticle = wcf.ModifyArticle(article);
            }

            // Notification
            if (changedArticle == null)
            {
                Console.WriteLine("Article update failed.");
            }
            else
            {
                Console.WriteLine($"Successfully updated article {changedArticle.Name}");
            }
        }
    }
}
