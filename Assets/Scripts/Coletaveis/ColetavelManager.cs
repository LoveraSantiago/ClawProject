using UnityEngine;

public class ColetavelManager : TransformadorDeEvento<GameObject, InformacoesColetado>
{
    private ColetaveisDto coletaveisDto;
    private ContadorDeColetaveis contadorDeColetaveis;
    private ColetaveisParaBoard coletaveisDeVoltaBoard;
    private ColetaveisParaTuboDeSaida coletaveisSaidaTubo;
    private Board board;

    public ColetavelManager(ColetaveisDto coletaveisDto)
    {
        CriarBoard(coletaveisDto.BoardDto);

        this.coletaveisDto = coletaveisDto;
        contadorDeColetaveis = new ContadorDeColetaveis(board.getTotalColetaveis());
        coletaveisDeVoltaBoard = new ColetaveisParaBoard();
        coletaveisSaidaTubo = new ColetaveisParaTuboDeSaida(coletaveisDto);

        
    }

    private void CriarBoard(BoardDto boardDto)
    {
        board = new Board(boardDto);
        board.Create();
    }

    private InformacoesColetado processarColetado(GameObject gameObjectColetado)
    {
        Sprite sprite = gameObjectColetado.GetComponent<SpriteRenderer>().sprite;
        gameObjectColetado.SetActive(false);

        contadorDeColetaveis.adicionarColetado(gameObjectColetado.name);

        board.devolver(contadorDeColetaveis.getArrayBoard());
        coletaveisSaidaTubo.devolver(contadorDeColetaveis.getArrayTubo());

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
