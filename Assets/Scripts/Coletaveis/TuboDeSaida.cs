using System.Collections;
using UnityEngine;

public class TuboDeSaida : ConsumidorDeEventoTrigger
{
    private bool devolverTubo;    
    private float torque;    

    private Vector3[] posicoesOriginais;
    private Rigidbody2D[] rigidBodies;//TODO transformar esses caras em coletavel para mais facil manipulacaoS
    private SpriteRenderer[] spriteRenderers;    

    private TuboDto tuboDto;

    public TuboDeSaida(TuboDto tuboDto)
    {
        this.tuboDto = tuboDto;

        inicializarArrays();
        configurarEventoTrigger();        
        
        torque = tuboDto.Torque;        
    }

    public void configuradoPeloLevel(bool devolverParaBoard)
    {
        this.devolverTubo = !devolverParaBoard;
    }

    public void devolver(bool[] resultados, Coletavel[] coletados, MonoBehaviour monoBehaviour)
    {
        if (devolverTubo)
        {
            Debug.Log("Devolver tubo acionado");
            monoBehaviour.StartCoroutine(descerPeloTubo(resultados, coletados));
        }
    }

    private IEnumerator descerPeloTubo(bool[] resultados, Coletavel[] coletados)
    {        
        
        for (int contador = 0; contador < coletados.Length; contador++)
        {
            if (resultados[contador])
            {
                torque *= -1;
                Sprite spriteAtual = coletados[contador].getSprite();
                rigidBodies[contador].gravityScale = tuboDto.Gravidade;
                rigidBodies[contador].AddTorque(torque);
                spriteRenderers[contador].sprite = spriteAtual;
            }
        }        
        yield return null;
    }

    private void restaurandoColetaveisParaOTubo(int indice)
    {   
        rigidBodies[indice].gravityScale = 0f;
        rigidBodies[indice].velocity = Vector2.zero;
        rigidBodies[indice].angularVelocity = 0f;
        tuboDto.ColetaveisParaTubo[indice].transform.position = posicoesOriginais[indice];        
    }

    private void triggerDeSaidaDeTuboAcionado(Collider2D coletavelSaindo)
    {
        if (Utils.isTag(coletavelSaindo, "ColetavelDoTubo"))
        {   
            restaurandoColetaveisParaOTubo(int.Parse(coletavelSaindo.name));
        }
    }

    private void inicializarArrays()
    {
        GameObject[] coletaveisParaTubo = tuboDto.ColetaveisParaTubo;

        posicoesOriginais = new Vector3[coletaveisParaTubo.Length];
        rigidBodies       = new Rigidbody2D[coletaveisParaTubo.Length];
        spriteRenderers   = new SpriteRenderer[coletaveisParaTubo.Length];

        for(int contador = 0; contador < coletaveisParaTubo.Length; contador++)
        {
            posicoesOriginais[contador] = coletaveisParaTubo[contador].transform.position;
            rigidBodies[contador]       = coletaveisParaTubo[contador].GetComponent<Rigidbody2D>();
            spriteRenderers[contador]   = coletaveisParaTubo[contador].GetComponent<SpriteRenderer>();
        }
    }

    private void configurarEventoTrigger()
    {
        tuboDto.ParentColetavelTubo
               .GetComponent<DetectorDeTriggers>()
               .registrarConsumidorDeTrigger(this);
    }

    //IMPLEMENTANDO INTERFACE ConsumidorDeEventoTrigger INICIO
    //ACIONADO QUANDO O COLETAVEL DO TUBO ATINGE O FIM DO TUBO
    public void consumir(Collider2D collider)
    {
        triggerDeSaidaDeTuboAcionado(collider);
    }
    //IMPLEMENTANDO INTERFACE ConsumidorDeEventoTrigger FIM
}
