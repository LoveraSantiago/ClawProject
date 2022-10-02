public class ModalFase 
{
    private ModalFaseDto modalFaseDto;

    public ModalFase(ModalFaseDto modalFaseDto)
    {
        this.modalFaseDto = modalFaseDto;
        modalFaseDto.BtnLevel.onClick.AddListener(()=> irParaCenaGame());
        modalFaseDto.BtnFechar.onClick.AddListener(() => desligar());
    }

    public void ligar(MapaEntidade mapaEntidade, int indiceLevel)
    {
        AbstractLevel level = mapaEntidade.getLevelByIndiceDezena(indiceLevel);
        ContextoEstaticoUtils.configMapaLevelAtual(mapaEntidade, level);
        MaterialMiniMaquina.addCores(3, modalFaseDto.ImgMiniMaquina.material, level.getDicionarioDeCores());

        modalFaseDto.LblNivel.text = level.getLevelTitle();
        modalFaseDto.LblTipoGame.text = "LEVEL " + level.getTipoGame().ToString();
        modalFaseDto.LblObjetivo.text = level.getMsgObjetivoLevel();

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
