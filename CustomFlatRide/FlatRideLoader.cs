using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlatRidesLoader : CustomFlatRideLoader
{

    public void LoadSlingshot()
    {
        Debug.Log("#### Started loading Slingshot ####");
        GameObject asset = base.LoadAsset("Slingshot");
        List<Transform> Holders = new List<Transform>();
        Utility.recursiveFindTransformsStartingWith("Holder", asset.transform, Holders);
        Slingshot SS = asset.AddComponent<Slingshot>();
        SS.UpperLeft = asset.transform.FindChild("LeftPole/HolderLeft").GetComponent<SpringJoint>();
        SS.UpperRight = asset.transform.FindChild("RightPole/HolderRight").GetComponent<SpringJoint>();
        SetLineSpring SLS = SS.UpperLeft.gameObject.AddComponent<SetLineSpring>();
        SLS.Point = asset.transform.FindChild("Shooter/Left");
        SLS = SS.UpperRight.gameObject.AddComponent<SetLineSpring>();
        SLS.Point = asset.transform.FindChild("Shooter/Right");
        if (asset.gameObject.GetComponent<SpringJoint>())
        {
            SS.Bottom = asset.gameObject.GetComponent<SpringJoint>();
        }
        base.BasicFlatRideSettings(SS, "Slingshot", 800, .4f, .9f, .6f, 7, 4);
        base.AddBoundingBox(asset, 7, 4);
        base.AddRestraints(asset, new Vector3(0, 0, 120));
        base.AddColors(asset, new Color[2] { Color.red, Color.yellow });
        List<int> connections = new List<int>()
        {
            //Outer
            0,1,
            1,2,
            2,3,
            3,4,
            4,5,
            5,0,
            2,6,
            3,6,
            //Outsied
            8,13,
            13,18,
            18,9,
            9,11,
            11,12,
            12,10,
            10,17,
            17,16,
            16,7,
            7,15,
            15,14,
            14,18,
            //Custom
            7,3,
            16,3,
            16,2,
            16,15,
            17,2,
            17,3,
            17,12,
            18,0,
            18,5,
            18,11,
            13,0,
            13,5,
            13,14



        };
        base.SetWaypoints(asset, connections);
        foreach (MeshCollider coll in asset.GetComponentsInChildren<MeshCollider>())
        {
            coll.convex = true;
        }

        asset.transform.position = new Vector3(0, 999, 0);
        Debug.Log("#### Done loading Slingshot ####");
    }
    public void LoadFlatRides()
    {
        LoadSlingshot();
    }
    


}


