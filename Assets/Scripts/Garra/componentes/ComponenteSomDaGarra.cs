public class ComponenteSomDaGarra : ComponenteGarraDtoDaGarra
{
    private SomGarra somGarra;

    public ComponenteSomDaGarra(GarraDto garraDto, SomGarra somGarra) 
        : base(garraDto)
    {
        this.somGarra = somGarra;
    }

    public void playSomGarraMovimentoVertical()
    {
        somGarra.playSomGarraSubindo();
    }

    public void stopSomGarraSubindo()
    {
        somGarra.stopSomGarraSubindo();
    }
}
