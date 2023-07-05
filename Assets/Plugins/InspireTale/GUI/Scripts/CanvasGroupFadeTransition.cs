using System.Collections;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace InspireTale.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasGroupFadeTransition : MonoBehaviour
    {
        [SerializeField]
        private AnimationCurve fadingCurve;

        private CanvasGroup canvasGroup;

        protected virtual void Awake()
        {
            this.canvasGroup = GetComponent<CanvasGroup>();
        }

        public UniTask FadeIn(float duration_s = 1, CancellationToken cancellationToken = default)
        {
            return this.DoFadeCanvasAlpha(0, 1, duration_s).WithCancellation(cancellationToken);
        }

        public UniTask FadeOut(float duration_s = 1, CancellationToken cancellationToken = default)
        {
            return this.DoFadeCanvasAlpha(1, 0, duration_s).WithCancellation(cancellationToken);
        }

        private IEnumerator DoFadeCanvasAlpha(float startValue, float endValue, float duration_s)
        {
            float time = 0f;
            this.canvasGroup.alpha = startValue;

            while (time < duration_s)
            {
                float t = fadingCurve.Evaluate(time / duration_s);
                this.canvasGroup.alpha = Mathf.Lerp(startValue, endValue, t);
                time += Time.deltaTime;
                yield return null;
            }

            this.canvasGroup.alpha = endValue;
        }
    }
}
