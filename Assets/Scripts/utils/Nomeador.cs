public class Nomeador
{
    private int contadorNome;

    public string getName()
    {
        contadorNome++;
        return contadorNome + "";
    }
}
