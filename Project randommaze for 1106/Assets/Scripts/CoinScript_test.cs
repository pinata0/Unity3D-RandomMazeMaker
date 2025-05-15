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

    public Text stopwatchText; // UI �ؽ�Ʈ ��ü�� ������ ����
    public Text stopwatchText1;
    private float elapsedTime; // ��� �ð�
    private bool isRunning = true; // �����ġ ���� �� ����


    public DisplayNumbers displayscript;


    private void Start()
    {
        canvasToActivate.gameObject.SetActive(true);
        if (stopwatchText != null)
        {
            stopwatchText.text = "Elapsed Time: 0"; // �ʱ� �ؽ�Ʈ ����
        }
        canvasToActivate.gameObject.SetActive(false);



    }

    private void Update()
    {
        if (isRunning)
        {
            if (eatencoin_test <= gollcoin_test)
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
        if (other.CompareTag("Coin"))
        {
            eatencoin_test += 1;
            Debug.Log(eatencoin_test);
            displayscript.UpdateSprites(eatencoin_test);
            other.gameObject.SetActive(false);

            if (eatencoin_test == gollcoin_test)
            {
                canvasToActivate.gameObject.SetActive(true);
                int elapsedTimeInt1 = Mathf.FloorToInt(elapsedTime); // ��� �ð��� ������ ��ȯ
                stopwatchText.text = "Elapsed Time: " + elapsedTimeInt1.ToString() + "sec";
                BackendRank.Instance.RankInsert_normal(elapsedTimeInt1); // [�߰�] ��ŷ ����ϱ� �Լ�
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