public abstract class AbstractMapaLevelFornecedor
{
    public AbstractLevel getLevel(int level)
    {
        switch (level)
        {
            case 1:  return getLevelPrimeiro();
            case 2:  return getLevelSegundo();
            case 3:  return getLevelTerceiro();
            case 4:  return getLevelQuarto();
            case 5:  return getLevelQuinto();
            case 6:  return getLevelSexto();
            case 7:  return getLevelSetimo();
            case 8:  return getLevelOitavo();
            case 9:  return getLevelNono();
            case 10: return getLevelDecimo();
        }
        return null;
    }

    public int getQtdLevels()
    {
        return 10;
    }

    protected abstract AbstractLevel getLevelPrimeiro();
    protected abstract AbstractLevel getLevelSegundo();
    protected abstract AbstractLevel getLevelTerceiro();
    protected abstract AbstractLevel getLevelQuarto();
    protected abstract AbstractLevel getLevelQuinto();
    protected abstract AbstractLevel getLevelSexto();
    protected abstract AbstractLevel getLevelSetimo();
    protected abstract AbstractLevel getLevelOitavo();
    protected abstract AbstractLevel getLevelNono();
    protected abstract AbstractLevel getLevelDecimo();
}
