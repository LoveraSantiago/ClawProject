using UnityEngine;

public class ColetavelManager : TransformadorDeEvento<GameObject, InformacoesColetado>
{      
    private ContadorDeColetaveis contadorDeColetaveis;

    private ColetaveisParaBoard coletaveisDeVoltaBoard;
    private ColetaveisParaTuboDeSaida coletaveisSaidaTubo;

    public ColetavelManager()
    {        
        contadorDeColetaveis = new ContadorDeColetaveis();
        coletaveisSaidaTubo = new ColetaveisParaTuboDeSaida();
        coletaveisDeVoltaBoard = new ColetaveisParaBoard();
    }

    private InformacoesColetado processarColetado(GameObject gameObjectColetado)
    {        
        Sprite sprite = gameObjectColetado.GetComponent<SpriteRenderer>().sprite;
        gameObjectColetado.SetActive(false);
        
        contadorDeColetaveis.adicionarColetado(gameObjectColetado.name, coletaveisSaidaTubo, coletaveisDeVoltaBoard);        

        AudioController.current.PlayAudio(AudioController.current.coletar);

        InformacoesColetado infoColetado = new InformacoesColetado();
        infoColetado.addInfosDisplayColetados(sprite, contadorDeColetaveis.hasResetColetados());
        infoColetado.addInfosDisplayScore(contadorDeColetaveis.getScore());
        return infoColetado;
    }

    public void FixedUpdate() { }

    public void match(bool result)
    {
        if (result)
        {
            //atualizaScore();
        }
        else
        {
            
        }
    }

    //private void atualizaScore()
    //{        
    //    //REMOVER DO DTO
    //    coletaveisDto.ScoreTextField.text = score.ToString();        
    //}   

    public TransformadorDeEvento<GameObject, InformacoesColetado> getProcessadorDeColetado()
    {
        return this;
    }

    //IMPLEMENTACAO INTERFACE TransformadorDeEvento<GameObject, InformacoesColetado> INICIO
    //� O PRIMEIRO DO PIPELINEDEEVENTOCOLETADO 
    //RECEBE UM GAMEOBJECT E DEVOLVE UM INFORMACOESCOLETADOS
    public InformacoesColetado transformarEvento(GameObject gameObjectColetado)
    {
        return processarColetado(gameObjectColetado);        
    }
    //IMPLEMENTACAO INTERFACE TransformadorDeEvento<GameObject, InformacoesColetado> FIM
}
