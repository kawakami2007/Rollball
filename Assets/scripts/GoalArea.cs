using UnityEngine;

public class GoalArea : MonoBehaviour
{
    public GameObject GoalText;

    // IsTriggerが設定されているオブジェクトについていると
    // コライダーとの接触判定を行ってくれる関数
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GoalText.SetActive(true);
        }
    }
    // 障害物(壁の追加、迷路の作成)
    // EX.音を出す
    // EX2.動く障害物
    // EX3.ライフ制 3回 トゲに当たったら終了
    // やりたい人用:UnityAssetsから3Dモデルを持ってくる
}
