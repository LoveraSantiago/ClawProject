public interface AllGameManagers 
{
    GarraManager      getGarraManager();
    MaquinaManager    getMaquinaManager();
    PowerUpManager    getPowerUpManager();
    ColetaveisManager getColetaveisManager();
    CameraManager     getCameraManager();
    UiGameManager     getUiManager();
    InputGameImpl     getInputGame();
    DraggavelManager  getDraggavelManager();

}
