using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    private bool buildAdy=false;

    

    private void Start()
    {
        buildManager = BuildManager.instance;

        
    }

    public void PurchaseArrowTurrent()
    {
        Debug.Log("Purchase Arrow Turrent");

        // build tower (after click build)
       
        if(buildAdy==false)
        {
            buildManager.SetTurrentBuild(buildManager.standardTurrentPrefab);
        }
        buildAdy = true;
    }
       
        
    public void PurchaseRocketTurrent()
    {

    }
}
