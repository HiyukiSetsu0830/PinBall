using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
    //�{�[����������\���̂���z���̍ő�l
    private float visiblePosZ = -6.5f;

    //�Q�[���I�[�o�[��\������e�L�X�g
    private GameObject gameoverText;

    //�X�R�A��\������e�L�X�g
    private GameObject scoreText;

    //�^�O
    string smallStarTag = "SmallStarTag";
    string largeStarTag = "LargeStarTag";
    string smallCloudTag = "SmallCloudTag";
    string largeCloudTag = "LargeCloudTag";
    string isScoreText = "ScoreText";
    string isGameOverText = "GameOverText";

    //�X�R�A
    int isSmallStarScore = 5;
    int isLargeStarScore = 10;
    int isSmallCloudScore = 20;
    int isLargeCloudScore = 40;
    int score = 0;


    void Start() {
        //�V�[������GameOverText�I�u�W�F�N�g���擾
        this.gameoverText = GameObject.Find(isGameOverText);
        this.scoreText = GameObject.Find(isScoreText);
        this.scoreText.GetComponent<Text>().text = "Score: " + score;
    }

    // Update is called once per frame
    void Update() {
        //�{�[������ʊO�ɏo���ꍇ
        if (this.transform.position.z < this.visiblePosZ) {

            //GameoverText�ɃQ�[���I�[�o�[�\��
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

    }

    //�{�[�����I�u�W�F�N�g�ɓ����������̃X�R�A����
    private void OnCollisionEnter(Collision collision) {

        scoreCollision(collision);

    }

    //�X�R�A����
    public void scorePlus(int point) {

        score += point;
        this.scoreText.GetComponent<Text>().text = "Score: " + score;

    }

    public void scoreCollision(Collision collision) {

        //�e�^�O�̏Փ˔������
        var isSmallStar = collision.gameObject.CompareTag(smallStarTag);
        var isLargeStar = collision.gameObject.CompareTag(largeStarTag);
        var isSmallCloud = collision.gameObject.CompareTag(smallCloudTag);
        var isLargeCloud = collision.gameObject.CompareTag(largeCloudTag);

        //�Փ˔���ɂ�链�_����
        if (isSmallStar) scorePlus(isSmallStarScore);
        if (isLargeStar) scorePlus(isLargeStarScore);
        if (isSmallCloud) scorePlus(isSmallCloudScore);
        if (isLargeCloud) scorePlus(isLargeCloudScore);
    }
}
