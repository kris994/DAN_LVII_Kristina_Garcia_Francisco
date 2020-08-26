namespace WCF
{
    public class FileService : IFileService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
    }
}
