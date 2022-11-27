using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllGameManagersImpl : AllGameManagers
{
    private GarraManager      garraManager;
    private MaquinaManager    maquinaManager;
    private PowerUpManager    powerUpManager;
    private ColetaveisManager coletaveisManager;
    private CameraManager     cameraManager;
    private UiGameManager     uiManager;
    private InputGameImpl     inputGame;
    private DraggavelManager  draggavelManager;

    public CameraManager getCameraManager()
    {
        return cameraManager;
    }

    public ColetaveisManager getColetaveisManager()
    {
        return coletaveisManager;
    }

    public DraggavelManager getDraggavelManager()
    {
        return draggavelManager;
    }

    public GarraManager getGarraManager()
    {
        return garraManager;
    }

    public InputGameImpl getInputGame()
    {
        return inputGame;
    }

    public MaquinaManager getMaquinaManager()
    {
        return maquinaManager;
    }

    public PowerUpManager getPowerUpManager()
    {
        return powerUpManager;
    }

    public UiGameManager getUiManager()
    {
        return uiManager;
    }
}
