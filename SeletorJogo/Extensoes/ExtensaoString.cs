namespace SeletorJogo.Extensoes;
public static class ExtensaoString
{
    public static string GerarId(this string _string)
    {
        if (string.IsNullOrEmpty(_string))
        {
            char[] chars = new char[]
            {'0','1', '2', '3', '4', '5', '6', '7', '8', '9'};
            Random random = new Random();

            string toReturn = string.Empty;

            for (int i = 0; i < 5; i++)
                toReturn += chars[random.Next(0, chars.Length)];

            return toReturn;
        }

        return _string;
    }
}
