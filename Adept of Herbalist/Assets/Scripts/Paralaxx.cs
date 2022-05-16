using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaxx : MonoBehaviour
{

    public Camera cam;

    public Transform subject;

    Vector2 startPosiotion;

    float StartZ;

    Vector2 travel => (Vector2)cam.transform.position - startPosiotion;



    float distanceFromSubject => transform.position.z - subject.position.z;

    float clippingPlane => (cam.transform.position.z + distanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane);

    float parallaxFactor => Mathf.Abs(distanceFromSubject) / clippingPlane;
    








    public void Start()
    {
        startPosiotion = transform.position;
        StartZ = transform.position.z;
    }

    // Update is called once per frame
    public void Update()
    {
        Vector2 newPos = startPosiotion + travel * parallaxFactor;
        transform.position = new Vector3(newPos.x, newPos.y, StartZ);
    }
}
