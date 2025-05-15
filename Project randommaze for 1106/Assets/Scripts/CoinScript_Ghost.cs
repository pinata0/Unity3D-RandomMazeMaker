using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

using BackEnd;

public class CoinScript_Ghost : MonoBehaviour
{
    [SerializeField]
    public int gollcoin;

    public int eatencoin = 0;
    public Canvas canvasToActivate;
    public Canvas overcanvas;
    private bool isGameClear = false;

    public Text stopwatchText; // UI 텍스트 객체를 연결할 변수
    public Text stopwatchText1;
    private float elapsedTime; // 경과 시간
    private bool isRunning = true; // 스톱워치 실행 중 여부
    private bool isgameover = false;

    public DisplayNumbers displayscript;


    private void Start()
    {
        canvasToActivate.gameObject.SetActive(true);
        if (stopwatchText != null)
        {
            stopwatchText.text = "Elapsed Time: 0"; // 초기 텍스트 설정
        }
        canvasToActivate.gameObject.SetActive(false);
        overcanvas.gameObject.SetActive(false);


    }

    private void Update()
    {
        if (isRunning)
        {
            if (eatencoin <= gollcoin)
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
        if (other.CompareTag("Coin") && isgameover == false)
        {
            eatencoin += 1;
            Debug.Log(eatencoin);
            displayscript.UpdateSprites(eatencoin);
            other.gameObject.SetActive(false);

            if (eatencoin == gollcoin)
            {
                canvasToActivate.gameObject.SetActive(true);
                int elapsedTimeInt1 = Mathf.FloorToInt(elapsedTime); // 경과 시간을 정수로 변환
                stopwatchText.text = "Elapsed Time: " + elapsedTimeInt1.ToString() + "sec";
                BackendRank.Instance.RankInsert_horror(elapsedTimeInt1); // [추가] 랭킹 등록하기 함수
                isGameClear = true;

            }

            if (isGameClear)
            {
                isRunning = false;
            }

        }

        if (other.CompareTag("Ghost"))
        {
            displayscript.UpdateSprites(eatencoin);
            other.gameObject.SetActive(false);

            overcanvas.gameObject.SetActive(true);

            stopwatchText1.text = "You Die";
            isGameClear = true;
            isgameover = true;


            if (isGameClear)
            {
                isRunning = false;
            }

        }



    }

    public int GetValue()
    {
        return eatencoin;
    }


}