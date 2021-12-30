using UnityEngine;

public class ProcuradorColetavelMaisAlto : Consumidor<Coletavel>
{
    public Coletavel coletavelMaisAlto { get; private set; }

    public void consumir(Coletavel coletavelIt)
    {
        if (coletavelIt.isAtivo())
        {
            float alturaIt = coletavelIt.getPosicao().y;
            float alturaMaisAlta = getHalturaAtual();

            if(alturaIt > alturaMaisAlta)
            {
                coletavelMaisAlto = coletavelIt;
                //Debug.Log("Setado mais alto");
            }
        }        
    }    

    private float getHalturaAtual()
    {
        if(coletavelMaisAlto != null)
        {
            return coletavelMaisAlto.getPosicao().y;
        }
        return -100;
    }
}
