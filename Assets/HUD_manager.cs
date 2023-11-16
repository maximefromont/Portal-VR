using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class HUD_manager : MonoBehaviour
{
    public Sprite portalGunSprite;
    public Sprite interactionSprite;
    public Sprite TeleportationItemSprite;
    public SpriteRenderer ToolspriteRenderer;
    public Sprite BluePortalSprite;
    public Sprite OrangePortalSprite;
    public SpriteRenderer PortalspriteRenderer;

    private int SelectedTool = 2;
    private int SelectedPortal = 0;



    private InputManager _inputManager;

    private void Awake() => _inputManager = InputManager.Instance;

    void Start()
    {
        ToolspriteRenderer.sprite = interactionSprite;
        PortalspriteRenderer.sprite = null;
    }


    private bool canChangeTool = true;
    private bool canChangePortal = true;
    private float toolChangeCooldown = 0.5f;
    private float portalChangeCooldown = 0.5f;

    void Update()
    {



        //change toolsprite when user slide the touchpad
        if ( _inputManager.TouchPad[0]> 0.5f || Input.GetKeyDown(KeyCode.RightArrow) 
        //detect if the thumbstick is pushed to the right
        //|| Input.GetAxis(thumbstickPosition.x) > 0.5f






        )
        {
            if (canChangeTool)
            {
                //switch case to change the sprite
                switch (SelectedTool)
                {
                    case 0:
                        ToolspriteRenderer.sprite = portalGunSprite;
                        SelectedTool = 1;
                        PortalspriteRenderer.sprite = BluePortalSprite;
                        break;
                    case 1:
                        ToolspriteRenderer.sprite = interactionSprite;
                        PortalspriteRenderer.sprite = null;
                        SelectedTool = 2;
                        break;
                    case 2:
                        ToolspriteRenderer.sprite = TeleportationItemSprite;
                        SelectedTool = 0;
                        break;
                }
                canChangeTool = false;
                Invoke("ResetToolChangeCooldown", toolChangeCooldown);
            }
        }

        //change toolsprite when user slide the touchpad
        if (_inputManager.TouchPad[0] < -0.5f || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (canChangeTool)
            {
                //switch case to change the sprite
                switch (SelectedTool)
                {
                    case 0:
                        ToolspriteRenderer.sprite = interactionSprite;
                        PortalspriteRenderer.sprite = null;
                        SelectedTool = 2;
                        break;
                    case 1:
                        ToolspriteRenderer.sprite = TeleportationItemSprite;
                        SelectedTool = 0;
                        break;
                    case 2:
                        ToolspriteRenderer.sprite = portalGunSprite;
                        SelectedTool = 1;
                        PortalspriteRenderer.sprite = BluePortalSprite;
                        break;
                }
                canChangeTool = false;
                Invoke("ResetToolChangeCooldown", toolChangeCooldown);
            }
        }



        if ((_inputManager.IsPressButton //detect when press enter key 
            ||Input.GetKeyDown(KeyCode.Return)
            ||_inputManager.IsTrigger) && SelectedTool == 1)
        {
            if (canChangePortal)
            {
                //switch case to change the sprite
                switch (SelectedPortal)
                {
                    case 0:
                        PortalspriteRenderer.sprite = OrangePortalSprite;
                        SelectedPortal = 1;
                        break;
                    case 1:
                        PortalspriteRenderer.sprite = BluePortalSprite;
                        SelectedPortal = 0;
                        break;
                }
                canChangePortal = false;
                Invoke("ResetPortalChangeCooldown", portalChangeCooldown);
            }
        }
    }

    private void ResetToolChangeCooldown()
    {
        canChangeTool = true;
    }

    private void ResetPortalChangeCooldown()
    {
        canChangePortal = true;
    }
}