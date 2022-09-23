public class LevelCacaNiquelPowerUpIndividual : AbstractLevelCacaNiquel
{
    public override string getLevelTitle()
    {
        return "Caça Niquel Pup Individual";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Ganhar power up escolhido.";
    }

    public override TipoGame getTipoGame()
    {
        return TipoGame.CACANIQUEL_PUP_INDIVIDUAL;
    }      
}
