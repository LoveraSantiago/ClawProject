using System.Collections;
using UnityEngine;

public class ModalResultadosManager : AcaoColetado.ConsumidorEvento,
                           AcaoTempoEsgotado.ConsumidorEvento,
                           AcaoBoardElevadoFim.ConsumidorEvento,
                           AcaoCacaNiquel.ConsumidorEvento
{    
    private bool mostrandoModal;

    private ModalPontosDto modalPontosDto;    
    private ModalResultados modalResultado;

    public ModalResultadosManager(ModalPontosDto modalPontosDto)
    {
        this.modalPontosDto = modalPontosDto;        
    }

    public void configurarLevel(string levelName)
    {        
        modalResultado = new ModalResultados(levelName, modalPontosDto);
    }          

    private void mostrarModalResultLevel()
    {   
        modalResultado.naoMostrarLinhasResult();        
    }

    private void mostrarModalPontuacao()
    {
        if (!mostrandoModal)
        {
            modalResultado.configurarResultado();   
            Utils.MonoBehaviour.StartCoroutine(coroutineMostrarModal());
        }
    }

    private void mostrarModalColetados()
    {
        if (!mostrandoModal)
        {
            modalResultado.naoMostrarLinhasResult();            
            Utils.MonoBehaviour.StartCoroutine(coroutineMostrarModal());
        }
    }

    private void mostrarModalCacaNiquelSinglePup(CacaNiquelResult evento)
    {
        if (!mostrandoModal)
        {
            linhasModal[0].ligar();
            linhasModal[1].ligar();
            linhasModal[2].ligar();
            linhasModal[3].desligar();

            int indicePup = PlayerPrefsPup.recuperarIndicePup();
            PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);

            montarLinhaPupSingle(0, evento, pupEscolhido);
            montarLinhaPupSingle(1, evento, pupEscolhido);
            montarLinhaPupSingle(2, evento, pupEscolhido);

            if (evento.isTripleSucess())
            {
                linhasModal[3].ligar();
                linhasModal[3].passarInfos("Bonus!!!", pupEscolhido.sprPowerUp, "3");
                PlayerPrefsPup.adicionarPup(pupEscolhido.nome, 3);
            }     
            else if (evento.isTripleFail())
            {
                linhasModal[3].ligar();
                linhasModal[3].passarInfos("Consolação", pupEscolhido.sprPowerUp, "1");
                PlayerPrefsPup.adicionarPup(pupEscolhido.nome, 1);
            }

            modalResultado.setScoreAtual("Power Ups Ganhos");                        
            Utils.MonoBehaviour.StartCoroutine(coroutineMostrarModal());
        }
    }

    private void montarLinhaPupSingle(int indice, CacaNiquelResult evento, PowerUpEntidade pup)
    {

        if(evento.isResultSucesso(indice))
        {
            linhasModal[indice].passarInfos(pup.nome, evento.sprResultados[indice], "OK");
            PlayerPrefsPup.adicionarPup(pup.nome, 1);
        }
        else if(evento.isResultFail(indice))
        {
            linhasModal[indice].passarInfos("Nada", evento.sprResultados[indice], "NOK");
        }
        else
        {
            linhasModal[indice].passarInfos("Ficha", evento.sprResultados[indice], "OK");
        }
    }

    private void mostrarModalCacaNiquelAllPups(CacaNiquelResult evento)
    {
        if (!mostrandoModal)
        {
            linhasModal[0].ligar();
            linhasModal[1].ligar();
            linhasModal[2].ligar();
            linhasModal[3].desligar();

            string[] nomes = PowerUpHelper.getNomesPupsBySprites(evento.sprResultados);

            linhasModal[0].passarInfos(nomes[0], evento.sprResultados[0], "1");
            linhasModal[1].passarInfos(nomes[1], evento.sprResultados[1], "1");
            linhasModal[2].passarInfos(nomes[2], evento.sprResultados[2], "1");

            PlayerPrefsPup.adicionarPup(nomes[0], 1);
            PlayerPrefsPup.adicionarPup(nomes[1], 1);
            PlayerPrefsPup.adicionarPup(nomes[2], 1);

            modalResultado.setScoreAtual("Power Ups Ganhos");            
            
            Utils.MonoBehaviour.StartCoroutine(coroutineMostrarModal());
        }
    }

    private void mostrarModalOrdemFail(int ordem)
    {
        modalResultado.naoMostrarLinhasResult();
        modalResultado.setScoreAtual("Não seguiu ordem " + ordem);                
        Utils.MonoBehaviour.StartCoroutine(coroutineMostrarModal());
    }  

    private IEnumerator coroutineMostrarModal()
    {      
        mostrandoModal = true;                   
        yield return new WaitForSeconds(0.5f);
        modalResultado.ligar();
    }

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {        
        modalResultado.setScoreAtual(evento.score.ToString());
        InformacoesFimDeJogoDto infoFimDeJogo = evento.infosFimDeJogo;
        if (infoFimDeJogo.fimColetados)
        {
            mostrarModalPontuacao();
        }
        else if (infoFimDeJogo.erroOrdem)
        {
            mostrarModalOrdemFail(evento.ordem);
        }
        else if (infoFimDeJogo.trincaColetaveis)
        {
            mostrarModalPontuacao();
        }
    }

    void AcaoTempoEsgotado.ConsumidorEvento.consumirEvento(TempoEsgotado evento)
    {
        if (evento.isTimeOver())
        {
            mostrarModalPontuacao();
        }
    }

    void AcaoBoardElevadoFim.ConsumidorEvento.consumirEvento(SubidaBoardAcaoFim evento)
    {
        if (evento.isGameOver)
        {
            mostrarModalPontuacao();
        }
    }    

    void AcaoCacaNiquel.ConsumidorEvento.consumirEvento(CacaNiquelResult evento)
    {
        if (evento.isFinalizado)
        {
            if(evento.isPupGeral())
            {
                mostrarModalCacaNiquelAllPups(evento);
            }
            else if (evento.isPupSingle())
            {
                mostrarModalCacaNiquelSinglePup(evento);
            }
        }
    }

}
