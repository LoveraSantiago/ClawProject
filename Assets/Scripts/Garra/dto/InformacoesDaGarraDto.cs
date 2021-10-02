public class InformacoesDaGarraDto 
{
    public string nomeColetado { get; private set; }

    public InformacoesDaGarraDto()
    {
    }

    public InformacoesDaGarraDto(string nomeColetado)
    {
        addNomeColetado(nomeColetado);
    }

    public void addNomeColetado(string nomeColetado)
    {
        this.nomeColetado = nomeColetado;
    }
}
