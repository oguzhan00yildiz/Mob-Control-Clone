using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    [SerializeField] private Transform[] Points;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject CannonBottom;

    private Quaternion lookRotation;
    private Vector3 direction;
    private int pointsIndex;
    [SerializeField] private GameObject Level1;
    private bool isLevelDestroyed=false;

    void Start()
    {

    }
    private void FixedUpdate()
    {
        if(CastleManager.instance.castleHealth < -10)
        {
            if (Level1)
            {
               StartCoroutine(DestroyLevel());   
            }
          
            if (pointsIndex <= Points.Length - 1&&isLevelDestroyed)
            {
                CannonBottom.transform.eulerAngles=new Vector3(0,90,0);
                transform.position = Vector3.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);

                if (transform.position == Points[pointsIndex].transform.position)
                {
                    pointsIndex++;
                    

                    if (pointsIndex <= Points.Length - 1)
                    {
                        StartCoroutine(RotateTowardsPoint(Points[pointsIndex].transform.position));
                        
                    }

                    CannonBottom.transform.localEulerAngles=new Vector3(0,0,0);
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

    private IEnumerator DestroyLevel()
    {
        Vector3 targetPosition = new Vector3(Level1.transform.position.x, -30, Level1.transform.position.z);
        Level1.transform.position = Vector3.Slerp(Level1.transform.position, targetPosition, Time.deltaTime * 1f);
        yield return new WaitForSeconds(1.5f);
        isLevelDestroyed=true;
        Destroy(Level1);
    }


}
