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
    private void FixedUpdate()
    {
        if (pointsIndex <= Points.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == Points[pointsIndex].transform.position)
            {
                pointsIndex++;

                if (pointsIndex <= Points.Length - 1)
                {
                    StartCoroutine(RotateTowardsPoint(Points[pointsIndex].transform.position));
                }
            }
        }
    }

    private IEnumerator RotateTowardsPoint(Vector3 targetPoint)
    {
        Quaternion startRotation = transform.rotation;
        Vector3 direction = (targetPoint - transform.position).normalized;

        while (Quaternion.Angle(transform.rotation, Quaternion.LookRotation(direction)) > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }

        transform.rotation = Quaternion.LookRotation(direction);
    }


}