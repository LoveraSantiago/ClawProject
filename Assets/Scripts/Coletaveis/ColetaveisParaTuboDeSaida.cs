using System.Collections;
using UnityEngine;

public class ColetaveisParaTuboDeSaida : ConsumidorDeEventoTrigger
{
    private readonly float GRAVIDADE = 0.65f;

    private int torque = 550;
    private int contadorSaindoTubo;

    private float delayQueda;    

    private Vector3[] posicoesOriginais;
    private Rigidbody2D[] rigidBodies;//TODO transformar esses caras em coletavel para mais facil manipulacaoS
    private SpriteRenderer[] spriteRenderers;
    private GameObject[] coletaveisParaTubo;    

    public ColetaveisParaTuboDeSaida(TuboDto tuboDto)
    {       
        inicializarArrays(tuboDto.ColetaveisParaTubo);
        configurarEventoTrigger(tuboDto.ParentColetavelTubo);
        
        this.delayQueda = tuboDto.DelayQuedaTubo;        
    }

    public void devolver(Coletavel[] coletados, MonoBehaviour monoBehaviour)
    {
        if(coletados.Length > 0)
        {
            monoBehaviour.StartCoroutine(descerPeloTubo(coletados));
        }
    }

    private IEnumerator descerPeloTubo(Coletavel[] coletados)
    {
        yield return new WaitForSeconds(delayQueda);
        if (coletados.Length > 0)
        {
            for (int contador = 0; contador < coletados.Length; contador++)
            {
                torque *= -1;
                Sprite spriteAtual = coletados[contador].getSprite();
                rigidBodies[contador].gravityScale = GRAVIDADE;
                rigidBodies[contador].AddTorque(torque);
                spriteRenderers[contador].sprite = spriteAtual;
            }
        }
        yield return null;
    }

    private void restaurandoColetaveisParaOTubo()
    {
        for (int contador = 0; contador < coletaveisParaTubo.Length; contador++)
        {
            rigidBodies[contador].gravityScale = 0f;
            rigidBodies[contador].velocity = Vector2.zero;
            rigidBodies[contador].angularVelocity = 0f;
            coletaveisParaTubo[contador].transform.position = posicoesOriginais[contador];
        }
    }

    private void triggerDeSaidaDeTuboAcionado(Collider2D coletavelSaindo)
    {
        if (Utils.isTag(coletavelSaindo, "ColetavelDoTubo"))
        {
            contadorSaindoTubo++;
            if (contadorSaindoTubo == 3)
            {
                restaurandoColetaveisParaOTubo();
                contadorSaindoTubo = 0;
            }
        }
    }

    private void inicializarArrays(GameObject[] coletaveisParaTubo)
    {
        this.coletaveisParaTubo = coletaveisParaTubo;
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

    private void configurarEventoTrigger(GameObject parentColetavelTubo)
    {
        parentColetavelTubo.GetComponent<DetectorDeTriggers>()
            .registrarConsumidorDeTrigger(this);
    }

    //IMPLEMENTANDO INTERFACE ConsumidorDeEventoTrigger INICIO
    //ACIONADO QUANDO O COLETAVEL DO TUBO ATINGE O FIM DO TUBO
    public void consumirEvento(Collider2D collider)
    {
        triggerDeSaidaDeTuboAcionado(collider);
    }
    //IMPLEMENTANDO INTERFACE ConsumidorDeEventoTrigger FIM
}
