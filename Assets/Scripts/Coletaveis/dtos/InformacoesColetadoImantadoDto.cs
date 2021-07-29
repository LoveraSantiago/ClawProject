public class InformacoesColetadoImantadoDto 
{
    public string nomeColetado { get; private set; }

    public InformacoesColetadoImantadoDto()
    {
    }

    public InformacoesColetadoImantadoDto(string nomeColetado)
    {
        addNomeColetado(nomeColetado);
    }

    public void addNomeColetado(string nomeColetado)
    {
        this.nomeColetado = nomeColetado;
    }
}
