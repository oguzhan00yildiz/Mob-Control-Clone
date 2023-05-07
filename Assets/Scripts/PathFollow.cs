using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    [SerializeField] private Transform[] Points;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    private Quaternion lookRotation;
    private Vector3 direction;
    private int pointsIndex;

    void Start()
    {

    }

    void Update()
    {
        if(pointsIndex <= Points.Length -1)
        {
            transform.position = Vector3.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);

            if(transform.position == Points[pointsIndex].transform.position)
            {
                direction = Points[Points.Length-1].transform.position - transform.position;

                Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, rotationSpeed * Time.deltaTime, 0.0f);

                transform.rotation = Quaternion.LookRotation(newDirection);

                pointsIndex += 1;
            }
        }
    }
}
