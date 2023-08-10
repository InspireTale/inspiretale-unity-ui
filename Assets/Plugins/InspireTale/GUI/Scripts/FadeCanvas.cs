using System.Threading;
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

        protected CanvasGroupFadeTransition canvasGroupFadeTransition;
        protected CancellationTokenSource showTransitionTokenSource;
        protected CancellationTokenSource hideTransitionTokenSource;

        protected override void Awake()
        {
            base.Awake();
            this.canvasGroupFadeTransition = GetComponent<CanvasGroupFadeTransition>();
        }

        public override async UniTask Show()
        {
            this.showTransitionTokenSource?.Cancel();
            this.showTransitionTokenSource?.Dispose();
            this.showTransitionTokenSource = new();
            await base.Show();
            await this.canvasGroupFadeTransition.FadeIn(this.fadeDuration, this.showTransitionTokenSource.Token);
            this.canvasGroup.interactable = true;
            this.canvasGroup.blocksRaycasts = this.isBlockRaycast;
        }

        public override async UniTask Hide()
        {
            this.hideTransitionTokenSource?.Cancel();
            this.hideTransitionTokenSource?.Dispose();
            this.hideTransitionTokenSource = new();
            await this.canvasGroupFadeTransition.FadeOut(this.fadeDuration, this.hideTransitionTokenSource.Token);
            this.canvasGroup.interactable = false;
            this.canvasGroup.blocksRaycasts = false;
            await base.Hide();
        }
    }
}
