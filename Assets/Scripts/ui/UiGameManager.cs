public class UiGameManager 
{
    public ModalResultadosManager modalResultados { get; private set; }
    public ModalSair modalSair { get; private set; }

    public UiGameManager(MainGameDto mainDto, ColetorDeDados coletorDeDados, SomModais somModais)
    {
        modalResultados = new ModalResultadosManager(mainDto, coletorDeDados, somModais);

        modalSair = new ModalSair(mainDto.UiDto.ModalSairDto, somModais);
    }

    public void configurandoLevel(AbstractLevel levelEscolhido)
    {        
        modalSair.configuradoPeloLevel(levelEscolhido);
    }        
}
