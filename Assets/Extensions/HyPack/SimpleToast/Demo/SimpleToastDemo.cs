using UnityEngine;

namespace HyPack.Demo
{
    public class SimpleToastDemo : MonoBehaviour
    {
        public Color textColor = Color.green;
        public void OnLogBtnClick(string msg)
        {
            SimpleToast.Show(msg, textColor);
        }
    }
}

