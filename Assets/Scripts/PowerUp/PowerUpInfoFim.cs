public class PowerUpInfoFim 
{
    public bool preFinalizar { get; private set; }
    public bool finalizar { get; private set; }

    public PowerUpInfoFim(bool preFinalizar, bool finalizar)
    {
        this.preFinalizar = preFinalizar;
        this.finalizar = finalizar;
    }
}
