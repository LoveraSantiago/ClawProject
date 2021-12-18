public class InformacoesDaGarraDto 
{
    public int qtdSubidas { get; private set; }
    public string nomeColetado { get; private set; }   

    public bool isImantadoInfo { get { return nomeColetado != null; } }
    public bool isNotImantadoInfo { get { return !isImantadoInfo; } }    

    public InformacoesDaGarraDto(int qtdSubidas, string nomeColetado)
    {
        this.qtdSubidas = qtdSubidas;
    }   
}
