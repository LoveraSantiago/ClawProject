using UnityEngine;

public class ColetaveisParaTuboDeSaida : ResultadoDoContadorColetaveis
{
    private int torque = 550;
    private int contador;

    private Vector3[] posicoesOriginais;
    private Rigidbody2D[] rigidBodies;
    //private GameObject[] coletaveisParaTubo;

    public ColetaveisParaTuboDeSaida(GameObject[] coletaveisParaTubo)
    {
       // this.coletaveisParaTubo = coletaveisParaTubo;
        inicializarArrays(coletaveisParaTubo);
    }

    public void devolver(string[] coletados)
    {
        Debug.Log("Devolver chamado com " + coletados.Length);
        for(contador = 0; contador < coletados.Length; contador++)
        {
            torque *= -1;
            rigidBodies[contador].gravityScale = .55F;
            rigidBodies[contador].AddTorque(torque);
        }        
    }    

    private void inicializarArrays(GameObject[] coletaveisParaTubo)
    {
        posicoesOriginais = new Vector3[coletaveisParaTubo.Length];
        rigidBodies = new Rigidbody2D[coletaveisParaTubo.Length];

        for(contador = 0; contador < coletaveisParaTubo.Length; contador++)
        {
            posicoesOriginais[contador] = coletaveisParaTubo[contador].transform.position;
            rigidBodies[contador] = coletaveisParaTubo[contador].GetComponent<Rigidbody2D>();
        }
    }
}
