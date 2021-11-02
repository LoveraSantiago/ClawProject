public class VigaParte : ParteEfeitoMaquina
{
    public VigaParte(ParteEfeitoDto vigaEsquerdaDto) 
        : base(vigaEsquerdaDto){}

    protected override string getNomeParteMaquina()
    {
        return ConstantesCoresMaquina.VIGA_TRAS;
    }
}
