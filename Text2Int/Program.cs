
namespace Text2Int
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Input the text you want to convert to number:");
            string value = Console.ReadLine();
            if (value != null && value != string.Empty)
            {
                Console.WriteLine("The value you inputted is: ");
                Console.Write(value);
                Console.WriteLine("The converted number is: ");
                Console.WriteLine(new Mechanism(value).Process());
            }
            else
            {
                Console.WriteLine("The text can't be empty.");
            }
        }
    }
}
