public class UiGameManager 
{
    public ModalResultadosManager modalResultados { get; private set; }
    public ModalSair modalSair { get; private set; }

    public UiGameManager(MainGameDto mainDto, ColetorDeDados coletorDeDados, Loading loading)
    {
        modalResultados = new ModalResultadosManager(mainDto, coletorDeDados, loading);

        modalSair = new ModalSair(mainDto.UiDto.ModalSairDto, loading);
    }

    public void configurandoLevel(AbstractLevel levelEscolhido)
    {        
        modalSair.configuradoPeloLevel(levelEscolhido);
    }        
}
