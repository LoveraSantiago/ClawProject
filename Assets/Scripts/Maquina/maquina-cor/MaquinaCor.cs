using System.Collections.Generic;

public interface MaquinaCor 
{
    string getNome();
    Dictionary<string, string> getCores();

    bool isLevelAlbedo0();

    bool isLevelAlbedo0Timer2Pontos();
}
