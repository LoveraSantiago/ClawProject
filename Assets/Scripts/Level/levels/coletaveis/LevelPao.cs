using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPao : LevelColetavel
{

    public static new Fornecedor<AbstractLevel> getFornecedor()
    {
        return new FornecedorPao();
    }

    public class FornecedorPao : Fornecedor<AbstractLevel>
    {
        public AbstractLevel fornecer()
        {
            return new LevelPao();
        }
    }
}
