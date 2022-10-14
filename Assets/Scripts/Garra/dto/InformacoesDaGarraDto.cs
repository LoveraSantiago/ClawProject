public class InformacoesDaGarraDto 
{    
    public string nomeColetado { get; private set; }   

    public bool isImantadoInfo { get { return nomeColetado != null; } }
    public bool isNotImantadoInfo { get { return !isImantadoInfo; } }    

    public InformacoesDaGarraDto(string nomeColetado)
    { 
        this.nomeColetado = nomeColetado;
    }   
}
