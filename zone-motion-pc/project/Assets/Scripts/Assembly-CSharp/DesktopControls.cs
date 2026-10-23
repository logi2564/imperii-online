#if UNITY_STANDALONE || UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ZoneMotionPC
{
    // Created automatically, without changing the recovered scene references.
    public sealed class DesktopControls : MonoBehaviour
    {
        private readonly List<RaycastResult> hits = new List<RaycastResult>();
        private bool dragging;
        private bool dragStartedOverUi;
        private Vector3 previousPointer;
        private bool paused;
        private float previousTimeScale;
        private EventSystem pausedEvents;
        private bool previousEventsEnabled;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Install()
        {
            if (Application.isMobilePlatform || FindObjectOfType<DesktopControls>() != null)
                return;
            var root = new GameObject("Desktop controls");
            DontDestroyOnLoad(root);
            root.AddComponent<DesktopControls>();
        }

        private static bool Typing()
        {
            var events = EventSystem.current;
            if (events == null || events.currentSelectedGameObject == null)
                return false;
            var field = events.currentSelectedGameObject.GetComponent<InputField>();
            return field != null && field.isFocused;
        }

        private bool PointerOverControl()
        {
            var events = EventSystem.current;
            if (events == null) return false;
            hits.Clear();
            events.RaycastAll(new PointerEventData(events) { position = Input.mousePosition }, hits);
            foreach (var hit in hits)
                if (hit.gameObject.GetComponentInParent<Selectable>() != null ||
                    hit.gameObject.GetComponentInParent<ScrollRect>() != null)
                    return true;
            return false;
        }

        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F1) || (Input.GetKeyDown(KeyCode.Escape) && !Typing()))
                SetPaused(!paused);
            if (paused || Typing()) return;

            var root = CharacterMotion._CameraCM;
            if (root == null || !root.activeInHierarchy || Data.CharacterD == null ||
                CharacterMotion._curCharacter < 0 ||
                CharacterMotion._curCharacter >= Data.CharacterD.Count ||
                !Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
            {
                dragging = false;
                return;
            }
            var map = root.GetComponentInChildren<Camera>();
            if (map == null || !map.orthographic) return;
            CharacterMotion.coefficientScreen = Mathf.Max(1f, Screen.width / 288f);

            bool overUi = PointerOverControl();
            float wheel = Input.mouseScrollDelta.y;
            if (!overUi && Mathf.Abs(wheel) > 0.001f)
                map.orthographicSize = Mathf.Clamp(map.orthographicSize - wheel * 0.5f, 4f, 7.5f);

            var pointer = Input.mousePosition;
            bool held = Input.GetMouseButton(1) || Input.GetMouseButton(2);
            if (held && !dragging)
            {
                previousPointer = pointer;
                dragStartedOverUi = overUi;
            }
            Vector3 shift = Vector3.zero;
            if (held && !dragStartedOverUi && !overUi)
                shift = (previousPointer - pointer) * (2f * map.orthographicSize / Mathf.Max(1, map.pixelHeight));
            dragging = held;
            previousPointer = pointer;

            Vector3 keys = Vector3.zero;
            if (Input.GetKey(KeyCode.A)) keys.x -= 1f;
            if (Input.GetKey(KeyCode.D)) keys.x += 1f;
            if (Input.GetKey(KeyCode.S)) keys.y -= 1f;
            if (Input.GetKey(KeyCode.W)) keys.y += 1f;
            shift += keys.normalized * map.orthographicSize * Time.unscaledDeltaTime;
            shift.z = 0f;
            if (!Inventory._GGActive && shift.sqrMagnitude > 0f)
            {
                // Use the game's existing map bounds and camera target.
                CharacterMotion.VectorOfSwipe = root.transform.position + shift;
                root.transform.position = CharacterMotion.VectorOfSwipe;
                CharacterMotion.swipe = true;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                var unit = Data.CharacterD[CharacterMotion._curCharacter].CharUnits;
                if (unit != null)
                {
                    root.transform.position = unit.transform.position;
                    CharacterMotion.VectorOfSwipe = root.transform.position;
                    CharacterMotion.swipe = false;
                }
            }
        }

        private void SetPaused(bool value)
        {
            if (paused == value) return;
            paused = value;
            if (value)
            {
                dragging = false;
                previousTimeScale = Time.timeScale;
                Time.timeScale = 0f;
                pausedEvents = EventSystem.current;
                if (pausedEvents != null)
                {
                    previousEventsEnabled = pausedEvents.enabled;
                    pausedEvents.enabled = false;
                }
            }
            else
            {
                Time.timeScale = previousTimeScale;
                if (pausedEvents != null) pausedEvents.enabled = previousEventsEnabled;
                pausedEvents = null;
            }
        }

        private void OnGUI()
        {
            if (!paused) return;
            float width = Mathf.Min(560f, Screen.width - 32f);
            GUI.ModalWindow(747820, new Rect((Screen.width - width) / 2f,
                Mathf.Max(16f, (Screen.height - 270f) / 2f), width, 270f), PauseWindow,
                "Zone Motion PC — пауза");
        }

        private void PauseWindow(int id)
        {
            GUI.Label(new Rect(24f, 38f, 500f, 170f),
                "ЛКМ — выбрать клетку, персонажа или кнопку\n" +
                "ПКМ или средняя кнопка — перетаскивать карту\n" +
                "W A S D — двигать камеру по карте\n" +
                "Колесо мыши — приблизить или отдалить карту\n" +
                "F — вернуть камеру к персонажу\n" +
                "Esc или F1 — пауза и управление");
            if (GUI.Button(new Rect(24f, 218f, 200f, 30f), "Продолжить")) SetPaused(false);
        }

        private void OnDestroy()
        {
            if (paused) SetPaused(false);
        }
    }
}
#endif
