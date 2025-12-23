using UnityEngine;
using System.Collections;

namespace UnityUtils.ScriptUtils.Cameras
{
    public static class CameraShake
    {
        /// Default curve used for screenshake
        public static AnimationCurve defaultScreenshakeCurve = new AnimationCurve(
            new Keyframe(0, 0),
            new Keyframe(0.2f, 0.1f, -0.05f, -0.05f),
            new Keyframe(1, 0)
        );

        /// <summary>
        /// Shakes the inputted camera for a specified amount of time with a certain intensity following an animation curve
        /// </summary>
        /// <param name="camera">Camera to apply screenshake to, default is Camera.main</param>
        /// <param name="intensity">A multiplier for more screenshake</param>
        /// <param name="duration">How many seconds the screenshake lasts for</param>
        /// <param name="curve">Curve used to apply screenshake</param>
        /// <param name="useRealtime">If true, will use Time.unscaledDeltatime, instead of Time.deltaTime</param>
        public static void Screenshake(Transform camera = default, float intensity = 1, float duration = 0.5f, AnimationCurve curve = default, bool useRealtime = true)
        {
            if (curve == default) curve = defaultScreenshakeCurve;
            if (camera == default) camera = Camera.main.transform;

            CoroutineHelper.Starter.StartCoroutine(ScreenshakeCoroutine(camera, intensity, duration, curve, useRealtime));
        }
        private static IEnumerator ScreenshakeCoroutine(Transform camera, float intensity, float duration, AnimationCurve curve, bool useRealtime)
        {
            Vector3 startPosition = camera.localPosition;
            float elapsedTime = 0;

            while (elapsedTime < duration)
            {
                elapsedTime += useRealtime ? Time.unscaledDeltaTime : Time.deltaTime;
                float strength = curve.Evaluate(elapsedTime / duration) * intensity;
                camera.localPosition = startPosition + Random.insideUnitSphere * strength;
                yield return null;
            }

            camera.localPosition = startPosition;
        }
    }
}
