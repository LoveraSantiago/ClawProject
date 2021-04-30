using UnityEngine;

//INTERFACE PARA ESTADOS DA GARRA SE COMUNICAR MUDANCA DE ESTADO
public interface ComunicadorComGerMovNormal
{
    void trocarParaAcaoNormal();
    void trocarParaAcaoSubindo();
    void trocarParaAcaoAgarrada();
    void trocarParaAcaoDescendo();    
}
