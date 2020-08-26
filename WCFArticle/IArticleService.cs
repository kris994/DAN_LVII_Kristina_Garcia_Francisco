using System.Collections.Generic;
using System.ServiceModel;
using WCFArticle.Model;

namespace WCFArticle
{
    [ServiceContract]
    public interface IArticleService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        List<Article> GetAllArticles();
    }
}
