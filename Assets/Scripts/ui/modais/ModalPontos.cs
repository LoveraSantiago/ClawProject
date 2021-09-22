using System.Collections;
using UnityEngine;

public class ModalPontos : AcaoColetado.ConsumidorEvento,
                           AcaoTempoEsgotado.ConsumidorEvento,
                           AcaoBoardElevadoFim.ConsumidorEvento,
                           AcaoCacaNiquel.ConsumidorEvento
{
    private string scoreAtual;
    private bool mostrandoModal;

    private ModalPontosDto modalPontosDto;
    private LinhaModalPontos[] linhasModal;

    public ModalPontos(ModalPontosDto modalPontosDto)
    {
        this.modalPontosDto = modalPontosDto;
        linhasModal = new LinhaModalPontos[modalPontosDto.Linhas.Length];
        for(int contador = 0; contador < linhasModal.Length; contador++)
        {
            linhasModal[contador] = new LinhaModalPontos(modalPontosDto.Linhas[contador]);
        }
    }

    public void configurarLevel(string levelName)
    {
        setNivel(levelName);
    }

    private void ligar()
    {
        modalPontosDto.GoModalPontos.SetActive(true);
    }

    private void setPontuacao()
    {
        modalPontosDto.TextoPontos.text = scoreAtual;
    }

    private void setNivel(string levelName)
    {
        modalPontosDto.TextoNivel.text = levelName;
    }

    private void naoMostrarLinhasResult()
    {
        linhasModal[0].desligar();
        linhasModal[1].desligar();
        linhasModal[2].desligar();
        linhasModal[3].desligar();
    }

    private void mostrarModalResultLevel()
    {
        setPontuacao();
        naoMostrarLinhasResult();        
    }

    private void mostrarModalPontuacao()
    {
        if (!mostrandoModal)
        {
            setPontuacao();
            naoMostrarLinhasResult();
            Utils.MonoBehaviour.StartCoroutine(coroutineMostrarModal());
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

            string[] nomes = FactoryPowerUpEntidade.getNomesPupsBySprites(evento.sprResultados);

            linhasModal[0].passarInfos(nomes[0], evento.sprResultados[0], "1");
            linhasModal[1].passarInfos(nomes[1], evento.sprResultados[1], "1");
            linhasModal[2].passarInfos(nomes[2], evento.sprResultados[2], "1");

            Utils.MonoBehaviour.StartCoroutine(coroutineMostrarModal());
        }
    }

    private IEnumerator coroutineMostrarModal()
    {        
        mostrandoModal = true;                   
        yield return new WaitForSeconds(0.5f);
        ligar();
    }

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        scoreAtual = evento.score.ToString();
        if (evento.fimColetados)
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

    void AcaoBoardElevadoFim.ConsumidorEvento.consumirEvento(BoardAcaoFim evento)
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
            if(evento.tipoGame == AbstractLevel.TIPO_GAME.CACANIQUEL_PUP_GERAL)
            {
                mostrarModalCacaNiquelAllPups();
            }
            else if (evento.tipoGame == AbstractLevel.TIPO_GAME.CACANIQUEL_PUP_INDIVIDUAL)
            {

            }
        }
    }

}
