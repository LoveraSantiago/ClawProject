public interface AllGameManagers 
{
    GarraManager      getGarraManager();
    MaquinaManager    getMaquinaManager();
    PowerUpManager    getPowerUpManager();
    ColetaveisManager getColetaveisManager();
    CameraManager     getCameraManager();
    UiGameManager     getUiManager();
    DraggavelManager  getDraggavelManager();
    InputGame         getInputGame();
    ModalResultadosManager getModalResultadosManager();

    DadosDeTempo      getDadosTempo();
    BoardElevador     getBoardElevador();
    ModoColetados     getModoColetados();
    DisplayTimer      getDisplayTimer();
    DisplaysDeColetados getDisplaysDeColetados();
    DisplayDeScores   getDisplayDeScores();
    ScrollSelecao     getScrollSelecao();
    ScrollPupsManager getScrollPupsManager();
    BotaoLigaDesliga  getBotaoLigaDesliga();
    BotoesPowerUp     getBotoesPowerUp();
    ArcoIrisEfeito    getArcoIrisEfeito();
    ModalSair         getModalSair();
    
}
