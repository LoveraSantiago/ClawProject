using UnityEngine;

public class ColetavelManager : ContadorDeColetaveis.ColetavelCallback, 
                                TransformadorDeEvento<GameObject, InformacoesColetado>
{   
    private ColetaveisDto coletaveisDto;
    private ContadorDeColetaveis contadorDeColetaveis;

    public ColetavelManager(ColetaveisDto coletaveisDto)
    {
        //contadorDeColetaveis = new ContadorDeColetaveis(coletaveisDto.ColetadosPosicoes, this);
        contadorDeColetaveis = new ContadorDeColetaveis(this);

        this.coletaveisDto = coletaveisDto;        
    }

    private InformacoesColetado processarColetado(GameObject gameObjectColetado)
    {        
        Sprite sprite = gameObjectColetado.GetComponent<SpriteRenderer>().sprite;
        gameObjectColetado.SetActive(false);
        
        contadorDeColetaveis.adicionarColetado(gameObjectColetado.name);        

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
            atualizaScore();
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
    //É O PRIMEIRO DO PIPELINEDEEVENTOCOLETADO 
    //RECEBE UM GAMEOBJECT E DEVOLVE UM INFORMACOESCOLETADOS
    public InformacoesColetado transformarEvento(GameObject gameObjectColetado)
    {
        return processarColetado(gameObjectColetado);        
    }
    //IMPLEMENTACAO INTERFACE TransformadorDeEvento<GameObject, InformacoesColetado> FIM
}
