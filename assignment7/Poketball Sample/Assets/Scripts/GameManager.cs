using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class GameManager : MonoBehaviour
{
    UIManager MyUIManager;
    AudioManager MyAudioManager;

    public GameObject BallPrefab;   // prefab of Ball

    // Constants for SetupBalls
    public static Vector3 StartPosition = new Vector3(0, 0, -6.35f);
    public static Quaternion StartRotation = Quaternion.Euler(0, 90, 90);
    const float BallRadius = 0.286f;
    const float RowSpacing = 0.6f;

    GameObject PlayerBall;
    GameObject CamObj;

    const float CamSpeed = 3f;

    const float MinPower = 15f;
    const float PowerCoef = 1f;

    void Awake()
    {
        // PlayerBall, CamObj, MyUIManager를 얻어온다.
        // ---------- TODO ---------- 
        PlayerBall = GameObject.Find("PlayerBall");
        CamObj = GameObject.Find("Main Camera");
        MyUIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        MyAudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        // -------------------- 
    }

    void Start()
    {
        SetupBalls();
    }

    // Update is called once per frame
    void Update()
    {
        // 좌클릭시 raycast하여 클릭 위치로 ShootBallTo 한다.
        // ---------- TODO ---------- 
        if(Input.GetMouseButtonDown(0)) {
            Debug.Log("Bruh");
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
                ShootBallTo(hit.point);
            }
            MyAudioManager.BallHit(1);
        }
        // -------------------- 
    }

    void LateUpdate()
    {
        CamMove();
    }

    void SetupBalls()
    {
        // 15개의 공을 삼각형 형태로 배치한다.
        // 가장 앞쪽 공의 위치는 StartPosition이며, 공의 Rotation은 StartRotation이다.
        // 각 공은 RowSpacing만큼의 간격을 가진다.
        // 각 공의 이름은 {index}이며, 아래 함수로 index에 맞는 Material을 적용시킨다.
        // Obj.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/ball_1");
        // ---------- TODO ---------- 

        GameObject[] HitBall = new GameObject[15];

        for(int i = 0; i < 15; i++) {
            float xpos = 0;
            float zpos = 0;
            int buffer = 0;
            int zcount = 4;

            for(int j = 0; j < 4; j++) {
                if(i - buffer <= 0) {
                    zcount = j;
                    Debug.Log(i + " is out on " + j);
                    break;
                }
                else {
                    buffer += j + 2; // 0, 2, 5, 9, 14
                }
            }

            Debug.Log(zcount);

            zpos = RowSpacing * zcount * -1;
            xpos = (RowSpacing / 2) * zcount + RowSpacing * (buffer - i) * (-1);

            HitBall[i] = Instantiate(BallPrefab);
            HitBall[i].name = "" + (i + 1);
            HitBall[i].transform.position = StartPosition + new Vector3(xpos, 0, zpos);
            HitBall[i].transform.rotation = StartRotation;
            HitBall[i].transform.localScale = new Vector3(BallRadius * 2, BallRadius * 2, BallRadius * 2);
            HitBall[i].GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/ball_" + (i + 1));
            HitBall[i].tag = "Ball";
        }
        // -------------------- 
    }
    void CamMove()
    {
        // CamObj는 PlayerBall을 CamSpeed의 속도로 따라간다.
        // ---------- TODO ---------- 
        CamObj.transform.position += new Vector3(PlayerBall.transform.position.x - CamObj.transform.position.x, 0, PlayerBall.transform.position.z - CamObj.transform.position.z) * Time.deltaTime * CamSpeed;
        // -------------------- 
    }

    float CalcPower(Vector3 displacement)
    {
        return MinPower + displacement.magnitude * PowerCoef;
    }

    void ShootBallTo(Vector3 targetPos)
    {
        // targetPos의 위치로 공을 발사한다.
        // 힘은 CalcPower 함수로 계산하고, y축 방향 힘은 0으로 한다.    // @gpzofficial: Dunno why doing this way; just calculated myself
        // ForceMode.Impulse를 사용한다.       
        // ---------- TODO ---------- 
       
        Rigidbody b_rd = PlayerBall.GetComponent<Rigidbody>();
        float ballPower = CalcPower(targetPos - PlayerBall.transform.position);
        b_rd.AddForce(new Vector3(targetPos.x - PlayerBall.transform.position.x, 0, targetPos.z - PlayerBall.transform.position.z) * ballPower / 10, ForceMode.Impulse);
        // -------------------- 
    }
    
    // When ball falls
    public void Fall(string ballName)
    {
        // "{ballName} falls"을 1초간 띄운다.
        // ---------- TODO ---------- 
        MyUIManager.DisplayText(ballName + " falls", 1f);
        
        // -------------------- 
    }
    
    
}
