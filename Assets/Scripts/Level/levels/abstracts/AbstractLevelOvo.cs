public abstract class AbstractLevelOvo : AbstractLevel
{
    public override string getLevelTitle()
    {
        return "Momorizacao Level";
    }  

    public override bool devolverParaBoard()
    {
        return true;
    }

    public override string getMsgObjetivoLevel()
    {
        return AbstractLevel.MSG_MEMORIA;
    }

    public override TipoGame getTipoGame()
    {
        return TipoGame.MEMORIA;
    }
}
