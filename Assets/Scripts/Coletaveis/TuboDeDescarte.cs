using System.Collections;
using UnityEngine;

public class TuboDeDescarte : ConsumidorDeEventoTrigger,
                              Fornecedor<ColetaveisDescartadosDto>
{
    private bool devolverTubo;    
    private float torque;    

    private Vector3[] posicoesOriginais;
    private DescarteTuboDto tuboDto;
    private ColetaveisDescartadosDto coletaveisDescartados;
    private SomColetagem somColetagem;

    public TuboDeDescarte(DescarteTuboDto tuboDto, SomColetagem somColetagem)
    {
        this.tuboDto = tuboDto;
        this.somColetagem = somColetagem;
        
        inicializarArrays();
        configurarEventoTrigger();                
        torque = tuboDto.Torque;
        coletaveisDescartados = new ColetaveisDescartadosDto();
    }

    public void configuradoPeloLevel(bool devolverParaBoard)
    {
        devolverTubo = !devolverParaBoard;
    }

    public void devolver(ContadorManager contador, ColetadoFimDto evento)
    {
        if (isDevolver(contador.getResultCombinacao(), evento))
        {
            //Debug.Log("Devolver tubo acionado");
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(descerPeloTubo(evento.clears, contador.getColetados()));
        }
    }

    public ColetaveisDescartadosDto fornecer()
    {
        return coletaveisDescartados;
    }

    private bool isDevolver(bool combinacaoValida, ColetadoFimDto evento)
    {
        return isLigadoECompleto(evento) ||
               isDesligadoMasValido(combinacaoValida) ||
               evento.isDescarte;
    }

    private bool isLigadoECompleto(ColetadoFimDto evento)
    {
        return devolverTubo && evento.isTodosColetados();
    }

    private bool isDesligadoMasValido(bool combinacaoValida)
    {
        return !devolverTubo && combinacaoValida;
    }

    private IEnumerator descerPeloTubo(bool[] resultados, Coletavel[] coletados)
    {
        Sprite[] spritesDescarte = new Sprite[coletados.Length];
        Coletavel[] coletadosCopia = ArrayUtils.copiarArray<Coletavel>(coletados);

        for (int contador = 0; contador < coletadosCopia.Length; contador++)
        {
            if (resultados[contador])
            {
                torque *= -1;
                Sprite spriteAtual = coletadosCopia[contador].getSprite();
                spritesDescarte[contador] = spriteAtual;

                ColetavelTuboDeSaida coletavelDescarte = new ColetavelTuboDeSaida(tuboDto.ColetavelTuboDeSaida[contador]);
                coletavelDescarte.prepararParaDescarte(torque, tuboDto.Gravidade, spriteAtual);
                HelperColetaveisInGame.inativarColetavel(coletadosCopia[contador]);
                ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(playSonsColetadosCaindo());
                yield return new WaitForSeconds(tuboDto.DelayDescarte);
            }
        }
        coletaveisDescartados.addTrinca(spritesDescarte);
        yield return null;
    }

    private IEnumerator playSonsColetadosCaindo()
    {
        yield return new WaitForSeconds(tuboDto.DelaySomQueda);
        somColetagem.playSomColetadosCaindo();

        yield return new WaitForSeconds(tuboDto.DelaySomTubo);
        somColetagem.playSomColetadosNoTubo();
    }

    private void restaurandoColetaveisParaOTubo(int indice)
    {   
        ColetavelTuboDeSaida coletavelDescarte = new ColetavelTuboDeSaida(tuboDto.ColetavelTuboDeSaida[indice]);
        coletavelDescarte.restaurarParaProximoDescarte(posicoesOriginais[indice]);
    }

    private void triggerDeSaidaDeTuboAcionado(Collider2D coletavelSaindo)
    {
        if (TagUtils.isNome(coletavelSaindo, "ColetavelDoTubo"))
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
