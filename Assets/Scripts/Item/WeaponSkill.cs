using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponSkill : MonoBehaviour
{
    #region Variables

    [SerializeField] protected float coolTime;
    [SerializeField] protected float coolTimeCount;
    [SerializeField] protected LayerMask targetMask;
    [SerializeField] protected int animationIndex;
    #endregion Variables

}
