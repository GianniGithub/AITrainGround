using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class DronesController : Agent
{

    public simpelDroneControll controll;

    Agent m_Agent;
    private Rigidbody rBody;
    private Vector3 startingPosition;


    public override void Initialize()
    {
        rBody = transform.parent.GetComponent<Rigidbody>();
        startingPosition = transform.parent.position;
    }
    public override void OnActionReceived(float[] vectorAction)
    {
        var rotateDir = vectorAction[0];
        var dirToGo = vectorAction[1];
        //actionsOut[1] = Input.GetKey(KeyCode.Space) ? 1.0f : 0.0f;
        controll.move(rotateDir, dirToGo);
    }
    public override void OnEpisodeBegin()
    {

    }
    // Für Manuelles Training
    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = Input.GetAxis("Horizontal");
        //actionsOut[1] = Input.GetKey(KeyCode.Space) ? 1.0f : 0.0f;
        actionsOut[2] = Input.GetAxis("Vertical");
        actionsOut[0] = 0;
    }




}
