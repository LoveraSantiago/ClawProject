using System.Collections;

public class PowerUpRotacionadorDeColetaveis 
{
    private PowerUpRotacionadorDeColetavel rotacionador1;
    private PowerUpRotacionadorDeColetavel rotacionador2;
    
    public PowerUpRotacionadorDeColetaveis(float velocidade, Coletavel coletavel1, Coletavel coletavel2)
    {
        rotacionador1 = new PowerUpRotacionadorDeColetavel(velocidade, coletavel1);
        rotacionador2 = new PowerUpRotacionadorDeColetavel(velocidade, coletavel2);
    }

    public IEnumerator rotacionar()
    {
        bool completo1 = false;
        bool completo2 = false;
        while(!completo1 || !completo2)
        {
            completo1 = rotacionador1.rotacao();
            completo2 = rotacionador2.rotacao();
            yield return null;
        }
    }
}
