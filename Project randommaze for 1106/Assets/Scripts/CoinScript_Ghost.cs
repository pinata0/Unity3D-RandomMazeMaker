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

    public Text stopwatchText; // UI �ؽ�Ʈ ��ü�� ������ ����
    public Text stopwatchText1;
    private float elapsedTime; // ��� �ð�
    private bool isRunning = true; // �����ġ ���� �� ����
    private bool isgameover = false;

    public DisplayNumbers displayscript;


    private void Start()
    {
        canvasToActivate.gameObject.SetActive(true);
        if (stopwatchText != null)
        {
            stopwatchText.text = "Elapsed Time: 0"; // �ʱ� �ؽ�Ʈ ����
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
                elapsedTime += Time.deltaTime; // ��� �ð� ����
            }
            DisplayElapsedTime();
        }
    }

    void DisplayElapsedTime()
    {
        if (stopwatchText != null)
        {
            int elapsedTimeInt = Mathf.FloorToInt(elapsedTime); // ��� �ð��� ������ ��ȯ
            stopwatchText.text = "Elapsed Time: " + elapsedTimeInt.ToString(); // ������ ǥ��

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
                int elapsedTimeInt1 = Mathf.FloorToInt(elapsedTime); // ��� �ð��� ������ ��ȯ
                stopwatchText.text = "Elapsed Time: " + elapsedTimeInt1.ToString() + "sec";
                BackendRank.Instance.RankInsert_horror(elapsedTimeInt1); // [�߰�] ��ŷ ����ϱ� �Լ�
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