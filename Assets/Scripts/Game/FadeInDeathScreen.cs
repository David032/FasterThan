using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInDeathScreen : MonoBehaviour
{
    public CanvasGroup uiElement;
    public GameObject player;

    private void Start()
    {
        FadeIn();
    }
    public void FadeIn()
    {
        if(player.GetComponent<Player_Movement>().canMove == false)
        {
            StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1));
        }
        
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
    {
        yield return new WaitForSeconds(1f);
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;
       
        while(true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Done");
    }
}
