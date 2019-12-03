using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    public void doRespawn()
    {
        var uiElement = GetComponent<CanvasGroup>();
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        StartCoroutine(DoFade(uiElement, uiElement.alpha, 1));

    }

    // Update is called once per frame
    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;

        while (counter < 1)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / 1);
            yield return null;
        }
    }
}
