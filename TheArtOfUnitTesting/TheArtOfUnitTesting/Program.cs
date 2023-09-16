namespace TheArtOfUnitTesting
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