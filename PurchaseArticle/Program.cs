using System;

namespace PurchaseArticle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ArticleUserInput articleFile = new ArticleUserInput();

            articleFile.PurchaseArticles();
            Console.ReadKey();
        }
    }
}
