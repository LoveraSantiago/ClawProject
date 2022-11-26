public class ModalFimPontos : AbstractModalFim
{
    private ModalPontosDto modalPontosDto;
    private LinhasChallenge linhasChallenge;
    private SomModais somModais;

    public ModalFimPontos(ModalPontosDto modalPontosDto, Loading loading, SomModais somModais)
    {
        this.modalPontosDto = modalPontosDto;
        this.somModais      = somModais;
        linhasChallenge = new LinhasChallenge(modalPontosDto.LinhasChallenges.LinhaChallenges);
        modalPontosDto.BtnAvancar.onClick.AddListener(() => irParaCena(loading));
    }

    public void passarResultados(ResultadoLevelDto resultadoLevelsDto, Challenge[] challenges, bool[] resultChallenges)
    {
        modalPontosDto.TextoTempo.text = resultadoLevelsDto.tempoPartida;
        modalPontosDto.TextoPontos.text = Utils.to3Digitos(resultadoLevelsDto.resultadosColetaveis.score);
        linhasChallenge.addConfiguracaoChallenges(resultadoLevelsDto.mapaEntidade, challenges);
        linhasChallenge.addEstrelasChallenges(modalPontosDto.LinhasChallenges.CorEstrela, resultChallenges);
    }

    public override void ligar()
    {
        somModais.playSomSucessoAbrirModal();
        modalPontosDto.GoModalPontos.SetActive(true);
    }

    protected override void irParaCena(Loading loading)
    {
        somModais.playSomCliquePositivo();
        loading.irParaMapScene();        
    }
}
