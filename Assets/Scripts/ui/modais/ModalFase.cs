using UnityEngine;

public class ModalFase 
{
    private readonly int ANIM_OBJETIVO = Animator.StringToHash("modal-objetivo");
    private readonly int ANIM_FECHAR = Animator.StringToHash("modal-fechar");

    private ModalFaseDto modalFaseDto;
    private LinhasChallenge linhasChallenge;
    private NavegacaoDeArray<ColetavelEntidade> navegacaDeColetaveis;

    public ModalFase(ModalFaseDto modalFaseDto, OperacaoFicha operacaoFichaPrata, SomMap somMap)
    {
        this.modalFaseDto = modalFaseDto;
        modalFaseDto.BtnLevel.onClick.AddListener(()=> irParaCenaGame(operacaoFichaPrata, somMap));
        modalFaseDto.BtnFechar.onClick.AddListener(() => desligar(somMap));
        modalFaseDto.BtnFree.onClick.AddListener(() => liberarLevel());
        navegacaDeColetaveis = new NavegacaoDeArray<ColetavelEntidade>();
        linhasChallenge = new LinhasChallenge(modalFaseDto.LinhasChallenges.LinhaChallenges);
    }

    public void ligar(MapaEntidade mapaEntidade, int indiceLevel, SomMap somMap)
    {        
        AbstractLevel level = mapaEntidade.getLevelByIndiceDezena(indiceLevel);
        ContextoEstaticoUtils.configMapaLevelAtual(mapaEntidade, level);
        MaterialMiniMaquina.addCores(3, modalFaseDto.ImgMiniMaquina.material, level.getDicionarioDeCores());
        navegacaDeColetaveis.setArray(mapaEntidade.getColetaveis(), indiceLevel - 1);

        modalFaseDto.LblNivel.text    = level.getLevelTitle();
        modalFaseDto.LblTipoGame.text = "LEVEL " + level.getTipoGame().ToString();
        modalFaseDto.LblObjetivo.text = level.getMsgObjetivoLevel();
        modalFaseDto.ImgsColetaveis[0].sprite = navegacaDeColetaveis.getItemIndiceAtual().sprite;
        modalFaseDto.ImgsColetaveis[1].sprite = navegacaDeColetaveis.getItemProximo().sprite;
        modalFaseDto.ImgsColetaveis[2].sprite = navegacaDeColetaveis.getItemProximo().sprite;

        somMap.playSomAbrirModal();
        modalFaseDto.Animator.Play(ANIM_OBJETIVO);
                
        linhasChallenge.addEstrelasChallenges(modalFaseDto.LinhasChallenges.MaterialEstrelaLigada, level.challenge);
        linhasChallenge.addConfiguracaoChallenges(mapaEntidade, level.getChallenges());
    }

    private void irParaCenaGame(OperacaoFicha operacaoFichaPrata, SomMap somMap)
    {        
        operacaoFichaPrata.consumirFicha(1);
        somMap.playSomStart();
        ContextoEstaticoUtils.loading.irParaGameCena();
        modalFaseDto.Animator.Play(ANIM_FECHAR);
    }

    private void liberarLevel()
    {
        ContextoEstaticoUtils.level.levelConcluido("10:00", 10, 7, true);
        ContextoEstaticoUtils.loading.irParaMapScene();
        modalFaseDto.Animator.Play(ANIM_FECHAR);
    }

    private void desligar(SomMap somMap)
    {
        somMap.playSomCliqueCancelar();
        somMap.playSomAbrirModal();
        modalFaseDto.Animator.Play(ANIM_FECHAR);
    }   
}
