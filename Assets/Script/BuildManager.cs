using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    public GameObject buildEffect;

    private TurretBlueprint turretToBuilt;





    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one turren in the scene");
        }
        else
        {
            instance = this;
        }
    }



    public bool CanBuild { get { return turretToBuilt != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuilt.cost; } }



    public void SelectTurretToBuilt(TurretBlueprint turret)
    {
        turretToBuilt = turret;
    }




    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < turretToBuilt.cost)
        {
            print("Not enough money to built that!");
            return;
        }

        PlayerStats.Money -= turretToBuilt.cost;

        GameObject turret = Instantiate(turretToBuilt.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

    }





    /*
     * use this when no cost system
     * 
     * 
    public GameObject GetTurretToBuild()
    {
        return turretToBuilt;
    }



    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuilt = turret;
    }
    */



}
