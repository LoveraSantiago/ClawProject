/*
 * Copyright (c) 2017 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Board 
{    
    private int xSize, ySize;
    private float shakeTile;
    private Transform startBoard;
    private List<Sprite> characters;
    private Coletavel[,] tiles;    
    private BoardDto boardDto;

    public Board(BoardDto boardDto)
    {        
        characters = boardDto.Characters;
        xSize = boardDto.XSize;
        ySize = boardDto.YSize;
        shakeTile = boardDto.ShakeTile;
        startBoard = boardDto.StartBoard;               

        this.boardDto = boardDto;                
    }

    public void Create(PoolDeColetaveis poolDeColetaveis)
    {
        float yOffset = boardDto.SpriteTile.bounds.size.y;
        //xOffset = boardManagerDto.spriteTile.bounds.size.x;
        float xOffset = 1;//TEMPORARIO AQUI

        tiles = new Coletavel[xSize, ySize];
       
        float startX = startBoard.position.x;
        float startY = startBoard.position.y;

        Sprite[] previousLeft = new Sprite[ySize];
        Sprite previousBelow = null;

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                shakeTile *= -1;
                Vector3 posCalculada = new Vector3(startX + shakeTile + (xOffset * x), startY + (yOffset * y), 0);

                Coletavel coletavel = poolDeColetaveis.criarColetavel();
                coletavel.colocarNaPosicao(posCalculada);                

                tiles[x, y] = coletavel;

                List<Sprite> possibleCharacters = new List<Sprite>();
                possibleCharacters.AddRange(characters);
                Sprite newSprite = possibleCharacters[Random.Range(0, possibleCharacters.Count)];

                possibleCharacters.Remove(previousLeft[y]);
                possibleCharacters.Remove(previousBelow);

                coletavel.receberSprite(newSprite);
            }
        }
    }

    public int getTotalColetaveis()
    {
        return xSize * ySize;
    }

    public void devolver(Coletavel[] coletados, MonoBehaviour monoBehaviour)
    {
        if (coletados.Length > 0)
        {
            monoBehaviour.StartCoroutine(devolverParaBoard(coletados));
        }        
    }

    private IEnumerator devolverParaBoard(Coletavel[] coletados)
    {
        yield return new WaitForSeconds(boardDto.DelayInicialVoltaBoard);

        for (int contador = 0; contador < coletados.Length; contador++)
        {
            float anguloDevolucao = Random.Range(180, 230);
            Coletavel coletavel = coletados[contador];
            coletavel.ligar();
            coletavel.disparar(boardDto.PosicaoRefVoltaBoard.position, anguloDevolucao, 10f);

            yield return new WaitForSeconds(boardDto.DelayVoltaBoard);
        }
        yield return null;
    }
}
