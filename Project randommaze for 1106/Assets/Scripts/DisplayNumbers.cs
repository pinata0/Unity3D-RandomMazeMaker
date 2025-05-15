using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayNumbers : MonoBehaviour
{
    public Canvas canvasToActivate1;
    public Image[] sprites;

    private void Start()
    {
        canvasToActivate1.gameObject.SetActive(true);
        foreach (var sprite in sprites)
        {
            sprite.gameObject.SetActive(false);
        }

    }

    public void UpdateSprites(int eatencoin)
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            if (i == eatencoin - 1)
            {
                sprites[i].gameObject.SetActive(true);
            }
            else
            {
                sprites[i].gameObject.SetActive(false);
            }
        }
    }
}
