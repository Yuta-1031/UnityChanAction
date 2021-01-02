using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private TriggerEvent onTriggerEnterStay = new TriggerEvent();

    /// <summary>
    /// IsTriggerがONで他のColliderと重なっている時は、このメソッドはコールされる
    /// </summary>
    /// <param name="other"></param>

    private void OnTriggerStay(Collider other)
    {
        onTriggerEnterStay.Invoke(other);
    }

   [Serializable]
    public class TriggerEvent : UnityEvent<Collider>
    {
    }
}
