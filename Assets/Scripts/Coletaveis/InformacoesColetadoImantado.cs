public class InformacoesColetadoImantado 
{
    public string nomeColetado { get; private set; }

    public InformacoesColetadoImantado()
    {
    }

    public InformacoesColetadoImantado(string nomeColetado)
    {
        addNomeColetado(nomeColetado);
    }

    public void addNomeColetado(string nomeColetado)
    {
        this.nomeColetado = nomeColetado;
    }
}
