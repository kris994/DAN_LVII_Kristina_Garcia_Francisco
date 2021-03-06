﻿using PurchaseArticle.ArticleServiceReference;
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
                        Console.WriteLine("{0,3}. {1,20} - {2,-1}\t {3,-20}", ++counter, item.Name, (item.Price).ToString("0.00") + " rsd", "Amount: " +  item.Amount);
                    }
                    else
                    {
                        Console.WriteLine("{0,3}. {1,20} - {2,-1}\t {3,-20}", ++counter,  item.Name, (item.Price).ToString("0.00") + " rsd", ">> OUT OF STOCK <<");
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

            // Creates a new article
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

            // Used for later notification depending if the article was updated or not
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
            Console.WriteLine("==============================================\n" +
                "Return option is disabled until purchase is completed." +
                "\n==============================================");

            // Do until User presses No as an answer
            do
            {
                int count = ShowAllArticles();

                using (ArticleServiceClient wcf = new ArticleServiceClient())
                {
                    List<Article> allArticles = wcf.GetAllArticles().ToList();

                    // Do until a valid item is selected
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

                    // Select amount
                    Console.Write("Choose the amount: ");
                    int amount = val.ValidMaxPositiveNumber(allArticles[number - 1].Amount);

                    // Changed article after reducing the total amount
                    Article article = new Article()
                    {
                        Name = allArticles[number - 1].Name,
                        Amount = allArticles[number - 1].Amount - amount,
                        Price = allArticles[number - 1].Price
                    };

                    // Calculate total price and save the item on the bill
                    totalPrice += amount * article.Price;
                    bill += article.Name + " - " + (amount * article.Price) + " rsd" + "\t\t(" + amount + "*" + article.Price  + ")" +"|";
                    wcf.ModifyArticle(article);
                }

                Console.Write("\nWould you like to purchase more items? (yes/no): ");
                answer = val.YesNo();
                Console.Clear();
            } while (answer.ToLower() == "yes");

            // Update bill with all the info before saving it
            bill += "|-----------------------|Total price: " + totalPrice + " rsd|" + "Hour: " + DateTime.Now.ToString("HH:mm:ss") + "|";

            // Save the bill
            using (ArticleServiceClient wcf = new ArticleServiceClient())
            {
                wcf.SaveBill(bill);
            }

            // Bill preview
            Console.WriteLine("Successfult finished the purchase!\n");
            string[] billInfo = bill.Split('|');
            foreach (var item in billInfo)
            {
                Console.WriteLine(item);
            }
        }
    }
}
