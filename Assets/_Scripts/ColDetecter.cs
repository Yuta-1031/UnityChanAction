using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]

public class ColDetecter : MonoBehaviour
{
    [SerializeField] private CollisionEvent onCollisionEnter = new CollisionEvent();

    /// <summary>
    /// Is TriggerがONで他のColliderと重なっているときは、このメソッドが常にコールされる
    /// </summary>
    /// <param name="other"></param>
     private void OnCollisionEnter(Collision other)
    {
        onCollisionEnter.Invoke(other);
    }

    // UnityEventを継承したクラスに[Serializable]属性を付与することで、Inspectorウインドウ上に表示できるようになる。
    [Serializable]
    public class CollisionEvent : UnityEvent<Collision>
    {
    }
}
