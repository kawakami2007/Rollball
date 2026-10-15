using UnityEngine;
using UnityEngine.InputSystem;

public class StageMove : MonoBehaviour
{
    // プレイヤーの入力（WASD, 矢印キー）が入力されたらStageを回転させる
    private InputAction _playerInput;

    // 回転させたい対称のオブジェクト
    [SerializeField]
    private GameObject _stage;

    // _playerInput <- 変数：データを保管する箱
    // void Start() <- 関数(メソッド)：処理を入れる箱
    
    void Start()
    {
        // InputSystem.actions.FindAction("Move") 
        // ↑InputSystemのアクションマップから"Move"という名前のアクションを探して取得する
        _playerInput = InputSystem.actions.FindAction("Move");
    }

    // １フレーム毎にこの関数が呼ばれる
    void Update()
    {
        // _playerInputの値によってステージを回転させる

        // Stageを回転させる処理
        // 水平(horizontal)入力の取得
        float horizontalInput = _playerInput.ReadValue<Vector2>().x;
        // 垂直(vertical)入力の取得
        float verticalInput = _playerInput.ReadValue<Vector2>().y;

        //Vector2の入力をVector3に変換
        Vector3 rotation = new Vector3(horizontalInput, 0, verticalInput);

        //オイラー角に変換
        Quaternion tilt = Quaternion.Euler(rotation.x,0f,rotation.z);

        //変換した値をRigidbodyに渡す
        _stage.GetComponent<Rigidbody>().MoveRotation(
            _stage.GetComponent<Rigidbody>().transform.rotation * tilt);

        // オブジェクトを回転させる
        //_stage.transform.Rotate(horizontalInput*0.2f,0f,verticalInput*0.2f);

    }
}




//〇ゴール判定の作成(10:50まで)
//1.IsTrigeerの判定をコード上から取得
//2.すり抜けたらCanvasにゴールしたよ！とメッセージ表示
//（TextMeshProで表示）
//EX1.ゴール時に音を鳴らそう
//EX2.壁を増やして迷路を作ろう
//EX3.透明な当たり判定のある天井を作ろう
