using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityUtils.ScriptUtils.Audio;
using static UnityUtils.ScriptUtils.Audio.AudioManager;

namespace UnityUtils.ScriptUtils.UI
{
    [RequireComponent(typeof(Button))]
    public class UIButtonDebugLogs : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("Debug")]
        public bool logHover = true;
        public bool logExit = true;
        public bool logClick = true;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (logHover)
            {
                Debug.Log("Hovered over button!");
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (logExit)
            {
                Debug.Log("Exited hovering button!");
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (logClick)
            {
                Debug.Log("Clicked button!");
            }
        }
    }
}