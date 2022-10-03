public class ModalFase 
{
    private ModalFaseDto modalFaseDto;
    private NavegacaoDeArray<ColetavelEntidade> navegacaDeColetaveis;

    public ModalFase(ModalFaseDto modalFaseDto)
    {
        this.modalFaseDto = modalFaseDto;
        modalFaseDto.BtnLevel.onClick.AddListener(()=> irParaCenaGame());
        modalFaseDto.BtnFechar.onClick.AddListener(() => desligar());
        navegacaDeColetaveis = new NavegacaoDeArray<ColetavelEntidade>();
    }

    public void ligar(MapaEntidade mapaEntidade, int indiceLevel)
    {
        AbstractLevel level = mapaEntidade.getLevelByIndiceDezena(indiceLevel);
        ContextoEstaticoUtils.configMapaLevelAtual(mapaEntidade, level);
        MaterialMiniMaquina.addCores(3, modalFaseDto.ImgMiniMaquina.material, level.getDicionarioDeCores());
        navegacaDeColetaveis.setArray(mapaEntidade.getColetaveis(), indiceLevel - 1);

        modalFaseDto.LblNivel.text = level.getLevelTitle();
        modalFaseDto.LblTipoGame.text = "LEVEL " + level.getTipoGame().ToString();
        modalFaseDto.LblObjetivo.text = level.getMsgObjetivoLevel();
        modalFaseDto.ImgsColetaveis[0].sprite = navegacaDeColetaveis.getItemIndiceAtual().sprite;
        modalFaseDto.ImgsColetaveis[1].sprite = navegacaDeColetaveis.getItemProximo().sprite;
        modalFaseDto.ImgsColetaveis[2].sprite = navegacaDeColetaveis.getItemProximo().sprite;

        modalFaseDto.Animator.Play("modal-objetivo");
    }

    private void irParaCenaGame()
    {
        PlayerPrefsFichas.consumirFicha(Ficha.PRATA, 1);
        CenaUtils.irParaCenaMainGame();
    }

    private void desligar()
    {
        modalFaseDto.Animator.Play("modal-fechar");
    }   
}
