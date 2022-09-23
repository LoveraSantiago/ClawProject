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


        modalFaseDto.LblNivel.text = level.getLevelTitle();
        modalFaseDto.LblObjetivo.text = level.getMsgObjetivoLevel();

        modalFaseDto.ModalFase.SetActive(true);
    }

    private void irParaCenaGame()
    {
        PlayerPrefsFichas.consumirFicha(Ficha.PRATA, 1);
        CenaUtils.irParaCenaMainGame();
    }

    private void desligar()
    {
        modalFaseDto.ModalFase.SetActive(false);
    }   
}
