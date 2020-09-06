using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasFlag : MonoBehaviour
{
    public GameObject Resurcse;
    public GameObject Target;

    public bool hasFlagFalg;
    public DronesController Agent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Resurcse)
        {
            if (!hasFlagFalg)
            {
                Agent.AddReward(0.5f);
                hasFlagFalg = true;
                Debug.Log("WurdeBelohnt mit 0.5f");
            }
        }
        if (collision.gameObject == Target)
        {
            if (hasFlagFalg)
            {
                Agent.AddReward(1f);
                hasFlagFalg = false;
                Debug.Log("WurdeBelohnt mit 1f");
            }
        }
    }
}
