using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace HyPack
{
    public class SimpleToast : MonoBehaviour
    {

        #region Singleton 
        // ? You can remove this region, then use your way to intergrate in your app.
        private static SimpleToast s_Instance;
        private void Awake()
        {
            if (s_Instance != null)
            {
                print("[Warning] Instance of SimpleToast can exist one only.");
                DestroyImmediate(this);
                return;
            }

            s_Instance = this;
        }

        #endregion Singleton

        public Transform container;
        public GameObject toastBlock;

        [Header("Settings")]
        public float toastLifetime = 5f;
        public Color defaultFontColor = Color.white;
        public AnimationCurve fadeCurve = AnimationCurve.EaseInOut(0, 1f, 1f, 0);

        public static void Show(string msg, Color? color = null)
        {
            s_Instance.StartCoroutine(NewToast(msg, color));
        }

        private static IEnumerator NewToast(string msg, Color? color = null)
        {
            color ??= s_Instance.defaultFontColor;
            ActiveOneToast(out CanvasGroup canvasGroup, out Text txt, out TextMeshProUGUI tmpTxt);
            SetTextAndFontColor(txt, tmpTxt, msg, color.Value);

            // Fade Animation
            for (float f = 0; f < s_Instance.toastLifetime; f += Time.deltaTime)
            {
                canvasGroup.alpha = s_Instance.fadeCurve.Evaluate(f / s_Instance.toastLifetime);
                yield return null;
            }

            canvasGroup.gameObject.SetActive(false);
        }

        private static void SetTextAndFontColor(Text uguiTx, TextMeshProUGUI tmpTx, string text, Color color)
        {
            if (uguiTx != null)
            {
                uguiTx.text = text;
                uguiTx.color = color;
            }

            if (tmpTx != null)
            {
                tmpTx.text = text;
                tmpTx.color = color;
            }
        }

        private static void ActiveOneToast(out CanvasGroup cg, out Text txt, out TextMeshProUGUI tmpTxt)
        {
            GameObject availableToast = null;
            for (int i = 0; i < s_Instance.container.childCount; i++)
            {
                availableToast = s_Instance.container.GetChild(i).gameObject;
                if (availableToast.activeSelf == false) break;
            }

            if (availableToast == null || availableToast.activeSelf)
            {
                availableToast = Instantiate(s_Instance.toastBlock, s_Instance.container);
            }

            availableToast.transform.SetAsLastSibling();
            availableToast.SetActive(true);

            cg = availableToast.GetComponent<CanvasGroup>();
            txt = availableToast.GetComponentInChildren<Text>();
            tmpTxt = availableToast.GetComponentInChildren<TextMeshProUGUI>();
        }
    }
}