using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public BuildManager buildManager;

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }



    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuilt(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuilt(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuilt(laserBeamer);
    }







    /*
     * use this where no cost system
     * 
    public void PurchaseStandardTurret()
    {
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);

        print("Standard Turret selected");
    }



    public void PurchaseMissileLauncher()
    {
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab);

        print("Missile Launcher selected");
    }
    */



}
