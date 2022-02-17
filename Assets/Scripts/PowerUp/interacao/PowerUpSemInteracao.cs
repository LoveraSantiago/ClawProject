using UnityEngine;

public abstract class PowerUpSemInteracao : AbstractPowerUpGo, 
                                            InteracaoPowerUpComComponente
{
    public PowerUpSemInteracao(GameObject goTile, string nome): base(goTile, nome){}

    public PowerUpSemInteracao(
        GameObject goTile, Transformador<GameObject, GameObject> getGoComSprRenderer, string nome) 
        : base(goTile, getGoComSprRenderer, nome)
    {
    }

    public override InteracaoPowerUpComComponente getInteracaoComComponente()
    {
        return this;
    }                    
}
