using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turrent;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    public bool build;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
            if (buildManager.GetTurrentToBuild() == null)
                return;

            if (turrent != null)
            {
                Debug.Log("Can't build there!");
                return;
            }
            GameObject turrentToBuild = BuildManager.instance.GetTurrentToBuild();
            turrent = (GameObject)Instantiate(turrentToBuild, transform.position + positionOffset, transform.rotation);
         
    }

    void OnMouseEnter()
    {
       if (buildManager.GetTurrentToBuild() == null)
           return;

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
