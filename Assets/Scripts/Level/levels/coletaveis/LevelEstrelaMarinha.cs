using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEstrelaMarinha : LevelColetavel
{
    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]{
            {16, 15, 15, 15, 15, 15, 15},
            {14, 14, 14, 14, 14, 14, 0},
            {13, 13, 13, 13, 13, 13, 16},
            {12, 12, 12, 12, 12, 12, 0},
            {16, 11, 11, 11, 11, 11, 11},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }

    public static new Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorEstrelaMarinha();
    }

    public class FornecedorEstrelaMarinha : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelEstrelaMarinha();
        }
    }
}
