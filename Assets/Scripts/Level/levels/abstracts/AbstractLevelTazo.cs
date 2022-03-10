public abstract class AbstractLevelTazo : AbstractLevel
{
    public override string getLevelName()
    {
        return "Tazo Level";
    }

    public override string getMsgObjetivoLevel()
    {
        return "Memorize e Acerte a trinca de coletaveis";
    }

    public override bool devolverParaBoard()
    {
        return true;
    }

    public override TipoGame getTipoGame()
    {
        return TipoGame.TAZO;
    }
}
