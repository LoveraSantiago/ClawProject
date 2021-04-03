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
using System.Collections;
using System.Collections.Generic;

public class BoardManager
{
    //public static BoardManager instance;
    //public List<Sprite> characters = new List<Sprite>();
    //public GameObject tile;
    //public int xSize, ySize;
    //public float shakeTile;

    private ColetavelManager coletavelManager;
    private BoardManagerDto boardManagerDto;
    private Board board;


    //private GameObject[,] tiles;

    //public bool IsShifting { get; set; }

    public BoardManager(BoardManagerDto boardManagerDto)
    {
        this.boardManagerDto = boardManagerDto;
        this.coletavelManager = new ColetavelManager();
        this.board = new Board(boardManagerDto);
        Start();
    }

    void Start()
    {
        //instance = GetComponent<BoardManager>();
        Vector2 offset = boardManagerDto.sprTile.bounds.size;
        CreateBoard(offset.x, offset.y);
    }

    private void CreateBoard(float xOffset, float yOffset)
    {
        this.board.Create(xOffset, yOffset);
        //tiles = new GameObject[boardManagerDto.xSize, boardManagerDto.ySize];

        //float startX = boardManagerDto.transform.position.x;
        //float startY = boardManagerDto.transform.position.y;

        //Sprite[] previousLeft = new Sprite[boardManagerDto.ySize];
        //Sprite previousBelow = null;


        //for (int x = 0; x < boardManagerDto.xSize; x++)
        //{
        //    for (int y = 0; y < boardManagerDto.ySize; y++)
        //    {
        //        boardManagerDto.shakeTile *= -1;
        //        GameObject newTile = GameObject.Instantiate(boardManagerDto.tile, new Vector3(startX + boardManagerDto.shakeTile + (xOffset * x), startY + (yOffset * y), 0), boardManagerDto.tile.transform.rotation);
        //        tiles[x, y] = newTile;
        //        newTile.transform.parent = boardManagerDto.transform;

        //        List<Sprite> possibleCharacters = new List<Sprite>();
        //        possibleCharacters.AddRange(boardManagerDto.characters);

        //        possibleCharacters.Remove(previousLeft[y]);
        //        possibleCharacters.Remove(previousBelow);


        //        //Sprite newSprite = characters[Random.Range(0, characters.Count)];
        //        Sprite newSprite = possibleCharacters[Random.Range(0, possibleCharacters.Count)];

        //        SpriteRenderer spriteRenderer = newTile.GetComponent<SpriteRenderer>();
        //        spriteRenderer.sprite = newSprite;
        //        spriteRenderer.sortingOrder = 31;
        //        newTile.name = newSprite.name;
        //    }
        //}
    }

    private void devolverBoard(string[] nomes)
    {
        //reposicionar
    }
}
