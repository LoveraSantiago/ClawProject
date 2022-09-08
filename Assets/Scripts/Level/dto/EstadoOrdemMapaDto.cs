public class EstadoOrdemMapaDto 
{
    public bool isAntepenultimo { get; private set; }
    public bool isPenultimo { get; private set; }
    public bool isUltimo { get; private set; }

    public EstadoOrdemMapaDto(bool isAntepenultimo, bool isPenultimo, bool isUltimo)
    {
        this.isAntepenultimo = isAntepenultimo;
        this.isPenultimo = isPenultimo;
        this.isUltimo = isUltimo;
    }
}
