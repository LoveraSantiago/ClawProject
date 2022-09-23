public class PropsCimaBaixoPrateleiraDto 
{
    public float posYReferenciaBaixo { get; private set; }
    public float posYReferenciaCima { get; private set; }

    public int contadorBaixoSprites { get; private set; }
    public int contadorCimaSprites { get; private set; }

    public PrateleiraArmarioDto prateleiraCima { get; private set; }
    public PrateleiraArmarioDto prateleiraBaixo { get; private set; }

    public PropsCimaBaixoPrateleiraDto(float posYReferenciaBaixo, float posYReferenciaCima)
    {
        this.posYReferenciaBaixo = posYReferenciaBaixo;
        this.posYReferenciaCima = posYReferenciaCima;
    }

    public void decrementarContadorBaixoSprites(int valor)
    {
        contadorBaixoSprites -= valor;
    }

    public void incrementarContadorBaixoSprites()
    {
        contadorBaixoSprites++;
    }

    public void incrementarContadorCimaSprites(int valor)
    {
        contadorCimaSprites += valor;
    }

    public void decrementarContadorCimaSprites()
    {
        contadorCimaSprites--;
    }

    public void setPrateleiraCima(PrateleiraArmarioDto prateleira)
    {
        prateleiraCima = prateleira;
    }

    public void setPrateleiraBaixo(PrateleiraArmarioDto prateleira)
    {
        prateleiraBaixo = prateleira;
    }
}
