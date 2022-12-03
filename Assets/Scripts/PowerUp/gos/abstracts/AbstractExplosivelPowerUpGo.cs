using UnityEngine;

public abstract class AbstractExplosivelPowerUpGo : AbstractPowerUpGo,                                                    
                                                    PowerUpInteracaoComGarra
{
    public AbstractExplosivelPowerUpGo(GameObject go, string nome) 
        : base(go, nome){}

    
    public abstract float getAnguloParaGarraSegurar();

    public virtual float getDelayInicio()
    {
        return 0;
    }

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
        //Debug.Log(evento.gameObject.name);
        return TagUtils.isColetavel(evento) || 
               TagUtils.isGaiola(evento) || 
               evento.gameObject.layer == LayerUtils.LAYER_CONTAINER_COLETAVEL_INDICE;
    }

    protected void desligarParticulasEfeitoExplosao()
    {
        powerUpDto.EfeitoExplosao.gameObject.SetActive(false);
    }  
}
