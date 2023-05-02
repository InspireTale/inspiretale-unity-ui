using Cysharp.Threading.Tasks;
using UnityEngine;

namespace InspireTale.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class BaseGUICanvas : MonoBehaviour
    {
        [SerializeField]
        protected bool isBlockRaycast;

        protected CanvasGroup canvasGroup;

        protected GameObject[] childrenList;

        protected virtual void Awake()
        {
            this.canvasGroup = GetComponent<CanvasGroup>();
            this.childrenList = new GameObject[this.transform.childCount];
            for(int i =0; i<this.transform.childCount; i++)
            {
                Transform child = this.transform.GetChild(i);
                childrenList[i] = child.gameObject;
            }
        }

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
