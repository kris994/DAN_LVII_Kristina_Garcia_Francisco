using System.Collections.Generic;
using System.ServiceModel;
using WCFArticle.Model;

namespace WCFArticle
{
    [ServiceContract]
    public interface IArticleService
    {
        [OperationContract]
        List<Article> GetAllArticles();

        [OperationContract]
        Article SaveArticleToFile(Article article);

        [OperationContract]
        Article ModifyArticle(Article article);

        [OperationContract]
        void SaveBill(string bill);
    }
}
