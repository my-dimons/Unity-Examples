using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityUtils.ScriptUtils.UI
{
    [RequireComponent(typeof(Button))]
    public class UIButtonHoverExpand : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("Adjustable Values")]
        /// When hovered this is the size the button will be set to.
        public float hoverSize = 1.3f;

        /// The amount of seconds that the button will size up or down in.
        public float sizeAnimationSeconds = 0.2f;

        [Space(8)]

        /// The <see cref="AnimationCurve"/> that the button will follow.
        public AnimationCurve SizingCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

        [Header("Debug Values")]

        /// True if the button is being hovered
        public bool hoveringOverButton;


        Vector3 originalSize;
        Vector3 hoverSizeVector;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            originalSize = transform.localScale;
        }

        // Update is called once per frame
        void Update()
        {
            hoverSizeVector = new Vector3(hoverSize, hoverSize, hoverSize);

            if (!hoveringOverButton && transform.localScale == hoverSizeVector)
            {
                ExitHoverAnimation();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (transform.localScale == originalSize)
                EnterHoverAnimation();

            hoveringOverButton = true;
            Debug.Log("Hovered over button");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (transform.localScale == hoverSizeVector)
                ExitHoverAnimation();

            hoveringOverButton = false;
            Debug.Log("Exited hover button");
        }

        /// <summary>
        /// Grows the button to the original size (<see cref="hoverSizeVector"/>).
        /// </summary>
        void EnterHoverAnimation()
        {
            StartCoroutine(UIUtilsManager.AnimateButtonSize(this.gameObject, originalSize, hoverSizeVector, SizingCurve, UIUtilsManager.CalculateAnimationSpeed(sizeAnimationSeconds)));
        }

        /// <summary>
        /// Shrinks the button to its original size.
        /// </summary>
        void ExitHoverAnimation()
        {
            StartCoroutine(UIUtilsManager.AnimateButtonSize(this.gameObject, hoverSizeVector, originalSize, SizingCurve, UIUtilsManager.CalculateAnimationSpeed(sizeAnimationSeconds)));
        }
    }
}
