public class HelperGaiolasInGame 
{
    private static PoolDeNomes<Gaiola> poolDeNomes;

    public Gaiola criarGaiola()
    {
        Gaiola gaiola = new Gaiola();
        poolDeNomes.addChaveValor(gaiola.nome, gaiola);
        return gaiola;
    }

    public Gaiola getGaiolaInGameByGoName(string name)
    {
        return poolDeNomes.getValor(name);
    }

    public static void configurar()
    {
        poolDeNomes = new PoolDeNomes<Gaiola>();
    }
}
