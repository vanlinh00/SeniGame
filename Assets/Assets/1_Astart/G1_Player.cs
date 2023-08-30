using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1_Player : MonoBehaviour
{
    public AIDestinationSetterCustom aIDestinationSetterCustom;
    public Transform TargetTrans;
    [Button]
    public void Move()
    {
        aIDestinationSetterCustom.SetTarGet(TargetTrans);
    }
}
