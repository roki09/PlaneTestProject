using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Gameplay.Player.Controll
{
    public class PlayerControl : MonoBehaviour
    {

        [SerializeField] private float speed;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] Canvas canvas;
        [SerializeField] private Joystick joystick = null;

        private const string tag = "UiLayerHUD";

        private void OnEnable()
        {
            if (joystick == null)
            {
                GetCanvas();
                CreateJoustick();
            }
        }
        private void Update()
        {
            Move();
        }

        private Vector2 SetDirection()
        {
            var dirX = joystick.Horizontal * speed;
            var dirY = joystick.Vertical * speed;
            return new Vector2(dirX, dirY);
        }

        private void Move()
        {
            rb.velocity = SetDirection();
        }

        private void GetCanvas()
        {
            var go = GameObject.FindGameObjectWithTag(tag);
            canvas = go.GetComponent<Canvas>();
        }

        private void CreateJoustick()
        {
            if (joystick == null)
            {
                var go = Instantiate(Resources.Load<GameObject>("DynamicJoystick"), canvas.transform);
                joystick = go.GetComponent<Joystick>();
            }
        }

    }

}
