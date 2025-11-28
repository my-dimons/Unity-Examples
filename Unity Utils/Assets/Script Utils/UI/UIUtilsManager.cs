using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityUtils.ScriptUtils.UI
{
    public static class UIUtilsManager
    {
        /// <summary>
        /// Animates the scale of a button from its original size to a new size over time using a specified animation
        /// curve.
        /// </summary>
        /// <remarks>If you want to use seconds for sizeAnimationSeconds, calculate the seconds using the <see cref="CalculateAnimationSpeed(float, float)"/> function</remarks>
        public static IEnumerator AnimateButtonSize(GameObject obj, Vector3 originalSize, Vector3 newSize, AnimationCurve SizingCurve, float speed)
        {
            float time = 0;

            while (time < 1)
            {
                time += Time.deltaTime * speed;
                obj.transform.localScale = Vector3.Lerp(originalSize, newSize, SizingCurve.Evaluate(time));
                yield return null;
            }

            obj.transform.localScale = newSize;
        }

        /// <summary>
        /// Calculates the animation sizeAnimationSeconds for the <see cref="AnimateButtonSize(GameObject, Vector3, Vector3, AnimationCurve, float)"/> function if you want to use seconds
        /// </summary>
        /// <param name="time">The duration, in seconds, over which the animation occurs</param>
        /// <returns>The calculated animation sizeAnimationSeconds, expressed as distance per second.</returns>
        public static float CalculateAnimationSpeed(float time)
        {
            if (time == 0)
                return 0;

            return 1 / time;
        }
    }
}

