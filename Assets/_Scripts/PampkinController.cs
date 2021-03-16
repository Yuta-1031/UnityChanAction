using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PampkinController : MonoBehaviour
{

    [SerializeField, Range(0F, 90F)] private float ThrowingAngle;

    private GameObject TargetObject;
    public GameObject explosion;
    GameObject nullTarget;
    Rigidbody _rig;
    TrailRenderer trajectory;
    Hal_SearchEnemy hal_target;
    private GameObject searchObj;


    private void Start()
    {
        searchObj = GameObject.FindGameObjectWithTag("Parent");
        nullTarget = GameObject.FindGameObjectWithTag("NullTarget");

        _rig = GetComponent<Rigidbody>();
        hal_target = searchObj.GetComponent<Hal_SearchEnemy>();
        trajectory = GetComponentInChildren<TrailRenderer>();
        trajectory.emitting = false;
       _rig.useGravity = false;

        if (hal_target.GetNowTarget())
        {
            TargetObject = hal_target.GetNowTarget();
            Invoke("ThrowingBall", 0.4f);
        }
        else
        {
            TargetObject = nullTarget;
            Invoke("ThrowingBall", 0.4f);
        }
    }

    void OnGravity()
    {
        //_rig.AddForce(transform.forward * -8.0f, ForceMode.Impulse);
    }

    private void Update()
    {
    }

    private void ThrowingBall()
    {
        _rig.useGravity = true;
        trajectory.emitting = true;

        if (TargetObject != null)
        {
            Vector3 targetPosition = TargetObject.transform.position;
            float angle = ThrowingAngle;
            Vector3 velocity = CalculateVelocity(this.transform.position, targetPosition, angle);

            //Rigidbody rid = this.gameObject.GetComponent<Rigidbody>();
            _rig.AddForce(velocity * _rig.mass, ForceMode.Impulse);
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

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z), Quaternion.identity);
        Destroy(this.gameObject, 0.1f);
    }
}
