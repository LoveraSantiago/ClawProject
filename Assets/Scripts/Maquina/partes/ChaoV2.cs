public class ChaoV2 : ParteEfeitoMaquinaV2
{
    public ChaoV2(ChaoDto chaoDto)
        : base(chaoDto) { }

    protected override string getNomeParteMaquina()
    {
        return ConstantesCoresMaquinaV2.CHAO_DENTRO;
    }
}
