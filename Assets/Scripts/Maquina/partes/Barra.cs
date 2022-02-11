public class Barra : ParteEfeitoMaquina
{
    public Barra(BarraDto barraDto)
        : base(barraDto){}

    protected override string getNomeParteMaquina()
    {
        return ConstantesCoresMaquina.BARRA;
    }
}
