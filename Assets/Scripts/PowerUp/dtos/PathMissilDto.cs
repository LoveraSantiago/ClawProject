using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class PathMissilDto 
{
    [SerializeField] private GameObject goMainPath;
    [SerializeField] private Transform[] pathPointsMissil;

    public GameObject GoMainPath { get { return goMainPath; } }
    public Transform[] PathPointsMissil { get { return pathPointsMissil; } }
}
