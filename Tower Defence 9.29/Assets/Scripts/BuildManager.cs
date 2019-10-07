using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager");
        }
        instance = this;

    }

    public GameObject standardTurrentPrefab;
    public GameObject anotherTurrentPrefab;

    private GameObject turrentToBuild;

    private void Start()
    {

    }

    public GameObject GetTurrentToBuild ()
    {
        return turrentToBuild;
    }

    public void SetTurrentBuild(GameObject turrent)
    {
        turrentToBuild = turrent;       
    }
}
