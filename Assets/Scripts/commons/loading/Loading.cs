using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading 
{
    private static readonly string LABEL_LOADING = "LOADING... {0}%";
    private static readonly int FECHAR_MODAL = Animator.StringToHash("fechar-loading");

    private LoadingDto loadingDto;

    public Loading(LoadingDto loadingDto)
    {
        this.loadingDto = loadingDto;
    }

    public void abrirModal(SomLoading somLoading)
    {
        loadingDto.GoCanvas.gameObject.SetActive(true);
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineIrParaCenaComDelay(somLoading));
    }

    private IEnumerator coroutineIrParaCenaComDelay(SomLoading somLoading)
    {
        somLoading.playGarraGirando();
        loadingDto.LblLoadingTexto.text = string.Format(LABEL_LOADING, 0);
        somLoading.playSomAbrirModal();
        yield return new WaitForSeconds(loadingDto.DelayAbrirModal);

        AsyncOperation operation = SceneManager.LoadSceneAsync("MapScene");
        operation.allowSceneActivation = false;
        while (operation.progress < 0.89)
        {
            float progresso = operation.progress * 100;
            loadingDto.LblLoadingTexto.text = string.Format(LABEL_LOADING, progresso);
            Debug.Log(operation.progress);
            yield return null;
        }
        loadingDto.LblLoadingTexto.text = string.Format(LABEL_LOADING, 100);
        loadingDto.Animator.Play(FECHAR_MODAL);
        somLoading.playSomAbrirModal();
        yield return new WaitForSeconds(loadingDto.DelayFecharModal);
        operation.allowSceneActivation = true;
        yield return null;
    }
}
