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
        bool combinacaoValida, ColetadoFimDto evento, Coletavel[] coletados)
    {
        if (isDevolver(combinacaoValida, evento))
        {
            //Debug.Log("Devolver tubo acionado");
            Utils.MonoBehaviour.StartCoroutine(descerPeloTubo(evento.clears, coletados));
        }
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
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        for (int contador = 0; contador < coletados.Length; contador++)
        {
            if (resultados[contador])
            {
                torque *= -1;
                Sprite spriteAtual = coletados[contador].getSprite();

                ColetavelTuboDeSaida coletavelDescarte = new ColetavelTuboDeSaida(tuboDto.ColetavelTuboDeSaida[contador]);
                coletavelDescarte.prepararParaDescarte(torque, tuboDto.Gravidade, spriteAtual);
                helperInGame.inativarColetavel(coletados[contador]);                
            }
        }        
        yield return null;
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
