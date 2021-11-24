using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    //スコアを表示するテキスト
    private GameObject scoreText;

    //タグ
    string smallStarTag = "SmallStarTag";
    string largeStarTag = "LargeStarTag";
    string smallCloudTag = "SmallCloudTag";
    string largeCloudTag = "LargeCloudTag";
    string isScoreText = "ScoreText";
    string isGameOverText = "GameOverText";

    //スコア
    int isSmallStarScore = 5;
    int isLargeStarScore = 10;
    int isSmallCloudScore = 20;
    int isLargeCloudScore = 40;
    int score = 0;


    void Start() {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find(isGameOverText);
        this.scoreText = GameObject.Find(isScoreText);
        this.scoreText.GetComponent<Text>().text = "Score: " + score;
    }

    // Update is called once per frame
    void Update() {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ) {

            //GameoverTextにゲームオーバー表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

    }

    //ボールがオブジェクトに当たった時のスコア処理
    private void OnCollisionEnter(Collision collision) {

        scoreCollision(collision);

    }

    //スコア処理
    public void scorePlus(int point) {

        score += point;
        this.scoreText.GetComponent<Text>().text = "Score: " + score;

    }

    public void scoreCollision(Collision collision) {

        //各タグの衝突判定を代入
        var isSmallStar = collision.gameObject.CompareTag(smallStarTag);
        var isLargeStar = collision.gameObject.CompareTag(largeStarTag);
        var isSmallCloud = collision.gameObject.CompareTag(smallCloudTag);
        var isLargeCloud = collision.gameObject.CompareTag(largeCloudTag);

        //衝突判定による得点処理
        if (isSmallStar) scorePlus(isSmallStarScore);
        if (isLargeStar) scorePlus(isLargeStarScore);
        if (isSmallCloud) scorePlus(isSmallCloudScore);
        if (isLargeCloud) scorePlus(isLargeCloudScore);
    }
}
