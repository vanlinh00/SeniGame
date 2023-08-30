using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class AIDestinationSetterCustom : AIDestinationSetter
{
    // Start is called before the first frame update
    //protected override void OnEnable()
    //{
    //    base.OnEnable();

    //}
    //    public void Move()
    //    {
    //        StartCoroutine(IESetTarget());
    //    }
    //    IEnumerator IESetTarget()
    //    {  
    //        //target = PlayerMovement.instance.getTarget();
    //        yield return null;
    //        ai.maxSpeed = Random.Range(3, 5);
    //        ai.destination= target.position;
    //    }

    public void SetTarGet(Transform targetTransform)
    {
        target = targetTransform;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        target = transform;
    }
}
