public class ModalFimPontos : AbstractModalFim
{
    private ModalPontosDto modalPontosDto;
    private LinhasChallenge linhasChallenge;

    public ModalFimPontos(ModalPontosDto modalPontosDto)
    {
        this.modalPontosDto = modalPontosDto;
        linhasChallenge = new LinhasChallenge(modalPontosDto.LinhasChallenges);
        modalPontosDto.BtnAvancar.onClick.AddListener(() => irParaCena());
    }

    public void passarResultados(ResultadoLevelDto resultadoLevelsDto, Challenge[] challenges, bool[] resultChallenges)
    {
        modalPontosDto.TextoTempo.text = resultadoLevelsDto.tempoPartida;
        modalPontosDto.TextoPontos.text = Utils.to3Digitos(resultadoLevelsDto.resultadosColetaveis.score);
        linhasChallenge.addConfiguracaoChallenges(challenges);
        linhasChallenge.addEstrelasChallenges(modalPontosDto.CorEstrela, resultChallenges);
    }

    public override void ligar()
    {
        modalPontosDto.GoModalPontos.SetActive(true);
    }

    protected override void irParaCena()
    {
        CenaUtils.irParaCenaMap();
    }
}
