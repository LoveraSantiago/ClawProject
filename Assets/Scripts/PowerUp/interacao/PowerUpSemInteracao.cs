using UnityEngine;

public abstract class PowerUpSemInteracao : AbstractPowerUpGo, 
                                            InteracaoPowerUpComComponente
{
    public PowerUpSemInteracao(GameObject goTile, string nome): 
        base(goTile, nome){}

    public PowerUpSemInteracao(
        GameObject goTile, FinderDeSprRenderer finderDeSprRenderer, string nome) 
        : base(goTile, finderDeSprRenderer, nome)
    {
    }

    public override InteracaoPowerUpComComponente getInteracaoComComponente()
    {
        return this;
    }                    
}
