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
    private GameObject tile;
    private SpriteRenderer spriteTile;
    private int xSize, ySize;
    private float shakeTile;
    private Transform startBoard;
    private List<Sprite> characters;
    private GameObject[,] tiles;
    private float xOffset;
    private float yOffset;

    public Board(BoardDto boardManagerDto)
    {        
        characters = boardManagerDto.characters;
        tile = boardManagerDto.tile;
        spriteTile = boardManagerDto.spriteTile;
        xSize = boardManagerDto.xSize;
        ySize = boardManagerDto.ySize;
        shakeTile = boardManagerDto.shakeTile;
        startBoard = boardManagerDto.startBoard;       
        xOffset = boardManagerDto.spriteTile.bounds.size.x;
        yOffset = boardManagerDto.spriteTile.bounds.size.y;        
    }

    public void Create()
    {
        tiles = new GameObject[xSize, ySize];
       
        float startX = startBoard.position.x;
        float startY = startBoard.position.y;

        Sprite[] previousLeft = new Sprite[ySize];
        Sprite previousBelow = null;

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                shakeTile *= -1;
                GameObject newTile = GameObject.Instantiate(tile, new Vector3(startX + shakeTile + (xOffset * x), startY + (yOffset * y), 0), tile.transform.rotation);
                tiles[x, y] = newTile;
                newTile.transform.parent = startBoard;

                List<Sprite> possibleCharacters = new List<Sprite>();
                possibleCharacters.AddRange(characters);

                possibleCharacters.Remove(previousLeft[y]);
                possibleCharacters.Remove(previousBelow);

                //Sprite newSprite = characters[Random.Range(0, characters.Count)]; //permite repetição do item na mesma linha
                Sprite newSprite = possibleCharacters[Random.Range(0, possibleCharacters.Count)];

                SpriteRenderer spriteRenderer = newTile.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = newSprite;
                spriteRenderer.sortingOrder = 31;
                newTile.name = newSprite.name;
            }
        }
    }

    internal void devolver(string[] coletaveis)
    {
        Debug.Log("Board - devolver");
    }
}
