using PurchaseArticle.ArticleServiceReference;

namespace PurchaseArticle
{
    class ArticleFile
    {
        public void ShowAllArticles()
        {
            using (ArticleServiceClient wcf = new ArticleServiceClient())
            {
                foreach (var item in wcf.GetAllArticles())
                {
                    System.Console.WriteLine($"{item.Name} - {item.Price}, Amount: {item.Amount}");
                }
                
            }
        }
    }
}
