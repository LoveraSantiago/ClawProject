using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEstrelaMarinha : LevelColetavel
{
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
