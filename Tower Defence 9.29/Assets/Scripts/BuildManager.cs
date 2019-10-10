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

    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn (MapCube mapCube)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("No money");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, mapCube.GetBuildPosition(), Quaternion.identity);
        mapCube.turret = turret;
    }
    private void Start()
    {

    }
    public void SelectTurretBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
   
}
