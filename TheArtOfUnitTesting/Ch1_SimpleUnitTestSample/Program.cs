using TheArtOfUnitTesting;

namespace Ch1_SimpleUnitTestSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SimpleParserTests.TestReturnZeroWhenEmptyString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}