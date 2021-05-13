using System.Collections;
using UnityEngine;

public class ModalPontos : ConsumidorDeEvento<InformacoesColetado>,
                           ConsumidorDeEvento<bool>
{
    private string scoreAtual;
    private bool mostrandoModal;
    private ModalPontosDto modalPontosDto;
    private MonoBehaviour monoBehaviour;

    public ModalPontos(ModalPontosDto modalPontosDto, MonoBehaviour monoBehaviour)
    {
        this.modalPontosDto = modalPontosDto;
        this.monoBehaviour = monoBehaviour;
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

    public void consumirEvento(InformacoesColetado infoColetado)
    {
        if (infoColetado.fimColetados)
        {
            mostrarModalResultado();
        }
        scoreAtual = infoColetado.score.ToString();
    }

    public void consumirEvento(bool evento)
    {
        mostrarModalResultado();
    }

    private void mostrarModalResultado()
    {
        if (!mostrandoModal)
        {
            monoBehaviour.StartCoroutine(coroutineMostrarModalResultado());
            mostrandoModal = true;
        }
    }

    private IEnumerator coroutineMostrarModalResultado()
    {        
        yield return new WaitForSeconds(0.5f);
        ligar();
        setPontuacao();
    }

    public ConsumidorDeEvento<InformacoesColetado> getConsumidorDeInformacoesColetado()
    {
        return this;
    }

    internal ConsumidorDeEvento<bool> getConsumidorDeTempoEsgotado()
    {
        return this;
    }   
}
