using Cysharp.Threading.Tasks;
using UnityEngine;

namespace InspireTale.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class BaseGUICanvas : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup canvasGroup;

        [SerializeField]
        private bool isBlockRaycast;

        public bool isShow
        {
            get
            {
                return this.canvasGroup?.alpha == 1;
            }
        }

        public virtual UniTask Show()
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = this.isBlockRaycast;
            return UniTask.CompletedTask;
        }

        public virtual UniTask Hide()
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            return UniTask.CompletedTask;
        }
    }
}
