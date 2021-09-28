using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModalPontos : AcaoColetado.ConsumidorEvento,
                           AcaoTempoEsgotado.ConsumidorEvento,
                           AcaoBoardElevadoFim.ConsumidorEvento,
                           AcaoCacaNiquel.ConsumidorEvento
{
    private static readonly string MAPSCENE = "MapScene";
    private static readonly string PUPSCENE = "PupScene";

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
            Utils.MonoBehaviour.StartCoroutine(coroutineMostrarModal(MAPSCENE));
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

            scoreAtual = "Power Ups Ganhos";
            setPontuacao();
            Utils.MonoBehaviour.StartCoroutine(coroutineMostrarModal(PUPSCENE));
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

            string[] nomes = FactoryPowerUpEntidade.getNomesPupsBySprites(evento.sprResultados);

            linhasModal[0].passarInfos(nomes[0], evento.sprResultados[0], "1");
            linhasModal[1].passarInfos(nomes[1], evento.sprResultados[1], "1");
            linhasModal[2].passarInfos(nomes[2], evento.sprResultados[2], "1");

            PlayerPrefsPup.adicionarPup(nomes[0], 1);
            PlayerPrefsPup.adicionarPup(nomes[1], 1);
            PlayerPrefsPup.adicionarPup(nomes[2], 1);

            scoreAtual = "Power Ups Ganhos";
            setPontuacao();

            Utils.MonoBehaviour.StartCoroutine(coroutineMostrarModal(PUPSCENE));
        }
    }

    private void mostrarModalOrdemFail(int ordem)
    {
        naoMostrarLinhasResult();
        scoreAtual = "Não conseguiu seguir a ordem " + ordem;
        setPontuacao();
        Utils.MonoBehaviour.StartCoroutine(coroutineMostrarModal(MAPSCENE));
    }

    private IEnumerator coroutineMostrarModal(string nomeCena)
    {
        modalPontosDto.BtnAvancar.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(nomeCena);
        });
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
        else if (evento.fimErroOrdem)
        {
            mostrarModalOrdemFail(evento.ordem);
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
