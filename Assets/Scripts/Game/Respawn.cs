using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    bool done;
    public CanvasGroup uiElement;
    // Start is called before the first frame update
    public void doRespawn()
    {
        if(!done)
        {
            StartCoroutine(DoFade(uiElement, uiElement.alpha, 1));
        Debug.Log("fade you died");
        }
        

    }

    // Update is called once per frame
    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;

        while (counter < 1)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / 0.5f);
            yield return null;
        }
        done = true;
    }
}
