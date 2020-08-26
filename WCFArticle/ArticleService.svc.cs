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
        private readonly string articleFile = AppDomain.CurrentDomain.BaseDirectory +  @"\TextFiles\Articles.txt";

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public List<Article> GetAllArticles()
        {
            List<Article> list = new List<Article>();

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
                            Price = double.Parse(articleInfo[2])
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

        public Article SaveArticleToFile(Article article)
        {
            try
            {
                // Makes sure the article file exists
                if (!File.Exists(articleFile))
                {
                    File.Create(articleFile).Close();
                }

                using (StreamWriter writer = new StreamWriter(articleFile, append: true))
                {
                    writer.WriteLine($"{article.Name}:{article.Amount}:{article.Price}");
                }

                return article;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        public Article ModifyArticle(Article article)
        {
            List<Article> allArticles = GetAllArticles().ToList();
            Article articleToEdit = new Article();

            for (int i = 0; i < allArticles.Count; i++)
            {
                if (allArticles[i].Name == article.Name)
                {
                    articleToEdit = allArticles[i];
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
                var linesToKeep = File.ReadLines(articleFile).Where(l => l != $"{articleToEdit.Name}:{articleToEdit.Amount}:{articleToEdit.Price}");

                // Place the new article
                File.WriteAllLines(tempFile, linesToKeep);
                File.AppendAllText(tempFile, $"{article.Name}:{article.Amount}:{article.Price}" + Environment.NewLine);
                File.Delete(articleFile);
                File.Move(tempFile, articleFile);
            }

            return article;
        }
    }
}
