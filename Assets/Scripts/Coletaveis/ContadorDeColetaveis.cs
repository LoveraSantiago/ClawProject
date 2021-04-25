using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ContadorDeColetaveis
{
    private int score = 0;
    private int qtdColetados = 0;

    private int decrementoComboValido;
    private int decrementoComboInvalido;

    private int totalColetaveis;

    private Coletavel[] coletados;
    private Coletavel[] devolverBoard;
    private Coletavel[] deveolverTubo;
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

        if (backToBoard)
        {
            decrementoComboValido = 3;
            decrementoComboInvalido = 0;
        }
        else
        {
            decrementoComboValido = 3;
            decrementoComboInvalido = 3;
        }
    }

    public void adicionarColetado(Coletavel coletado)
    {
        // Debug.Log(nomeColetado);
        adicionaAoContainerDeColetados(coletado);

        if (qtdColetados > coletados.Length - 1)
        {
            if (isCombinacaoValida())
            {
                AudioController.current.PlayAudio(AudioController.current.combinacaoOk);
                adicionaPontuacao();
                devolverBoard = arrayVazio;
                deveolverTubo = coletados;
                totalColetaveis -= decrementoComboValido;
            }
            else
            {
                devolverBoard = coletados;
                deveolverTubo = arrayVazio;
                AudioController.current.PlayAudio(AudioController.current.combinacaoNok);

                totalColetaveis -= decrementoComboInvalido;
            }
            resetarColetados();
        }
        else
        {
            devolverBoard = arrayVazio;
            deveolverTubo = arrayVazio;
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
        return deveolverTubo;
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

    public bool hasResetColetados()
    {
        return qtdColetados == 0;
    }

    public bool getResult()
    {
        return deveolverTubo == coletados;
    }

    private bool isCombinacaoValida()
    {
        Coletavel primeiroColetado = coletados[0];
        for (int i = 0; i < coletados.Length; i++)
        {
            if (!primeiroColetado.hasEqualsSprite(coletados[i]))
            {
                return false;
            }
        }
        return true;
    }

    private void adicionaAoContainerDeColetados(Coletavel coletado)
    {
        coletados[qtdColetados] = coletado;
        qtdColetados++;
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
