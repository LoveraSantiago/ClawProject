public class PropsCimaBaixoLevelsSCroll 
{    
    public float PosYReferenciaBaixo { get; private set; }
    public float PosYReferenciaCima { get; private set; }

    public int ContadorBaixoLevel { get; private set; }
    public int ContadorCimaLevel { get; private set; }

    public ItemLevelDto ItemLevelCima { get; private set; }
    public ItemLevelDto ItemLevelBaixo { get; private set; }

    public void setPosYReferenciaBaixo(float value)
    {
        PosYReferenciaBaixo = value;
    }

    public void setPosYReferenciaCima(float value)
    {
        PosYReferenciaCima = value;
    }

    public void incrementarContadorBaixo()
    {
        ContadorBaixoLevel++;
    }

    public void decrementarContadorBaixo()
    {
        ContadorBaixoLevel--;
    }

    public void incrementarContadorCima()
    {
        ContadorCimaLevel++;
    }

    public void decrementarContadorCima()
    {
        ContadorCimaLevel--;
    }

    public void setItemLevelCima(ItemLevelDto value)
    {
        ItemLevelCima = value;
    }

    public void setItemLevelBaixo(ItemLevelDto value)
    {
        ItemLevelBaixo = value;
    }
}
