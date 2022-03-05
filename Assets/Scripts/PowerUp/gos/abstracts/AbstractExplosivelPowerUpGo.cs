using UnityEngine;

public abstract class AbstractExplosivelPowerUpGo : AbstractPowerUpGo,                                                    
                                                    PowerUpInteracaoComGarra
{
    public AbstractExplosivelPowerUpGo(GameObject go, string nome) 
        : base(go, nome){}

    
    public abstract float getAnguloParaGarraSegurar();

    public virtual TipoInteracaoGarra getInteracaoComGarra()
    {
        return TipoInteracaoGarra.MOVIMENTO;
    }

    public override InteracaoPowerUpComComponente getInteracaoComComponente()
    {
        return this;
    }

    protected bool isAlvoExplosivel(Collision2D evento)
    {
        return TagUtils.isColetavel(evento) || TagUtils.isGaiola(evento);
    }
}
