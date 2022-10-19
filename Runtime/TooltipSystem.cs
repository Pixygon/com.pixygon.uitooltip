using System;
using UnityEngine;

namespace Pixygon.Tooltip {
    public class TooltipSystem : MonoBehaviour {
        private static TooltipSystem current;
        public Tooltip tooltip;
        public bool isTablet;
        public float multiplier = 1f;

        public static float Multiplier {
            get {
                return current.multiplier;
            }
        }

        private void Start() {
            current = this;
            gameObject.SetActive(false);
        }

        private void OnDestroy() {
            if (current = this)
                current = null;
        }

        public static void Show(Vector2 pos, string content, string header = "", string subheader = "") {
            if (current==null)
                return;
            if(current.isTablet)
                pos = pos * current.multiplier;
            current.tooltip.SetText(pos, content, header, subheader);
            current.tooltip.gameObject.SetActive(true);
        }

        public static void Hide() {
            if (current)
                current.tooltip.gameObject.SetActive(false);
        }
    }
}