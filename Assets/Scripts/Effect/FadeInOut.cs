using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    private bool isFading = false;
    public float fadeDuration = 0.5f; // Thời gian tăng/giảm độ trong suốt
    public float fadeTimer = 0f;
    private float startAlpha = 1f; // Giá trị độ trong suốt ban đầu
    public float targetAlpha = 0f; // Giá trị độ trong suốt tăng/giảm đến

    public int numberOfFades = 3; // Số lần trong suốt
    private int currentFadeCount = 0; // Biến đếm số lần đã trong suốt

    private Renderer rendererPlayer;
    private Color startColor;

    private void Start()
    {
        // Lấy Renderer component để thay đổi màu sắc
        rendererPlayer = GetComponent<Renderer>();
        if (rendererPlayer != null)
        {
            startColor = rendererPlayer.material.color;
        }
    }

    private void Update()
    {
        if (isFading)
        {
            // Tính toán giá trị độ trong suốt mới dựa trên thời gian
            fadeTimer += Time.deltaTime;
            float t = fadeTimer / fadeDuration;
            float newAlpha = rendererPlayer.material.color.a;

            if (currentFadeCount % 2 != 0)
            {
                newAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            }
            else
            {
                newAlpha = Mathf.Lerp( targetAlpha, startAlpha, t); // đảo ngược
            }


            // Cập nhật màu sắc với độ trong suốt mới
            Color newColor = new Color(startColor.r, startColor.g, startColor.b, newAlpha);
            rendererPlayer.material.color = newColor;

            if (t >= 1f)
            {
                // Hoàn thành tăng/giảm độ trong suốt, đặt lại các giá trị ban đầu
                fadeTimer = 0f;
                currentFadeCount++;

                if (currentFadeCount >= numberOfFades)
                {
                    isFading = false;
                    currentFadeCount = 0;
                    rendererPlayer.material.color = startColor;
                }
            }
        }
    }

    public void StartFading()
    {
        isFading = true;
        fadeTimer = 0f;
        currentFadeCount = 0;
    }
}
