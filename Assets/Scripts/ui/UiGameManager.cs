public class UiGameManager 
{
    public ModalResultadosManager modalResultados { get; private set; }
    public ModalSair modalSair { get; private set; }

    public UiGameManager(MainGameDto mainDto, ColetorDeDados coletorDeDados)
    {
        modalResultados = new ModalResultadosManager(
            mainDto.UiDto, mainDto.MaquinaDto.DisplayColetadosDto.CacaNiquelDto, coletorDeDados);

        modalSair       = new ModalSair(uiDto.ModalSairDto);
    }

    public void configurandoLevel(AbstractLevel levelEscolhido)
    {        
        modalSair.configuradoPeloLevel(levelEscolhido);
    }        
}
