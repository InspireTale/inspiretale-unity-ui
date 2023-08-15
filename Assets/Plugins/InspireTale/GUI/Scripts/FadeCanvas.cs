using Cysharp.Threading.Tasks;
using UnityEngine;

namespace InspireTale.UI
{
    [RequireComponent(typeof(CanvasGroupFadeTransition))]
    public class FadeCanvas : BaseGUICanvas
    {
        [Tooltip("Fade in/out transition duration.")]
        [SerializeField]
        private float fadeDuration = 0.5f;

        public bool IsFading => this.canvasGroup.alpha != 0 || this.canvasGroup.alpha != 1;

        protected CanvasGroupFadeTransition canvasGroupFadeTransition;
        protected override void Awake()
        {
            base.Awake();
            this.canvasGroupFadeTransition = GetComponent<CanvasGroupFadeTransition>();
        }

        public override async UniTask Show()
        {
            if (this.IsShow)
            {
                return;
            }

            await base.Show();
            await this.canvasGroupFadeTransition.FadeIn(this.fadeDuration);
            this.canvasGroup.interactable = true;
            this.canvasGroup.blocksRaycasts = this.isBlockRaycast;
        }

        public override async UniTask Hide()
        {
            if (!this.IsShow)
            {
                return;
            }

            await this.canvasGroupFadeTransition.FadeOut(this.fadeDuration);
            this.canvasGroup.interactable = false;
            this.canvasGroup.blocksRaycasts = false;
            await base.Hide();
        }
    }
}
