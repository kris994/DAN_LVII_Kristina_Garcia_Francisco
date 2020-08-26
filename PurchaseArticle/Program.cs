using PurchaseArticle.ArticleServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseArticle
{
    class Program
    {
        static void Main(string[] args)
        {
            ArticleFile articleFile = new ArticleFile();
            articleFile.ShowAllArticles();
            Console.ReadKey();
        }
    }
}
