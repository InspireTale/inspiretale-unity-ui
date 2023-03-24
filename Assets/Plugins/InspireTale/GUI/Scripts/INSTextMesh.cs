using UnityEngine;
using TMPro;

namespace InspireTale.UI
{
    [AddComponentMenu("UI/InspireTale/INSTextMesh")]
    public class INSTextMesh : TextMeshProUGUI
    {
        public override string text
        {
            get
            {
                return this.unAdjustedText;
            }
            set
            {
                this.unAdjustedText = value;
                if (value != null)
                {

                    base.text = ThaiFontAdjuster.Adjust(value);
                }
            }
        }

        protected string unAdjustedText;

        protected override void OnValidate()
        {
            base.OnValidate();
            this.text = this.m_text;
        }
    }
}
