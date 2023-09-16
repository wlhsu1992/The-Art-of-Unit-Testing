namespace Ch2_SimpleUnitTest
{
    public class FileExtensionManager
    {
        public bool IsValid(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(
                    "filename has to be provided");
            }

            return fileName.EndsWith(".SLF", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
