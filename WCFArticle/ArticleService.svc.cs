using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using WCFArticle.Model;

namespace WCFArticle
{
    public class Service1 : IArticleService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        List<Article> IArticleService.GetAllArticles()
        {
            List<Article> list = new List<Article>();
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "WCFArticle.Resources.Articles.txt";

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
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
    }
}
