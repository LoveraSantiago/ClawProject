public class BordasVidroFrente : ParteEfeitoMaquina
{
    public BordasVidroFrente(BordasFrenteDto bordasDto)
        :base(bordasDto){}   

    protected override string getNomeParteMaquina()
    {
        return ConstantesCoresMaquina.BORDA_VIDRO;
    }    
}
