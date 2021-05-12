using System.Collections;
using UnityEngine;

public class ModalPontos : ConsumidorDeEvento<InformacoesColetado>
{    
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

    private void setPontuacao(string pontos)
    {
        modalPontosDto.TextoPontos.text = pontos;
    }

    private void setNivel(string levelName)
    {
        modalPontosDto.TextoNivel.text = levelName;
    }

    public void consumirEvento(InformacoesColetado infoColetado)
    {
        if (infoColetado.fimColetados)
        {
            monoBehaviour.StartCoroutine(waitToShow(infoColetado.score.ToString()));
        }
    }

    private IEnumerator waitToShow(string pontos)
    {        
        yield return new WaitForSeconds(0.5f);
        ligar();
        setPontuacao(pontos);
    }

    public ConsumidorDeEvento<InformacoesColetado> getConsumidorDeInformacoesColetado()
    {
        return this;
    }
}
