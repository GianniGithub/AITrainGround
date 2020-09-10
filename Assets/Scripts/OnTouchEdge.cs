using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchEdge : MonoBehaviour
{
    public DronesController Agent;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("edge"))
        {
            Agent.AddReward(-0.1f);
        }

    }
}
