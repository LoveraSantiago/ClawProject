public class TudoDeSaida : ParteEfeitoMaquina
{
    public TudoDeSaida(TuboDto tuboDto) 
        : base(tuboDto){}

    protected override string getNomeParteMaquina()
    {
        return ConstantesCoresMaquina.TUBO;
    }

    protected override float getTransparencia()
    {
        return 0.88f;
    }
}
