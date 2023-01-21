using System.Collections;
using UnityEngine;

public class PowerUpRotacionadorDeColetavel 
{
    private float velocidade;
    private Coletavel coletavel;

    public PowerUpRotacionadorDeColetavel(float velocidade, Coletavel coletavel)
    {
        this.velocidade = velocidade;
        this.coletavel = coletavel;
    }

    public IEnumerator rotacionar()
    {
        Vector3 angulo = coletavel.getAngulo();
        float anguloZDouble = angulo.z;        
        //Debug.Log("Angulo Coletavel " + angulo);
        if ((int)anguloZDouble > 10 || (int)anguloZDouble < -10)
        {
            //Debug.Log("maior que 10 ou menor que -10");
            if ((int)anguloZDouble > 180)
            {
                Debug.Log("E maior que 180");
                do
                {
                    anguloZDouble += velocidade * Time.deltaTime;
                    //Debug.Log("Angulo Coletavel Update " + anguloZDouble);
                    coletavel.colocarNoAngulo(anguloZDouble);
                    yield return null;
                } while ((int)anguloZDouble < 359);
            }
            else
            {
                Debug.Log("E menor que 180");
                do
                {
                    anguloZDouble -= velocidade * Time.deltaTime;
                    //Debug.Log("Angulo Coletavel Update " + anguloZDouble);
                    coletavel.colocarNoAngulo(anguloZDouble);
                    yield return null;
                } while ((int)anguloZDouble > 0);
            }
        }
    }

    
}
