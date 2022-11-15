using UnityEngine;

public class PrefabLoading : MonoBehaviour
{
    [SerializeField] private LoadingDto loadingDto;

    public Loading getLoading()
    {
        return new Loading(loadingDto);
    }
}
