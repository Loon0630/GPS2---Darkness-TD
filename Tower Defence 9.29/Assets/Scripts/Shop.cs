using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    public TurretBlueprint standardTurret;

    

    private void Start()
    {
        buildManager = BuildManager.instance;

        
    }

    public void SelectArrowTurret()
    {
        Debug.Log("Purchase Arrow Turret");

        // build tower (after click build)
            buildManager.SelectTurretBuild(standardTurret);
        
    }
       
        
    public void PurchaseRocketTurret()
    {

    }
}
