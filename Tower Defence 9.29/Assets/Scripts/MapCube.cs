﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCube : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turrent;

    private Renderer rend;
    private Color startColor;



    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turrent !=null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        GameObject turrentToBuild = BuildManager.instance.GetTurrentToBuild();
        turrent=(GameObject)Instantiate(turrentToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}