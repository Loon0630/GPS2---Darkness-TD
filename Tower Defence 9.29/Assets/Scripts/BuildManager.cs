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

    private void Start()
    {
        turrentToBuild = standardTurrentPrefab;
    }

    private GameObject turrentToBuild;

    public GameObject GetTurrentToBuild ()
    {
        return turrentToBuild;
    }
}
