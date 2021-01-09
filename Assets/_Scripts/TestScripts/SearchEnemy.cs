using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SearchEnemy : MonoBehaviour
{

    //　サーチした敵を入れる
    [SerializeField]
    private List<GameObject> enemyList;
    //　現在標的にしている敵
    [SerializeField]
    private GameObject nowTarget;
    //　主人公操作スクリプト
    private RotateEnemyChara rotateEnemyChara;

    void Start()
    {
        enemyList = new List<GameObject>();
        nowTarget = null;
        rotateEnemyChara = GetComponentInParent<RotateEnemyChara>();
    }

    void Update()
    {
        //　ターゲットがいる場合に左右のキーを押したらターゲットを変える
        TargetOthers();
    }

    void TargetOthers()
    {
        //　一人も敵を登録していなければ何もしない
        if (enemyList.Count == 0)
        {
            nowTarget = null;
            return;
        }

        /*if (rotateEnemyChara.GetState() != RotateEnemyChara.State.WaitShot || rotateEnemyChara.IsRotate() || Mathf.Approximately(Input.GetAxis("Horizontal"), 0f))
        {
            return;
        }*/

        //float inputHorizontal = Input.GetAxis("Horizontal");

        GameObject nearTarget = null;
       
        float nearTargetAngle = 360f;

        foreach (var enemy in enemyList)
        {
            //　この敵が現在のターゲットの時、または主人公と敵との間に壁があれば何もしない
            if (enemy == nowTarget
                || Physics.Linecast(transform.parent.transform.position + Vector3.up, enemy.transform.position + Vector3.up, LayerMask.GetMask("Field")))
            {
                continue;
            }
            //　今調べている敵と主人公との角度を設定
            float targetAngle = Vector3.SignedAngle(transform.parent.forward, enemy.transform.position - transform.parent.position, Vector3.up);
            //　現在ターゲットにしている敵と主人公との角度を設定（設定されていない時はエラーになるので回避）
            if (nearTarget != null)
            {
                nearTargetAngle = Vector3.SignedAngle(transform.parent.forward, nearTarget.transform.position - transform.parent.position, Vector3.up);
            }

          
            /*if ((inputHorizontal < 0f && -180f <= targetAngle && targetAngle <= 0f)
                || (inputHorizontal > 0f && 0f <= targetAngle && targetAngle <= 180f)
                    )
            {
                if (nearTarget == null)
                {
                    nearTarget = enemy;
                }
                else if (Mathf.Abs(targetAngle) < Mathf.Abs(nearTargetAngle))
                {
                    nearTarget = enemy;
                }
            }*/
        }
        //　近くのターゲットがいれば設定
        if (nearTarget != null)
        {
            nowTarget = nearTarget;
        }
    }

    void OnTriggerStay(Collider col)
    {
        Debug.DrawLine(transform.parent.position + Vector3.up, col.gameObject.transform.position + Vector3.up, Color.blue);
        //　敵を登録する
        if (col.tag == "Enemy"
            && !enemyList.Contains(col.gameObject)
        )
        {
            enemyList.Add(col.gameObject);
        }
    }
    void OnTriggerExit(Collider col)
    {
        //　敵がサーチエリアを抜けたらリストから削除
        if (col.tag == "Enemy"
            && enemyList.Contains(col.gameObject)
        )
        {
            //　ターゲットになっていたらターゲットを解除
            if (col.gameObject == nowTarget)
            {
                nowTarget = null;
            }
            enemyList.Remove(col.gameObject);
        }
    }
    //　現在のターゲットを返す
    public GameObject GetNowTarget()
    {
        return nowTarget;
    }
    //　敵が死んだ時に呼び出して敵をリストから外す
    void DeleteEnemyList(GameObject obj)
    {
        if (nowTarget == obj)
        {
            nowTarget = null;
        }
        enemyList.Remove(obj);
    }

    //　ターゲットを設定
    public void SetNowTarget()
    {

        //　一番近い敵を標的に設定する
        foreach (var enemy in enemyList)
        {
            //　ターゲットがいなくて敵との間に壁がなければターゲットにする
            if (nowTarget == null)
            {
                if (!Physics.Linecast(transform.parent.position + Vector3.up, enemy.transform.position + Vector3.up, LayerMask.GetMask("Field")))
                {
                    nowTarget = enemy;
                }
                //　ターゲットがいる場合で今の敵の方が近ければ今の敵をターゲットにする
            }
            else if (Vector3.Distance(transform.parent.position, enemy.transform.position) < Vector3.Distance(transform.parent.position, nowTarget.transform.position)
              && !Physics.Linecast(transform.parent.position + Vector3.up, enemy.transform.position + Vector3.up, LayerMask.GetMask("Field"))
          )
            {
                nowTarget = enemy;
            }
        }
    }
}

