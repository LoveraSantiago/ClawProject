using UnityEngine;

public class GaiolaContexto : GOContexto
{
    public Nomeador nomeador { get; private set; }

    public GaiolaContexto(GameObject goMainGaiola) 
        : base(goMainGaiola)
    {
        nomeador = new Nomeador();
    }
}
