using System.Text.RegularExpressions;


public static class StringTo
{
    public static int To(this string str)
    {
        int i = 0;
        str = Regex.Match(str, "[0-9]+").Value;
        int.TryParse(str, out i);
        return i;
    }
    public static int ToTryParse(this string str)
    {
        int i = 0;
        int.TryParse(str, out i);
        return i;

    }
}

