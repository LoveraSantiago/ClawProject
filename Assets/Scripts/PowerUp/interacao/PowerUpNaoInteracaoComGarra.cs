using UnityEngine;

public abstract class PowerUpNaoInteracaoComGarra : AbstractPowerUpGo, 
                                                    InteracaoPowerUpComComponente
{
    public PowerUpNaoInteracaoComGarra(GameObject goTile, string nome): base(goTile, nome){}

    public PowerUpNaoInteracaoComGarra(
        GameObject goTile, Transformador<GameObject, GameObject> getGoComSprRenderer, string nome) 
        : base(goTile, getGoComSprRenderer, nome)
    {
    }

    public override InteracaoPowerUpComComponente getInteracaoComComponente()
    {
        return this;
    }

    public PowerUpEnums.INTERACAOGARRA getInteracaoComGarra()
    {
        return PowerUpEnums.INTERACAOGARRA.NAO_INTERACAO;
    }                   
}
