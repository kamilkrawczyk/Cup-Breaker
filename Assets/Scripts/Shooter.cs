using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private Vector3 shootPos;

    public Camera _camera;
    public GameObject ballPrefab;

    public int shootForce = 10;
    // Start is called before the first frame update
    void Start()
    {
        shootPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        GameObject ball = Instantiate(ballPrefab, shootPos, ballPrefab.transform.rotation); //Instantiate the ball

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;

        Vector3 target = _camera.ScreenToWorldPoint(mousePos);

        Vector3 dir = target - transform.position; //Calculate direction

        ball.GetComponent<Rigidbody>().AddForce(dir * shootForce); //Apply force

    }
}
