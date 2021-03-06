﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PurchaseArticle.ArticleServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Article", Namespace="http://schemas.datacontract.org/2004/07/WCFArticle.Model")]
    [System.SerializableAttribute()]
    public partial class Article : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AmountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PriceField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Amount {
            get {
                return this.AmountField;
            }
            set {
                if ((this.AmountField.Equals(value) != true)) {
                    this.AmountField = value;
                    this.RaisePropertyChanged("Amount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ArticleServiceReference.IArticleService")]
    public interface IArticleService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IArticleService/GetAllArticles", ReplyAction="http://tempuri.org/IArticleService/GetAllArticlesResponse")]
        PurchaseArticle.ArticleServiceReference.Article[] GetAllArticles();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IArticleService/GetAllArticles", ReplyAction="http://tempuri.org/IArticleService/GetAllArticlesResponse")]
        System.Threading.Tasks.Task<PurchaseArticle.ArticleServiceReference.Article[]> GetAllArticlesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IArticleService/SaveArticleToFile", ReplyAction="http://tempuri.org/IArticleService/SaveArticleToFileResponse")]
        PurchaseArticle.ArticleServiceReference.Article SaveArticleToFile(PurchaseArticle.ArticleServiceReference.Article article);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IArticleService/SaveArticleToFile", ReplyAction="http://tempuri.org/IArticleService/SaveArticleToFileResponse")]
        System.Threading.Tasks.Task<PurchaseArticle.ArticleServiceReference.Article> SaveArticleToFileAsync(PurchaseArticle.ArticleServiceReference.Article article);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IArticleService/ModifyArticle", ReplyAction="http://tempuri.org/IArticleService/ModifyArticleResponse")]
        PurchaseArticle.ArticleServiceReference.Article ModifyArticle(PurchaseArticle.ArticleServiceReference.Article article);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IArticleService/ModifyArticle", ReplyAction="http://tempuri.org/IArticleService/ModifyArticleResponse")]
        System.Threading.Tasks.Task<PurchaseArticle.ArticleServiceReference.Article> ModifyArticleAsync(PurchaseArticle.ArticleServiceReference.Article article);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IArticleService/SaveBill", ReplyAction="http://tempuri.org/IArticleService/SaveBillResponse")]
        void SaveBill(string bill);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IArticleService/SaveBill", ReplyAction="http://tempuri.org/IArticleService/SaveBillResponse")]
        System.Threading.Tasks.Task SaveBillAsync(string bill);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IArticleServiceChannel : PurchaseArticle.ArticleServiceReference.IArticleService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ArticleServiceClient : System.ServiceModel.ClientBase<PurchaseArticle.ArticleServiceReference.IArticleService>, PurchaseArticle.ArticleServiceReference.IArticleService {
        
        public ArticleServiceClient() {
        }
        
        public ArticleServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ArticleServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ArticleServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ArticleServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PurchaseArticle.ArticleServiceReference.Article[] GetAllArticles() {
            return base.Channel.GetAllArticles();
        }
        
        public System.Threading.Tasks.Task<PurchaseArticle.ArticleServiceReference.Article[]> GetAllArticlesAsync() {
            return base.Channel.GetAllArticlesAsync();
        }
        
        public PurchaseArticle.ArticleServiceReference.Article SaveArticleToFile(PurchaseArticle.ArticleServiceReference.Article article) {
            return base.Channel.SaveArticleToFile(article);
        }
        
        public System.Threading.Tasks.Task<PurchaseArticle.ArticleServiceReference.Article> SaveArticleToFileAsync(PurchaseArticle.ArticleServiceReference.Article article) {
            return base.Channel.SaveArticleToFileAsync(article);
        }
        
        public PurchaseArticle.ArticleServiceReference.Article ModifyArticle(PurchaseArticle.ArticleServiceReference.Article article) {
            return base.Channel.ModifyArticle(article);
        }
        
        public System.Threading.Tasks.Task<PurchaseArticle.ArticleServiceReference.Article> ModifyArticleAsync(PurchaseArticle.ArticleServiceReference.Article article) {
            return base.Channel.ModifyArticleAsync(article);
        }
        
        public void SaveBill(string bill) {
            base.Channel.SaveBill(bill);
        }
        
        public System.Threading.Tasks.Task SaveBillAsync(string bill) {
            return base.Channel.SaveBillAsync(bill);
        }
    }
}
