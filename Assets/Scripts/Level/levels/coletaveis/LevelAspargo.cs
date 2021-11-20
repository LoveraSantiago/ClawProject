using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAspargo : LevelColetavel
{
    public override int[,] getArrayDeColetaveis()
    {
        return new int[,]
        {
            {16, 16, 16, 16, 16, 16, 14},
            {16, 16, 16, 16, 16, 14, 0},
            {16, 16, 16, 16, 16, 14, 16},
            {16, 16, 16, 16, 16, 16, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0}
        };
    }

    public static new Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorAspargo();
    }

    public class FornecedorAspargo : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelAspargo();
        }
    }
}
