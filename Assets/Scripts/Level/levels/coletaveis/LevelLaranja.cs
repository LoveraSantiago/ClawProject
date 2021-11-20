using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLaranja : LevelColetavel
{
    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {15, 15, 12, 12, 12, 15, 15},
            {11, 11, 11, 11, 11, 11, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }

    public static new Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLaranja();
    }

    public class FornecedorLaranja : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelLaranja();
        }
    }
}
