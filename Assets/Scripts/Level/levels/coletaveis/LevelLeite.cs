using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLeite : LevelColetavel
{
    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {10, 10, 10, 11, 12, 13, 14},
            {13, 14, 15, 16, 16, 15, 0},
            {12, 11, 12, 13, 14, 15, 16},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }

    public static new Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorLeite();
    }

    public class FornecedorLeite : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelLeite();
        }
    }

}
