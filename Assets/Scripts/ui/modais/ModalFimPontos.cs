public class ModalFimPontos : AbstractModalFim
{
    private ModalPontosDto modalPontosDto;
    private LinhasChallenge linhasChallenge;
    private SomModais somModais;

    public ModalFimPontos(ModalPontosDto modalPontosDto, SomModais somModais)
    {
        this.modalPontosDto = modalPontosDto;
        this.somModais      = somModais;
        linhasChallenge = new LinhasChallenge(modalPontosDto.LinhasChallenges.LinhaChallenges);
        modalPontosDto.BtnAvancar.onClick.AddListener(() => irParaCena());
    }

    public void passarResultados(ResultadoLevelDto resultadoLevelsDto, Challenge[] challenges, bool[] resultChallenges)
    {
        modalPontosDto.TextoNivel.text = ContextoEstaticoUtils.level.getLevelTitle();
        modalPontosDto.TextoTempo.text = resultadoLevelsDto.tempoPartida;
        modalPontosDto.TextoPontos.text = Utils.to3Digitos(resultadoLevelsDto.resultadosColetaveis.score);
        linhasChallenge.addConfiguracaoChallenges(resultadoLevelsDto.mapaEntidade, challenges);
        linhasChallenge.addEstrelasChallenges(modalPontosDto.LinhasChallenges.MaterialEstrelaLigada, resultChallenges);
    }

    public override void ligar()
    {
        somModais.playSomSucessoAbrirModal();
        modalPontosDto.GoModalPontos.SetActive(true);
    }

    protected override void irParaCena()
    {
        somModais.playSomCliquePositivo();
        if (LevelUtils.isTutorialPowerUp())
        {
            ContextoEstaticoUtils.loading.irParaPowerUpCena();
        }
        else
        {
            ContextoEstaticoUtils.loading.irParaMapScene();        
        }
    }
}
