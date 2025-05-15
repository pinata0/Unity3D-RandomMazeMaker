using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

using BackEnd;

public class CoinScript_storyitem : MonoBehaviour
{
    [SerializeField]
    public int goalcoin;

    public int eatencoin = 0;
    public Canvas canvasToActivate;


    public DisplayNumbers displayscript;


    private void Start()
    {
        canvasToActivate.gameObject.SetActive(true);

    }

    private void Update()
    {

    }

    public int GetValue()
    {
        return eatencoin;
    }


}