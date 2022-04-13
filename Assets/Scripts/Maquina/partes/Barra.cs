public class Barra : ParteEfeitoMaquina
{
    public Barra(BarraDto barraDto)
        : base(barraDto){}

    protected override string getNomeParteMaquina()
    {
        return ConstantesCoresMaquinaV2.BARRA;
    }
}
