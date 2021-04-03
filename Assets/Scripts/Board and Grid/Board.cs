using UnityEngine;
using System.Collections.Generic;

public class Board
{
    private BoardManagerDto boardManagerDto;

    private GameObject[,] tiles;

    public Board(BoardManagerDto boardManagerDto)
    {
        this.boardManagerDto = boardManagerDto;
        //Vector2 offset = boardManagerDto.tile.GetComponent<SpriteRenderer>().bounds.size;
    }

    public void Create(float xOffset, float yOffset)
    {
        tiles = new GameObject[boardManagerDto.xSize, boardManagerDto.ySize];

        float startX = boardManagerDto.transform.position.x;
        float startY = boardManagerDto.transform.position.y;

        Sprite[] previousLeft = new Sprite[boardManagerDto.ySize];
        Sprite previousBelow = null;


        for (int x = 0; x < boardManagerDto.xSize; x++)
        {
            for (int y = 0; y < boardManagerDto.ySize; y++)
            {
                boardManagerDto.shakeTile *= -1;
                GameObject newTile = GameObject.Instantiate(boardManagerDto.tile, new Vector3(startX + boardManagerDto.shakeTile + (xOffset * x), startY + (yOffset * y), 0), boardManagerDto.tile.transform.rotation);
                tiles[x, y] = newTile;
                newTile.transform.parent = boardManagerDto.transform;

                List<Sprite> possibleCharacters = new List<Sprite>();
                possibleCharacters.AddRange(boardManagerDto.characters);

                possibleCharacters.Remove(previousLeft[y]);
                possibleCharacters.Remove(previousBelow);


                //Sprite newSprite = characters[Random.Range(0, characters.Count)];
                Sprite newSprite = possibleCharacters[Random.Range(0, possibleCharacters.Count)];

                SpriteRenderer spriteRenderer = newTile.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = newSprite;
                spriteRenderer.sortingOrder = 31;
                newTile.name = newSprite.name;
            }
        }
    }

}
