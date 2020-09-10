using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasFlag : MonoBehaviour
{
    [SerializeField]
    bool hasFlagFalg;
    public float HasFlagFalg => hasFlagFalg ? 1 : 0;
    public DronesController Agent;


    public float currentDistanz;
    //public float LastDistanz;

    public Transform Resurce;
    public Transform Goal;
    float TimeStep = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Target = hasFlagFalg ? Goal.position : Resurce.position;
        
        currentDistanz = Vector2.Distance(transform.position, Target);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Resurce.gameObject)
        {
            SetFlag(true, !hasFlagFalg);
        }
        if (collision.gameObject == Goal.gameObject)
        {
            SetFlag(false, hasFlagFalg);
        }
    }

    private void SetFlag(bool to, bool Condition)
    {
        if (Condition)
        {
            TimeStep = Time.time;

            Agent.AddReward(1f);

            hasFlagFalg = to;
        }
        else
            Agent.AddReward(-0.001f);
    }
}
