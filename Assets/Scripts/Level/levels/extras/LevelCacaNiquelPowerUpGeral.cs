public class LevelCacaNiquelPowerUpGeral : AbstractLevelCacaNiquel
{
    public override string getLevelTitle()
    {
        return "Caça Niquel Pup Geral";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Ganhar power ups gerais.";
    }   

    public override TipoGame getTipoGame()
    {
        return TipoGame.CACANIQUEL_PUP_GERAL;
    }   
}
