using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ContadorDeColetaveis
{
    private int score = 0;
    private int qtdColetados = 0;

    private bool backToBoard;
    private bool resultCombinacao;
    private int totalColetaveis;

    private Coletavel[] coletados;
    private Coletavel[] devolverBoard;
    private Coletavel[] devolverTubo;
    private Coletavel[] arrayVazio;

    private GameObject pontosModal;
    private MonoBehaviour monoBehaviour;

    public ContadorDeColetaveis(GameObject pontosModal, MonoBehaviour monoBehaviour)
    {
        this.monoBehaviour = monoBehaviour;
        this.pontosModal = pontosModal; // Todo - Level 1 - para mostrar modal de pontuação total

        coletados = new Coletavel[3];
        arrayVazio = new Coletavel[0];        
    }

    public void configurarTotalColetaveis(int total, bool backToBoard)
    {
        this.totalColetaveis = total;
        this.backToBoard = backToBoard;        
    }

    public void adicionarColetado(Coletavel coletado)
    {
        // Debug.Log(nomeColetado);
        adicionaAoContainerDeColetados(coletado);

        if (qtdColetados > coletados.Length - 1)
        {
            if (isCombinacaoValida())
            {
                processarRetornoValido();
            }
            else
            {
                processarRetornoInvalido();
            }
            resetarColetados();
        }
        else
        {
            resultCombinacao = false;
            devolverBoard = arrayVazio;
            devolverTubo = arrayVazio;
        }

        score += 10;

        if (totalColetaveis <= 0)
        {
            //resetCena();
            monoBehaviour.StartCoroutine(waitToShow());                 
        }
    }

    public Coletavel[] getArrayBoard()
    {
        return devolverBoard;
    }

    public Coletavel[] getArrayTubo()
    {
        return devolverTubo;
    }

    public void resetCena()
    {
        SceneManager.LoadScene("MapScene");
    }

    public void showPontuacao()
    {       
        pontosModal.SetActive(true);

        GameObject pontosText = GameObject.Find("PointsText");

        if (pontosText != null)
        {
            pontosText.GetComponent<Text>().text = score.ToString();
        }
    }

    IEnumerator waitToShow()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.5f);

        showPontuacao();
    }    

    public bool getResult()
    {
        return resultCombinacao;
    }

    private bool isCombinacaoValida()
    {
        Coletavel primeiroColetado = coletados[0];
        for (int contador = 0; contador < coletados.Length; contador++)
        {
            if (!primeiroColetado.hasEqualsSprite(coletados[contador]))
            {
                resultCombinacao = false;
                return false;
            }
        }
        resultCombinacao = true;
        return true;
    }

    private void adicionaAoContainerDeColetados(Coletavel coletado)
    {
        coletados[qtdColetados] = coletado;
        qtdColetados++;
    }

    private void processarRetornoValido()
    {
        AudioController.current.PlayAudio(AudioController.current.combinacaoOk);
        adicionaPontuacao();
        devolverBoard = arrayVazio;
        devolverTubo = coletados;
        totalColetaveis -= 3;
    }

    private void processarRetornoInvalido()
    {
        if (backToBoard)
        {
            devolverBoard = coletados;
            devolverTubo = arrayVazio;
            AudioController.current.PlayAudio(AudioController.current.combinacaoNok);

            totalColetaveis -= 0;
        }
        else
        {
            devolverBoard = coletados;
            devolverTubo  = coletados;

            totalColetaveis -= 3;
        }
        AudioController.current.PlayAudio(AudioController.current.combinacaoNok);
    }

    private void adicionaPontuacao()
    {
        score += 90;
    }

    public int getScore()
    {
        return score;
    }

    private void resetarColetados()
    {
        qtdColetados = 0;
    }
}
