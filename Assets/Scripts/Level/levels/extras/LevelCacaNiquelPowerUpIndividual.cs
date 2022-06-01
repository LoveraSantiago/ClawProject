public class LevelCacaNiquelPowerUpIndividual : AbstractLevelCacaNiquel
{
    public override string getLevelName()
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

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLevelCacaNiquelPupIndividual();
    }

    public class FornecedorLevelCacaNiquelPupIndividual : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelCacaNiquelPowerUpIndividual();
        }
    }
}
