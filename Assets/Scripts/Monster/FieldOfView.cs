using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    #region Variables

    public float viewRadius = 5f;
    public float viewAngle = 120f;
    public LayerMask targetMask;
    public LayerMask obstacleMask;

    private List<Transform> visibleTargets = new List<Transform>();
    public List<Transform> VisibleTargets => visibleTargets;

    private Transform nearestTarget;
    public Transform NearestTarget => nearestTarget;
    private float distanceToTarget;
    public float delay = 0.1f;
    #endregion Variables
    
    #region Properties

    void findTarget()
    {
        visibleTargets.Clear();
        nearestTarget = null;

        Collider[] targets = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        foreach (Collider target in targets)
        {
            Transform t = target.transform;

            Vector3 dirToTarget = (target.transform.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < (viewAngle / 2))
            {
                float distToTarget = Vector3.Distance(transform.position, target.transform.position);
                if (!Physics.Raycast(transform.position, target.transform.position, distToTarget, obstacleMask))    //감지된 적이 없으면,
                {
                    visibleTargets.Add(target.transform);
                    if (nearestTarget == null || distanceToTarget > distToTarget)
                    {
                        nearestTarget = target.transform;
                        distanceToTarget = distToTarget;
                    }
                }
            }
        }
    }

    IEnumerator delayFindTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            findTarget();
        }
    }
    #endregion Properties
    
    #region Unity Methods

    void Start()
    {
        StartCoroutine(delayFindTarget());
    }
    #endregion Unity Methods


}
