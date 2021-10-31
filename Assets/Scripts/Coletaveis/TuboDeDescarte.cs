using System.Collections;
using UnityEngine;

public class TuboDeDescarte : ConsumidorDeEventoTrigger
{
    private bool devolverTubo;    
    private float torque;    

    private Vector3[] posicoesOriginais;
    private DescarteTuboDto tuboDto;

    public TuboDeDescarte(DescarteTuboDto tuboDto)
    {
        this.tuboDto = tuboDto;

        inicializarArrays();
        configurarEventoTrigger();        
        
        torque = tuboDto.Torque;        
    }

    public void configuradoPeloLevel(bool devolverParaBoard)
    {
        devolverTubo = !devolverParaBoard;
    }

    public void devolver(
        bool combinacaoValida, ColetadoFim evento, 
        ColetavelTile[] coletados, PoolDeColetaveis poolDeColetaveis)
    {
        if (isLigadoECompleto(evento) || 
            isDesligadoMasValido(combinacaoValida) || 
            evento.isDescarte)
        {
            //Debug.Log("Devolver tubo acionado");
            Utils.MonoBehaviour.StartCoroutine(descerPeloTubo(evento.clears, coletados, poolDeColetaveis));
        }
    }

    private bool isLigadoECompleto(ColetadoFim evento)
    {
        return devolverTubo && evento.isTodosColetados();
    }

    private bool isDesligadoMasValido(bool combinacaoValida)
    {
        return !devolverTubo && combinacaoValida;
    }

    private IEnumerator descerPeloTubo(
        bool[] resultados, ColetavelTile[] coletados, PoolDeColetaveis poolDeColetaveis)
    {        
        
        for (int contador = 0; contador < coletados.Length; contador++)
        {
            if (resultados[contador])
            {
                torque *= -1;
                Sprite spriteAtual = coletados[contador].getSprite();
                ColetavelTuboDeSaidaDto coletavelTuboSaidaIt = tuboDto.ColetavelTuboDeSaida[contador];
                coletavelTuboSaidaIt.RigidBodyColetavel.gravityScale = tuboDto.Gravidade;
                coletavelTuboSaidaIt.RigidBodyColetavel.AddTorque(torque);
                coletavelTuboSaidaIt.SprRendererColetavel.sprite = spriteAtual;

                coletavelTuboSaidaIt.GoTrail.SetActive(true);
                coletavelTuboSaidaIt.RigidBodyTrail.gravityScale = tuboDto.Gravidade;
                coletavelTuboSaidaIt.ParticulasTrail.Play();

                poolDeColetaveis.inativarColetavel(coletados[contador]);
            }
        }        
        yield return null;
    }

    private void restaurandoColetaveisParaOTubo(int indice)
    {
        ColetavelTuboDeSaidaDto coletavelTuboSaidaIt = tuboDto.ColetavelTuboDeSaida[indice];
        float zero = 0f;
        coletavelTuboSaidaIt.RigidBodyColetavel.gravityScale = zero;
        coletavelTuboSaidaIt.RigidBodyColetavel.angularVelocity = zero;
        coletavelTuboSaidaIt.RigidBodyColetavel.velocity = Vector2.zero;
        coletavelTuboSaidaIt.TransformColetavel.position = posicoesOriginais[indice];

        coletavelTuboSaidaIt.RigidBodyTrail.gravityScale = zero;
        coletavelTuboSaidaIt.RigidBodyTrail.angularVelocity = zero;
        coletavelTuboSaidaIt.RigidBodyTrail.velocity = Vector2.zero;
        coletavelTuboSaidaIt.ParticulasTrail.Stop();
        coletavelTuboSaidaIt.GoTrail.SetActive(false);
        coletavelTuboSaidaIt.TransformTrail.position = posicoesOriginais[indice];
    }

    private void triggerDeSaidaDeTuboAcionado(Collider2D coletavelSaindo)
    {
        if (UtilsTags.isNome(coletavelSaindo, "ColetavelDoTubo"))
        {   
            restaurandoColetaveisParaOTubo(int.Parse(coletavelSaindo.name));
        }
    }

    private void inicializarArrays()
    {
        ColetavelTuboDeSaidaDto[] coletaveisParaTubo = tuboDto.ColetavelTuboDeSaida;
        posicoesOriginais = new Vector3[coletaveisParaTubo.Length];        

        for(int contador = 0; contador < coletaveisParaTubo.Length; contador++)
        {
            posicoesOriginais[contador] = coletaveisParaTubo[contador].TransformColetavel.position;            
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
