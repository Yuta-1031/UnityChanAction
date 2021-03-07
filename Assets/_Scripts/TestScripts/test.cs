using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    [SerializeField, Tooltip("射出するオブジェクトをここに割り当てる")] private GameObject ThrowingObject;

    [SerializeField, Tooltip("標的のオブジェクトをここに割り当てる")] private GameObject TargetObject;

    [SerializeField, Range(0F, 90F), Tooltip("射出する角度")] private float ThrowingAngle;

    private void Start()
    {
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }

        ThrowingBall();
    }

    private void ThrowingBall()
    {
        if (ThrowingObject != null && TargetObject != null)
        {
            Vector3 targetPosition = TargetObject.transform.position;
            float angle = ThrowingAngle;
            Vector3 velocity = CalculateVelocity(this.transform.position, targetPosition, angle);

            Rigidbody rid = ThrowingObject.GetComponent<Rigidbody>();
            rid.AddForce(velocity * rid.mass, ForceMode.Impulse);
        }
    }
    private Vector3 CalculateVelocity(Vector3 pointA, Vector3 pointB, float angle)
    {
        // 射出角をラジアンに変換
        float rad = angle * Mathf.PI / 180;

        // 水平方向の距離x
        float x = Vector2.Distance(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z));

        // 垂直方向の距離y
        float y = pointA.y - pointB.y;

        // 斜方投射の公式を初速度について解く
        float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        if (float.IsNaN(speed))
        {
            // 条件を満たす初速を算出できなければVector3.zeroを返す
            return Vector3.zero;
        }
        else
        {
            return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * speed);
        }
    }
}
