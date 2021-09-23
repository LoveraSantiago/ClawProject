public class ControlePupDoCanvas 
{
    private PowerUpEntidade[] allPups;
    public int indiceAtual { get; private set; }

    public ControlePupDoCanvas()
    {
        allPups = FactoryPowerUpEntidade.getAllPowerUps();
        indiceAtual = PlayerPrefsPup.recuperarEApagarIndicePup();
    }

    public PowerUpEntidade getPupAtual()
    {
        return allPups[indiceAtual];
    }

    public PowerUpEntidade getProxPup()
    {
        if(indiceAtual == allPups.Length - 1)
        {
            indiceAtual = 0;
        }
        else
        {
            indiceAtual++;
        }
        return getPupAtual();
    }

    public PowerUpEntidade getAntPup()
    {
        if(indiceAtual == 0)
        {
            indiceAtual = allPups.Length - 1;
        }
        else
        {
            indiceAtual--;
        }
        return getPupAtual();
    }

    public void irPupDoIndice(int indice)
    {
        indiceAtual = indice;
    }    
}
