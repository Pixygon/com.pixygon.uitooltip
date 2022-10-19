using UnityEngine;
using UnityEngine.EventSystems;

namespace Pixygon.Tooltip {
    public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
        public string header;
        public string subheader;
        public string content;
        public void OnPointerEnter(PointerEventData eventData) {
            TooltipSystem.Show(transform.position, content, header, subheader);

        }
        public void OnPointerExit(PointerEventData eventData) {
            TooltipSystem.Hide();
        }
        public void SetTooltip(string h = "", string s = "", string c = "") {
            if(!string.IsNullOrEmpty(h))
                header = h;
            if(!string.IsNullOrEmpty(s))
                subheader = s;
            if(!string.IsNullOrEmpty(c))
                content = c;
        }
    }
}