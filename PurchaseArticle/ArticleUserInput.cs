using PurchaseArticle.ArticleServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseArticle
{
    /// <summary>
    /// Article User Input
    /// </summary>
    class ArticleUserInput
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
                    if (item.Amount != 0)
                    {
                        Console.WriteLine($"{++counter}. {item.Name} - {item.Price} rsd, Amount: {item.Amount}");
                    }
                    else
                    {
                        Console.WriteLine($"{++counter}. >>OUT OF STOCK<< {item.Name} - {item.Price} rsd");
                    }
                }               
            }
            return counter;
        }

        /// <summary>
        /// Create new article
        /// </summary>
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

        /// <summary>
        /// Edit existing article
        /// </summary>
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

        /// <summary>
        /// Purchase article
        /// </summary>
        public void PurchaseArticles()
        {
            string answer = "";
            string bill = "";
            int number = 0;
            int currentAmount = 0;
            double totalPrice = 0;
            Validations val = new Validations();

            do
            {
                int count = ShowAllArticles();

                using (ArticleServiceClient wcf = new ArticleServiceClient())
                {

                    List<Article> allArticles = wcf.GetAllArticles().ToList();

                    do
                    {
                        Console.Write("\nSelect an article number: ");
                        number = val.ValidMaxPositiveNumber(count);
                        currentAmount = allArticles[number - 1].Amount;
                        if (currentAmount == 0)
                        {
                            Console.Write("Cannot select an article that is out of stock.");
                        }
                    } while (currentAmount == 0);


                    Console.Write("Choose the amount: ");
                    Article changedArticle = new Article();

                    int amount = val.ValidMaxPositiveNumber(allArticles[number - 1].Amount);

                    Article article = new Article()
                    {
                        Name = allArticles[number - 1].Name,
                        Amount = allArticles[number - 1].Amount - amount,
                        Price = allArticles[number - 1].Price
                    };

                    totalPrice += amount * article.Price;
                    bill += article.Name + " - " + (amount * article.Price) + " (" + amount + "*" + article.Price  + ")" +"|";
                    changedArticle = wcf.ModifyArticle(article);
                }

                Console.Write("\nWould you like to purchase more items? (yes/no): ");
                answer = val.YesNo();
                Console.Clear();
            } while (answer.ToLower() == "yes");

            bill += "|-----------------------|Total price: " + totalPrice + "|" + "Hour: " + DateTime.Now.ToString("HH:mm:ss") + "|";

            using (ArticleServiceClient wcf = new ArticleServiceClient())
            {
                wcf.SaveBill(bill);
            }

            Console.WriteLine("Successfult finished the purchase!\n");
            string[] billInfo = bill.Split('|');
            foreach (var item in billInfo)
            {
                Console.WriteLine(item);
            }
        }
    }
}
