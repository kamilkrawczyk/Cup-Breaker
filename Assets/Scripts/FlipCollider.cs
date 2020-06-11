using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCollider : MonoBehaviour
{
    private bool isFlipped;
    // Start is called before the first frame update
    void Start()
    {
        isFlipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleFallingUnderTable();
    }
    private void OnTriggerEnter(Collider other)//When cup collides with some surface or object other than other cup
    {
        if(other.gameObject.layer == 0 && !isFlipped)//default layer
        {
            isFlipped = true;           
            GameController.cupsFlipped++;
        }
    }
    public void HandleFallingUnderTable()//When cup falls to the floor but does not change the rotation
    {
        if (transform.position.y < 0.6f && !isFlipped)
        {
            GameController.cupsFlipped++;
            isFlipped = true;
        }
    }
}
