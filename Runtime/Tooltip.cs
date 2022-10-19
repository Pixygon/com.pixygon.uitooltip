using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Pixygon.Tooltip {
    public class Tooltip : MonoBehaviour {
        [FormerlySerializedAs("headerField")] [SerializeField] private TextMeshProUGUI _headerField;
        [FormerlySerializedAs("subheaderField")] [SerializeField] private TextMeshProUGUI _subheaderField;
        [FormerlySerializedAs("contentField")] [SerializeField] private TextMeshProUGUI _contentField;
        [FormerlySerializedAs("layoutElement")] [SerializeField] private LayoutElement _layoutElement;
        [FormerlySerializedAs("characterWrapLimit")] [SerializeField] private int _characterWrapLimit;
        [FormerlySerializedAs("tabletContainer")] [SerializeField] private RectTransform _tabletContainer;
        [SerializeField] private Vector2 _offset;
        
        private RectTransform _rectTransform;
        private bool _isReady;

        private void Start() {
            _rectTransform = GetComponent<RectTransform>();
            _isReady = true;
        }

        public void SetText(Vector2 pos, string content, string header = "", string subheader = "") {
            if (string.IsNullOrEmpty(header)) {
                _headerField.gameObject.SetActive(false);
            }
            else {
                _headerField.gameObject.SetActive(true);
                _headerField.text = header;
            }

            if (string.IsNullOrEmpty(subheader)) {
                _subheaderField.gameObject.SetActive(false);
            }
            else {
                _subheaderField.gameObject.SetActive(true);
                _subheaderField.text = subheader;
            }

            if (string.IsNullOrEmpty(content)) {
                _contentField.gameObject.SetActive(false);
            }
            else {
                _contentField.gameObject.SetActive(true);
                _contentField.text = content;
            }

            var headerLength = _headerField.text.Length;
            var subheaderLength = _subheaderField.text.Length;
            var contentLength = _contentField.text.Length;

            _layoutElement.preferredWidth = (headerLength > _characterWrapLimit || subheaderLength > _characterWrapLimit ||
                                            contentLength > _characterWrapLimit)
                ? 400
                : -1;
        }

        private void LateUpdate() {
            if (!_isReady) return;
            /*
            var pos = GamepadCursor.GetPosition;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(_tabletContainer, pos,
                null,
                out pos);
            //rectTransform.anchoredPosition = (new Vector2((pos.x - Screen.width / 2f) + 15f, (pos.y - Screen.height / 2f) - 15f) * TooltipSystem.Multiplier)+_offset;
            _rectTransform.anchoredPosition = pos + _offset;
            */
            //rectTransform.anchoredPosition = GetMouseCoordsInCanvas(uiCam, false) + _offset;
        }

        private Vector3 GetMouseCoordsInCanvas(Camera cam, bool worldCanvas) {
            if (!worldCanvas) {
                return Input.mousePosition;
            }

            // If the canvas render mode is in World Space,
            // We need to convert the mouse position into this rect coords.
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _tabletContainer, Input.mousePosition, cam, out var mousePosition);
            return mousePosition;
        }
    }
}