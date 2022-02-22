using UnityEngine;

public abstract class AbstractTrocaPowerUpGo : PowerUpSemInteracao
{
    private static Fornecedor<TrocadorDeOrdem> fornecedorTrocadorDeOrdem;

    public AbstractTrocaPowerUpGo(GameObject goTile, string nome) : base(goTile, nome) { }

    protected TrocadorDeOrdem getTrocadorDeOrdem()
    {
        return fornecedorTrocadorDeOrdem.fornecer();
    }

    public static void configurarTrocadorDeOrdem(Fornecedor<TrocadorDeOrdem> fornecedorTrocadorDeOrdemArg)
    {
        fornecedorTrocadorDeOrdem = fornecedorTrocadorDeOrdemArg;
    }
}
