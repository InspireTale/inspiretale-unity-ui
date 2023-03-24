using Cysharp.Threading.Tasks;
using UnityEngine;

namespace InspireTale.UI
{
    [RequireComponent(typeof(CanvasGroupFadingTransition))]
    public class FadingGUICanvas : BaseGUICanvas
    {
        [SerializeField]
        private float fadeDuration = 0.5f;

        private CanvasGroupFadingTransition canvasGroupFadingTransition;

        protected override void Awake()
        {
            base.Awake();
            this.canvasGroupFadingTransition = GetComponent<CanvasGroupFadingTransition>();
        }

        public override async UniTask Show()
        {
            if (isShow)
            {
                return;
            }

            await base.Show();
            await this.canvasGroupFadingTransition.FadeIn(this.fadeDuration);
            this.canvasGroup.interactable = true;
            this.canvasGroup.blocksRaycasts = this.isBlockRaycast;
        }

        public override async UniTask Hide()
        {
            if (!isShow)
            {
                return;
            }

            await this.canvasGroupFadingTransition.FadeOut(this.fadeDuration);
            this.canvasGroup.interactable = false;
            this.canvasGroup.blocksRaycasts = false;
            await base.Hide();
        }
    }
}
