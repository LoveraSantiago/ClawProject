using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemontadorLabelsBoard 
{
    private ListaDeSprites listaDeSprites;
    private ReferenciasDoBoardPositivo referencias;

    public RemontadorLabelsBoard(
        ReferenciasDoBoardPositivo referencias, ListaDeSprites listaDeSprites)
    {
        this.listaDeSprites = listaDeSprites;
        this.referencias = referencias;
    }

    public void montarLabels(BoardOrdem[] boardOrdem)
    {
        if (boardOrdem == null)
        {
            return;
        }

        int contadorNome = 0;
        for (int contadorLinha = 0; contadorLinha < referencias.dicionarioTextLabels.Count; contadorLinha++)
        {
            Dictionary<int, Text> dicionarioLinha = referencias.dicionarioTextLabels[0];
            for (int contadorColuna = 0; contadorColuna < dicionarioLinha.Count; contadorColuna++)
            {
                GameObject goReferencias = referencias.dicionarioGosBoard[contadorLinha][contadorColuna];
                SpriteRenderer sprRenderer = goReferencias.GetComponent<SpriteRenderer>();
                if (!sprRenderer.sprite.name.Equals(listaDeSprites.getSpriteVazio().name))
                {
                    int nomeOrdem = contadorNome + 1;
                    BoardOrdem boardOrdemIt = getOrdemByNome(nomeOrdem, boardOrdem);
                    if (boardOrdem != null)
                    {
                        Text text = referencias.dicionarioTextLabels[contadorLinha][contadorColuna];
                        text.text = boardOrdemIt.ordem.ToString();
                    }
                    contadorNome++;
                }
            }
        }
    }

    private BoardOrdem getOrdemByNome(int nomeOrdem, BoardOrdem[] boardOrdem)
    {
        string nomeOrdemString = nomeOrdem.ToString();
        for (int contador = 0; contador < boardOrdem.Length; contador++)
        {
            if (boardOrdem[contador].nome.Equals(nomeOrdemString))
            {
                return boardOrdem[contador];
            }
        }
        return null;
    }
}
