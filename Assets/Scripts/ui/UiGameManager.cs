public class UiGameManager 
{
    public ModalResultadosManager modalResultados { get; private set; }
    public ModalSair modalSair { get; private set; }

    public UiGameManager(UIGameDto uiDto, CacaNiquelDto cacaNiquelDto)
    {
        modalResultados = new ModalResultadosManager(uiDto, cacaNiquelDto);        
        modalSair       = new ModalSair(uiDto.ModalSairDto);
    }

    public void configurandoLevel(AbstractLevel levelEscolhido)
    {
        modalResultados.configurarLevel(levelEscolhido.getLevelTitle());        
        modalSair.configuradoPeloLevel(levelEscolhido);
    }        
}
