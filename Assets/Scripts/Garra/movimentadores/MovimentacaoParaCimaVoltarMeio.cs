public class MovimentacaoParaCimaVoltarMeio : MovimentacaoParaCima
{
    protected override void trocarAcao()
    {
        comunicadorComGerMovimentacao.trocarParaAcaoVoltarParaMeio();
    }

}
