using UnityEngine;

public class TeleportePowerUpGo : AbstractPowerUpGo
{
    private bool configurado;
    private ColetavelQuery coletavelQuery;

    public TeleportePowerUpGo(GameObject goTile) 
        : base(goTile, "teleporte")
    {
    }

    public override PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra()
    {
        return PowerUpEntidade.INTERACAOGARRA.NAO_INTERACAO;
    }

    public override void configurarPup()
    {
        coletavelQuery = new ColetavelQuery();        
    }

    public override void iniciarPup()
    {
        coletavelQuery.executeNoPoolDeColetaveis(new LigadorDeMiras());        
    }

    public override void resetPup()
    {
        
    }
}
