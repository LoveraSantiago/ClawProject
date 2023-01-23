public class Utils 
{
    public static bool isBlank(string valor)
    {
        return valor == null || "".Equals(valor);
    }

    public static string to3Digitos(int valor)
    {
        string valorString = valor.ToString();
        if(valorString.Length > 2)
        {
            return valorString;
        }
        else if(valorString.Length == 2)
        {
            return "0" + valorString;
        }
        else if(valorString.Length == 1)
        {
            return "00" + valorString;
        }
        return "000";
    } 
}
