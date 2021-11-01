public class VigaEsquerda : ParteEfeitoMaquina
{
    public VigaEsquerda(VigaEsquerdaDto vigaEsquerdaDto) 
        : base(vigaEsquerdaDto){}

    protected override string getNomeParteMaquina()
    {
        return ConstantesCoresMaquina.VIGA_TRAS;
    }
}
