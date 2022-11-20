public class SomManagerGame : SomManager,
                              SomGarra
{
    public SomManagerGame(AudioDto audioDto) 
        : base(audioDto)
    {
    }

    //***** IMPLEMENTACAO INTERFACE SOMGARRA INICIO *****
    public void playSomGarraSubindo()
    {
        base.playSomGarraGirando();
    }

    public void stopSomGarraSubindo()
    {
        base.stopSomGarraGirando();
    }
    //***** IMPLEMENTACAO INTERFACE SOMGARRA FIM *****
}
