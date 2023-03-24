using UnityEngine;
using UnityEngine.UI;

namespace InspireTale.UI
{
    [AddComponentMenu("UI/InspireTale/INSText")]
    public class INSText : Text
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
                base.text = ThaiFontAdjuster.Adjust(value);
            }
        }

        protected string unAdjustedText;

        protected override void OnValidate()
        {
            base.OnValidate();
            this.text = this.m_Text;
        }
    }
}
