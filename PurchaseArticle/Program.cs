using System;

namespace PurchaseArticle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ArticleUIData articleFile = new ArticleUIData();

            articleFile.EditArticle();
            Console.ReadKey();
        }
    }
}
