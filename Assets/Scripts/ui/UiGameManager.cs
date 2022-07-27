public class UiGameManager 
{
    public ModalResultadosManager modalResultados { get; private set; }
    public ModalSair modalSair { get; private set; }

    public UiGameManager(UIGameDto uiDto)
    {
        modalResultados   = new ModalResultadosManager(uiDto.ModalPontosDto);        
        modalSair         = new ModalSair(uiDto.ModalSairDto);
    }

    public void configurandoLevel(AbstractLevel levelEscolhido)
    {
        modalResultados.configurarLevel(levelEscolhido.getLevelName());        
        modalSair.configuradoPeloLevel(levelEscolhido);
    }        
}
