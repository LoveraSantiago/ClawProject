public class Chao : ParteEfeitoMaquina
{
    public Chao(ChaoDto chaoDto) 
        : base(chaoDto){}

    protected override string getNomeParteMaquina()
    {
        return ConstantesCoresMaquina.CHAO_DENTRO;
    }
}
