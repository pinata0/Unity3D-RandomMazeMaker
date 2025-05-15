using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

using BackEnd;

public class CoinScript_test : MonoBehaviour
{
    [SerializeField]
    public int gollcoin_test;

    public int eatencoin_test = 0;
    public Canvas canvasToActivate;

    private bool isGameClear = false;

    public Text stopwatchText; // UI 텍스트 객체를 연결할 변수
    public Text stopwatchText1;
    private float elapsedTime; // 경과 시간
    private bool isRunning = true; // 스톱워치 실행 중 여부


    public DisplayNumbers displayscript;


    private void Start()
    {
        canvasToActivate.gameObject.SetActive(true);
        if (stopwatchText != null)
        {
            stopwatchText.text = "Elapsed Time: 0"; // 초기 텍스트 설정
        }
        canvasToActivate.gameObject.SetActive(false);



    }

    private void Update()
    {
        if (isRunning)
        {
            if (eatencoin_test <= gollcoin_test)
            {   
                elapsedTime += Time.deltaTime; // 경과 시간 증가
            }
            DisplayElapsedTime();
        }
    }

    void DisplayElapsedTime()
    {
        if (stopwatchText != null)
        {
            int elapsedTimeInt = Mathf.FloorToInt(elapsedTime); // 경과 시간을 정수로 변환
            stopwatchText.text = "Elapsed Time: " + elapsedTimeInt.ToString(); // 정수로 표시

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            eatencoin_test += 1;
            Debug.Log(eatencoin_test);
            displayscript.UpdateSprites(eatencoin_test);
            other.gameObject.SetActive(false);

            if (eatencoin_test == gollcoin_test)
            {
                canvasToActivate.gameObject.SetActive(true);
                int elapsedTimeInt1 = Mathf.FloorToInt(elapsedTime); // 경과 시간을 정수로 변환
                stopwatchText.text = "Elapsed Time: " + elapsedTimeInt1.ToString() + "sec";
                BackendRank.Instance.RankInsert_normal(elapsedTimeInt1); // [추가] 랭킹 등록하기 함수
                isGameClear = true;

            }

            if (isGameClear)
            {
                isRunning = false;
            }

        }


    }

    public int GetValue()
    {
        return eatencoin_test;
    }


}