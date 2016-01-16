using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpringJoint))]
[RequireComponent(typeof(LineRenderer))]
public class SetLineSpring : MonoBehaviour {

    LineRenderer Line;
    SpringJoint Spring;
    public Transform Point;

	// Use this for initialization
	void Awake () {
        Line = GetComponent<LineRenderer>();
        Line.material.SetTexture(("_MainTex"), null);
        Spring = GetComponent<SpringJoint>();
	}
	
	// Update is called once per frame
	void Update () {
        Line.SetPosition(0, transform.position);
        Line.SetPosition(1, Point.position);
	}
}
