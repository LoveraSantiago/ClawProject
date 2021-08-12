using UnityEngine;

public class DisplayDeColetadosArcoIris : ArcoIrisConjunto
{
    private DisplayDeColetado[] displayDeColetado;

    public DisplayDeColetadosArcoIris(DisplayDeColetado[] displayDeColetado)
    {
        this.displayDeColetado = displayDeColetado;
    }

    public void desligar()
    {
        displayDeColetado[0].desligarGlow();
        displayDeColetado[1].desligarGlow();
        displayDeColetado[2].desligarGlow();
    }

    public void ligar()
    {
        displayDeColetado[0].ligarGlowSucesso();
        displayDeColetado[1].ligarGlowSucesso();
        displayDeColetado[2].ligarGlowSucesso();
    }

    public void passarCor(Color cor)
    {
        displayDeColetado[0].getMaterialGlow().setCorNoMaterial(cor);
    }    
}
