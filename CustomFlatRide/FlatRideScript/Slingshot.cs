
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slingshot : FlatRide
{

    public bool getOut;
    public SpringJoint UpperLeft;
    public SpringJoint UpperRight;
    public SpringJoint Bottom;
    public float speedDown = .15f;
    public float strenghtDown = 20;
    public float springVar = 1.5f;
   
    
    public override void onStartRide()
    {
        getOut = false;
        base.onStartRide();
        foreach (MeshCollider coll in GetComponentsInChildren<MeshCollider>())
        {
            coll.convex = true;
        }
        StartCoroutine(Ride());
    }
    IEnumerator Ride()
    {
       
        Bottom.connectedBody.isKinematic = false;
        Bottom.spring = 0;
        Bottom.damper = 0;
        UpperRight.spring = springVar;
        UpperLeft.spring = springVar;
        yield return new WaitForSeconds(10);
        while (Vector3.Distance(Bottom.anchor + Bottom.transform.position, Bottom.connectedBody.transform.position + Bottom.connectedAnchor) > .1f)
        {
            Bottom.spring = Mathf.Lerp(Bottom.spring, strenghtDown, speedDown / 2 * Time.deltaTime);
            Bottom.damper = Mathf.Lerp(Bottom.damper, strenghtDown * 1.4f , speedDown / 2 * Time.deltaTime); ;
            UpperRight.spring = Mathf.Lerp(UpperRight.spring, 0, speedDown * Time.deltaTime); ;
            UpperLeft.spring = Mathf.Lerp(UpperLeft.spring, 0, speedDown * Time.deltaTime); ;
            yield return null;
        }
        
        UpperRight.spring = 0;
        UpperLeft.spring = 0;
        yield return new WaitForSeconds(1);
        Bottom.connectedBody.isKinematic = true;
        getOut = true;
    }
    public override void tick(StationController stationController)
    {
    }

    public override bool shouldLetGuestsOut()
    {
        return getOut;
    }
}
