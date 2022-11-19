public class ModalFase 
{
    private ModalFaseDto modalFaseDto;
    private LinhasChallenge linhasChallenge;
    private NavegacaoDeArray<ColetavelEntidade> navegacaDeColetaveis;

    public ModalFase(ModalFaseDto modalFaseDto, Loading loading, SomMap somMap)
    {
        this.modalFaseDto = modalFaseDto;
        modalFaseDto.BtnLevel.onClick.AddListener(()=> irParaCenaGame(loading));
        modalFaseDto.BtnFechar.onClick.AddListener(() => desligar(somMap));
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
        modalFaseDto.Animator.Play("modal-objetivo");
                
        linhasChallenge.addEstrelasChallenges(modalFaseDto.LinhasChallenges.CorEstrela, level.challenge);
        linhasChallenge.addConfiguracaoChallenges(mapaEntidade, level.getChallenges());
    }

    private void irParaCenaGame(Loading loading)
    {
        PlayerPrefsFichas.consumirFicha(Ficha.PRATA, 1);
        loading.irParaGameCena();        
    }

    private void desligar(SomMap somMap)
    {
        somMap.playSomAbrirModal();
        modalFaseDto.Animator.Play("modal-fechar");
    }   
}
