using System.Collections;
using UnityEngine;

public class ModalPontos : AcaoColetado.ConsumidorEvento,
                           Consumidor<bool>
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

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetado evento)
    {
        if (evento.fimColetados)
        {
            mostrarModalResultado();
        }
        scoreAtual = evento.score.ToString();
    }

    public void consumir(bool evento)
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

    internal Consumidor<bool> getConsumidorDeTempoEsgotado()
    {
        return this;
    }   
}
