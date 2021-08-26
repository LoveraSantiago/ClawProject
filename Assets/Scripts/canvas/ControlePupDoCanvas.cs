using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePupDoCanvas 
{
    private PowerUpEntidade[] allPups;

    public ControlePupDoCanvas()
    {
        allPups = FactoryPowerUpEntidade.getAllPowerUps();
    }
}
