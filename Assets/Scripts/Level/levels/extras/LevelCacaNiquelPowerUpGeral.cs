public class LevelCacaNiquelPowerUpGeral : AbstractLevelCacaNiquel
{
    public override string getLevelName()
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

    public static Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLevelCacaNiquelGeral();
    }

    public class FornecedorLevelCacaNiquelGeral : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelCacaNiquelPowerUpGeral();
        }
    }
}
