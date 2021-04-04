using UnityEngine;
using System.Collections.Generic;

public class ColetaveisParaTuboDeSaida : ResultadoDoContadorColetaveis
{
    private int torque = 550;
    private int contador;

    private List<Sprite> listaDeCharacters;

    private Vector3[] posicoesOriginais;
    private Rigidbody2D[] rigidBodies;
    private SpriteRenderer[] spriteRenderers;
    private GameObject[] coletaveisParaTubo;

    public ColetaveisParaTuboDeSaida(GameObject[] coletaveisParaTubo,
        List<Sprite> listaDeCharacters)
    {
       // this.coletaveisParaTubo = coletaveisParaTubo;
        inicializarArrays(coletaveisParaTubo);
        this.listaDeCharacters = listaDeCharacters;
    }

    public void devolver(string[] coletados)
    {
        if(coletados.Length > 0)
        {
            Sprite spriteAtual = listaDeCharacters.Find((sprite) => sprite.name == coletados[0]);
            for(contador = 0; contador < coletados.Length; contador++)
            {
                torque *= -1;
                rigidBodies[contador].gravityScale = .55F;
                rigidBodies[contador].AddTorque(torque);
                spriteRenderers[contador].sprite = spriteAtual;
            }        
        }
    }    

    private void inicializarArrays(GameObject[] coletaveisParaTubo)
    {
        this.coletaveisParaTubo = coletaveisParaTubo;
        posicoesOriginais = new Vector3[coletaveisParaTubo.Length];
        rigidBodies       = new Rigidbody2D[coletaveisParaTubo.Length];
        spriteRenderers   = new SpriteRenderer[coletaveisParaTubo.Length];

        for(contador = 0; contador < coletaveisParaTubo.Length; contador++)
        {
            posicoesOriginais[contador] = coletaveisParaTubo[contador].transform.position;
            rigidBodies[contador]       = coletaveisParaTubo[contador].GetComponent<Rigidbody2D>();
            spriteRenderers[contador]   = coletaveisParaTubo[contador].GetComponent<SpriteRenderer>();
        }
    }
}
