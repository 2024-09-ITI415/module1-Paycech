using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    static private Slingshot S;
    // fields set in the Unity Inspector pane
    [Header("Set in Inspector")] 
    public GameObject prefabProjectile;
    public float velocityMult = 8f;

    // fields set dynamically
    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos; 
    public GameObject projectile; 
    public bool aimingMode; 
    private Rigidbody projectileRigidbody;

    static public Vector3 Launch_POS {
        get {
            if (S == null) return Vector3.zero;
            return S.launchPos;
        }
    }


    void Awake() {
        S = this;
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive( false );
        launchPos = launchPointTrans.position;
    }

    void OnMouseEnter() {
        print("Slingshot:OnMouseEnter()");
        launchPoint.SetActive( true );
    }

    void OnMouseExit() {
        print("Slingshot:OnMouseExit()");
        launchPoint.SetActive( false ); 
    }
    void OnMouseDown() { // d
        // The player has pressed the mouse button while over Slingshot
        aimingMode = true;
        // Instantiate a Projectile
        projectile = Instantiate( prefabProjectile ) as GameObject;
        // Start it at the launchPoint
        projectile.transform.position = launchPos;
        // Set it to isKinematic for now
        projectileRigidbody = projectile.GetComponent<Rigidbody>(); // a
        projectileRigidbody.isKinematic = true; 
    }

    void Update() {
        if (!aimingMode) return;
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D ); 

        Vector3 mouseDelta = mousePos3D-launchPos;
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude){
            mouseDelta.Normalize();
            mouseDelta *=maxMagnitude;
        }

        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

        if ( Input.GetMouseButtonUp(0) ){
        // The mouse has been released)
            aimingMode = false;
            projectileRigidbody.isKinematic = false;
            projectileRigidbody.velocity = -mouseDelta * velocityMult;
            FollowCam.POI = projectile;
            projectile = null;
            MissionDemolition.ShotFired(); // a
            ProjectileLine.S.poi = projectile;
        }
    }
}
