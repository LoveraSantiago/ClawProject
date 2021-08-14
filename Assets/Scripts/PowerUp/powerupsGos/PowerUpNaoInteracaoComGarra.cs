using UnityEngine;

public abstract class PowerUpNaoInteracaoComGarra : AbstractPowerUpGo,
                                                    PowerUpInteracaoComGarra
{
    public PowerUpNaoInteracaoComGarra(GameObject goTile, string nome)
        : base(goTile, nome)
    {
    }

    public PowerUpNaoInteracaoComGarra(
        GameObject goTile, Transformador<GameObject, GameObject> getGoComSprRenderer, string nome) 
        : base(goTile, getGoComSprRenderer, nome)
    {
    }

    public override PowerUpInteracaoComGarra getObjInteracaoComGarra()
    {
        return this;
    }

    public PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra()
    {
        return PowerUpEntidade.INTERACAOGARRA.NAO_INTERACAO;
    }   

    public override void fixarEixoX(){}

    public float getAnguloParaGarraSegurar(){ return 0; }        

    public override void ligarGravidadeHum(){}

    public override void ligarGravidadeZero(){}

    public override void parar(){}

    public override void timeout(){}
}
