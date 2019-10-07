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

    private TurrentBlueprint turrentToBuild;

    public bool CanBuild { get { return turrentToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turrentToBuild.cost; } }

    public void BuildTurrentOn (MapCube mapCube)
    {
        if(PlayerStats.Money < turrentToBuild.cost)
        {
            Debug.Log("No money");
            return;
        }

        PlayerStats.Money -= turrentToBuild.cost;

        GameObject turrent = (GameObject)Instantiate(turrentToBuild.prefab, mapCube.GetBuildPosition(), Quaternion.identity);
        mapCube.turrent = turrent;
    }
    private void Start()
    {

    }
    public void SelectTurrentBuild (TurrentBlueprint turrent)
    {
        turrentToBuild = turrent;
    }
   
}
