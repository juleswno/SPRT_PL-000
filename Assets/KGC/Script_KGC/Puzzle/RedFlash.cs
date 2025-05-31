using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RedFlash : MonoBehaviour
{
    public Image flashPanel;
    public float flashInterval = 0.3f;
    public float flashMaxAlpha = 0.4f;

    public void StartFlash()
    {
        StartCoroutine(FlahRoutine());
    }

    private IEnumerator FlahRoutine()
    {
        flashPanel.gameObject.SetActive(true);

        while (true)
        {
            SetAlpha(flashMaxAlpha);
            yield return new WaitForSeconds(flashInterval);
            SetAlpha(0f);
            yield return new WaitForSeconds(flashInterval);
        }
    }

    void SetAlpha(float _alpha)
    {
        Color color = flashPanel.color;
        color.a = _alpha;
        flashPanel.color = color;
    }
}
