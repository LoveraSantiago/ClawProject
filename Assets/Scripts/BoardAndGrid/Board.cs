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

public class Board 
{    
    private SpriteRenderer spriteTile;
    private int xSize, ySize;
    private float shakeTile;
    private Transform startBoard;
    private List<Sprite> characters;
    private Coletavel[,] tiles;
    private float xOffset;
    private float yOffset;    

    public Board(BoardDto boardManagerDto)
    {        
        characters = boardManagerDto.characters;
        spriteTile = boardManagerDto.spriteTile;
        xSize = boardManagerDto.xSize;
        ySize = boardManagerDto.ySize;
        shakeTile = boardManagerDto.shakeTile;
        startBoard = boardManagerDto.startBoard;       
        xOffset = boardManagerDto.spriteTile.bounds.size.x;
        yOffset = boardManagerDto.spriteTile.bounds.size.y;
    }

    public void Create(PoolDeColetaveis poolDeColetaveis)
    {
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

    public void devolver(Coletavel[] coletaveis)
    {
        for(int contador = 0; contador < coletaveis.Length; contador++)
        {
            float angulo = Random.Range(-45, 45);
            Coletavel coletavel = coletaveis[contador];
            float x = Mathf.Cos(angulo * Mathf.PI / 180) * 20;
            float y = Mathf.Sin(angulo * Mathf.PI / 180) * 20;
            Vector3 forca = new Vector3(x, y, 0);
            coletavel.colocarNaPosicao(new Vector3(-1.61f, 4.1f, 0f));
            coletavel.addForce(forca);
            coletavel.ligar();
        }
    }
}
