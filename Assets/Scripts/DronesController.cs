using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class DronesController : Agent
{

    public simpelDroneControll controll;
    private Vector3 startingPosition;


    public hasFlag Distanzes;


    public override void Initialize()
    {
        //rBody = transform.parent.GetComponent<Rigidbody>();
        startingPosition = transform.parent.position;
    }
    public override void OnActionReceived(float[] vectorAction)
    {
        var rotateDir = vectorAction[0];
        var dirToGo = vectorAction[1];


        //actionsOut[1] = Input.GetKey(KeyCode.Space) ? 1.0f : 0.0f;
        controll.move(rotateDir, dirToGo);
        AddReward(-0.0001f);

    }
    public override void OnEpisodeBegin()
    {

    }
    public override void CollectObservations(VectorSensor sensor)
    {
        // Distanz
        sensor.AddObservation(Distanzes.currentDistanz);
        //sensor.AddObservation(Distanzes.HasFlagFalg);
    }
    // Für Manuelles Training
    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = Input.GetAxis("Horizontal");
        //actionsOut[1] = Input.GetKey(KeyCode.Space) ? 1.0f : 0.0f;
        actionsOut[1] = Input.GetAxis("Vertical");

    }




}
