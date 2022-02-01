public class ModalFase 
{
    private ModalFaseDto modalFaseDto;

    public ModalFase(ModalFaseDto modalFaseDto)
    {
        this.modalFaseDto = modalFaseDto;
        modalFaseDto.BtnLevel.onClick.AddListener(()=> CenaUtils.irParaCenaMainGame());
        modalFaseDto.BtnFechar.onClick.AddListener(() => desligar());
    }

    public void ligar(Level levelEnum)
    {
        PlayerPrefsLevel.salvarLevel(levelEnum);

        AbstractLevel level = LevelHelper.getLevelByEnum(levelEnum);
        modalFaseDto.LblNivel.text = level.getLevelName();
        modalFaseDto.LblObjetivo.text = level.getMsgObjetivoLevel();

        modalFaseDto.ModalFase.SetActive(true);
    }

    private void desligar()
    {
        modalFaseDto.ModalFase.SetActive(false);
    }
   
}
