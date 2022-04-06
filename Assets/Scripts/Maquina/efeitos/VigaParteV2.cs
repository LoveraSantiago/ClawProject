public class VigaParteV2 : ParteEfeitoMaquinaV2
{
    public VigaParteV2(ParteEfeitoDto vigaEsquerdaDto)
        : base(vigaEsquerdaDto) { }

    protected override string getNomeParteMaquina()
    {
        return ConstantesCoresMaquinaV2.VIGAS;
    }
}
