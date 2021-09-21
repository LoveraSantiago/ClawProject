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
        ligar();
    }

    void AcaoColetado.ConsumidorEvento.consumirEvento(InformacoesColetadoDto evento)
    {
        if (evento.fimColetados)
        {
            mostrarModalResultado();
        }
        scoreAtual = evento.score.ToString();
    }

    void AcaoTempoEsgotado.ConsumidorEvento.consumirEvento(TempoEsgotado evento)
    {
        if (evento.isTimeOver())
        {
            mostrarModalResultado();
        }
    }

    void AcaoBoardElevadoFim.ConsumidorEvento.consumirEvento(BoardAcaoFim evento)
    {
        if (evento.isGameOver)
        {            
            mostrarModalResultado();
        }
    }

    void AcaoCacaNiquel.ConsumidorEvento.consumirEvento(CacaNiquelResult evento)
    {
        if (evento.isFinalizado)
        {

        }
    }

    private void mostrarModalResultado()
    {
        if (!mostrandoModal)
        {
            Utils.MonoBehaviour.StartCoroutine(coroutineMostrarModalResultado());
        }
    }

    private IEnumerator coroutineMostrarModalResultado()
    {        
        mostrandoModal = true;                   
        yield return new WaitForSeconds(0.5f);
        mostrarModalResultLevel();
    }     
}
