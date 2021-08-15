using UnityEngine;

public class DisplayDeColetadosArcoIris : ArcoIrisConjunto
{
    private bool powerUpDisplayColetado;
    private DisplayDeColetado[] displayDeColetado;

    public DisplayDeColetadosArcoIris(DisplayDeColetado[] displayDeColetado)
    {
        this.displayDeColetado = displayDeColetado;
    }

    public void setarEstadoPowerUp(bool estado)
    {
        powerUpDisplayColetado = estado;
    }

    public void desligar()
    {
        displayDeColetado[0].desligarGlow();
        displayDeColetado[1].desligarGlow();
        displayDeColetado[2].desligarGlow();
    }

    public void ligar()
    {
        if (!powerUpDisplayColetado)
        {
            displayDeColetado[0].ligarGlowSucesso();
            displayDeColetado[1].ligarGlowSucesso();
            displayDeColetado[2].ligarGlowSucesso();
        }
    }

    public void passarCor(Color cor)
    {
        if (!powerUpDisplayColetado)
        {
            displayDeColetado[0].getMaterialGlow().setCorNoMaterial(cor);
        }
    }    
}
