using UnityEngine;

//INTERFACE PARA ESTADOS DA GARRA SE COMUNICAR MUDANCA DE ESTADO
public interface ComunicadorComGerMovimentacao
{
    void trocarParaAcaoNormal();
    void trocarParaAcaoSubindo();
    void trocarParaAcaoAgarrada();
    void trocarParaAcaoDescendo();    
}
