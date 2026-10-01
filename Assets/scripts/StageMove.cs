using UnityEngine;
using UnityEngine.InputSystem;

public class StageMove : MonoBehaviour
{
    //プレイヤーの入力（WASD、矢印キー）が入力されたらStageを回転させる。
    private InputAction _playerInput;

    //回転させたい対象のオブジェクト
    [SerializeField]
        private GameObject _stage;

    //変数の定義について
    //１．pribate <- アクセス修飾子：［3._playerInput]に入るデータを宣言
    //
    //
    //

    // _playerInput <- 変数：データを保管する箱
    // void Start() <- 関数（メゾット）：処理を入れる箱

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InputiSystemのアクションマップから"Move"という名前のアクションを探して取得する
        _playerInput = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    // 1フレーム毎にこの関数が呼ばれる
    void Update()
    {
        // _playerInputの値によってステージを回転させる
        Debug.Log(_playerInput.ReadValue<Vector2>());
        // Stageを回転させる処理
        // 水平(Horizontal)入力の取得
        float horizontalInput = _playerInput.ReadValue<Vector2>().x;
        // 垂直(Vertical)入力の取得
        float verticalInput = _playerInput.ReadValue<Vector2>().y;

        //オブジェクトを回転させる
        _stage.transform.Rotate(horizontalInput,0f,verticalInput);
    }
}
