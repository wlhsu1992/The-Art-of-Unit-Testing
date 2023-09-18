using Ch2_SimpleUnitTest.Interface;

namespace Ch2_SimpleUnitTest
{
    public class FileExtensionManager : IExtensionManager
    {
        public bool IsValid(string fileName)
        {
            return fileName.EndsWith(".SLF", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
