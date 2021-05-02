public class Nomeador
{
    private int contadorNome;

    public Nomeador()
    {
        contadorNome = 0;
    }

    public string getName()
    {
        contadorNome++;
        return contadorNome + "";
    }
}
