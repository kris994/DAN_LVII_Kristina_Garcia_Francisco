using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using WCFArticle.Model;

namespace WCFArticle
{
    public class Service1 : IArticleService
    {
        /// <summary>
        /// The folder we are saving the articles at
        /// </summary>
        private readonly string articleFolder = AppDomain.CurrentDomain.BaseDirectory + @"\TextFiles";

        /// <summary>
        /// The file we are saving the articles at
        /// </summary>
        private readonly string articleFile = AppDomain.CurrentDomain.BaseDirectory +  @"\TextFiles\Articles.txt";

        /// <summary>
        /// The folder we are saving the bills at
        /// </summary>
        private readonly string billFolder = AppDomain.CurrentDomain.BaseDirectory + @"\BillFolder";

        /// <summary>
        /// Get all articles from the file
        /// </summary>
        /// <returns></returns>
        public List<Article> GetAllArticles()
        {
            List<Article> list = new List<Article>();

            // Create Folder if it does not exist
            Directory.CreateDirectory(articleFolder);

            // Makes sure the article file exists
            if (!File.Exists(articleFile))
            {
                File.Create(articleFile).Close();
            }

            try
            {
                using (StreamReader reader = new StreamReader(articleFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] articleInfo = line.Split(':');

                        Article newArticle = new Article()
                        {
                            Name = articleInfo[0].ToString(),
                            Amount = int.Parse(articleInfo[1]),
                            Price = Math.Round(double.Parse(articleInfo[2]), 2)
                        };

                        list.Add(newArticle);
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return list;
            }
        }

        /// <summary>
        /// Saves an article to the file
        /// </summary>
        /// <param name="article">The article that is being saved</param>
        /// <returns>The created article if it was successful</returns>
        public Article SaveArticleToFile(Article article)
        {
            try
            {
                // Create Folder if it does not exist
                Directory.CreateDirectory(articleFolder);

                // Makes sure the article file exists
                if (!File.Exists(articleFile))
                {
                    File.Create(articleFile).Close();
                }

                using (StreamWriter writer = new StreamWriter(articleFile, append: true))
                {
                    writer.WriteLine($"{article.Name}:{article.Amount}:{article.Price.ToString("0.00")}");
                }

                return article;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        /// <summary>
        /// Modifies the article in the file
        /// </summary>
        /// <param name="article">article with the modified value</param>
        /// <returns>The modified article if the update is successful</returns>
        public Article ModifyArticle(Article article)
        {
            List<Article> allArticles = GetAllArticles().ToList();
            Article articleToEdit = new Article();

            for (int i = 0; i < allArticles.Count; i++)
            {
                if (allArticles[i].Name == article.Name)
                {
                    articleToEdit = allArticles[i];
                    break;
                }
            }

            // If article does not exist return null
            if (articleToEdit.Name == null)
            {
                return null;
            }
            else
            {
                // Remove the old article
                var tempFile = Path.GetTempFileName();
                var linesToKeep = File.ReadLines(articleFile).Where(l => l != $"{articleToEdit.Name}:{articleToEdit.Amount}:{articleToEdit.Price.ToString("0.00")}");

                // Place the new article
                File.WriteAllLines(tempFile, linesToKeep);
                File.AppendAllText(tempFile, $"{article.Name}:{article.Amount}:{article.Price.ToString("0.00")}" + Environment.NewLine);
                File.Delete(articleFile);
                File.Move(tempFile, articleFile);
            }

            return article;
        }

        public void SaveBill(string bill)
        {
            // Create Folder if it does not exist
            Directory.CreateDirectory(billFolder);
            int fileCount = Directory.GetFiles(billFolder).Length;


            using (StreamWriter writer = new StreamWriter(billFolder + @"\Racun_" + (fileCount + 1) + "_TimeStamp.txt"))
            {
                string[] billInfo = bill.Split('|');
                foreach (var item in billInfo)
                {
                    writer.WriteLine(item);
                }
            }
        }
    }
}
