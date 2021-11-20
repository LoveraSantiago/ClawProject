using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaca : LevelColetavel
{
    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {13, 12, 15, 11, 14, 14, 15},
            {0, 16, 11, 11, 13, 0, 0},
            {0, 0, 10, 10, 12, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }

    public static new Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorMaca();
    }

    public class FornecedorMaca : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelMaca();
        }
    }

}
