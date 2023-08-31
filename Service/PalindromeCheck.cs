using System.Text.RegularExpressions;

namespace intervie.Service
{
    public class PalindromeCheck
    {

       public static bool palindrom(string str)
        {
            if (str == null || str.Length == 0) return false;
            str = Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled).ToLower();
            for (int i = 0; i < str.Length / 2; i++)
            {

                if (str[i] == str[str.Length - 1 - i]) continue;
                else return false;
            }

            return true;
        }
    }
}
