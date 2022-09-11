public class PropsCimaBaixoScrollManager 
{    
    public float PosYReferenciaBaixo { get; private set; }
    public float PosYReferenciaCima { get; private set; }

    public int ContadorBaixoLevel { get; private set; }
    public int ContadorCimaLevel { get; private set; }

    public ItemLevelScroll ItemLevelCima { get; private set; }
    public ItemLevelScroll ItemLevelBaixo { get; private set; }

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

    public void setItemLevelCima(ItemLevelScroll value)
    {
        ItemLevelCima = value;
    }

    public void setItemLevelBaixo(ItemLevelScroll value)
    {
        ItemLevelBaixo = value;
    }
}
