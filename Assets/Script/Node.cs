using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using VRTK;


public class Node : MonoBehaviour {

    public Vector3 positionOffset;

    public Color notEnoughMoneyColor;
    public Color hoverColor;

    [Header("Optional")]
    public GameObject turret = null;

    private Renderer rend;
    private Color startColor;

    private BuildManager buildmanager;



    public void Start()
    {


        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildmanager = BuildManager.instance;

    }


   
   




    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }


    
    public void OnMouseDown()
    {
        if(turret != null)
        {
            print("Can't build there");
        }
        else
        {

            if( buildmanager.CanBuild && !EventSystem.current.IsPointerOverGameObject())
            {
                buildmanager.BuildTurretOn(this);

                //GameObject turretToBuilt = buildmanager.GetTurretToBuild();
                //turret = Instantiate(turretToBuilt, transform.position + positionOffset, transform.rotation);

            }
            
        }

    }
    


    public void OnMouseEnter()
    {

        

        if( !buildmanager.CanBuild || EventSystem.current.IsPointerOverGameObject())
        {
            return; 
        }



        if (buildmanager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }



    }

    public void OnMouseExit()
    {
        if( !buildmanager.CanBuild || EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        rend.material.color = startColor;

    }

}
