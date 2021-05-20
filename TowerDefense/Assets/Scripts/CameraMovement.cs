using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour{

	float speed = 0.06f;
	float zoomSpeed = 10f;
	float rotationSpeed = 0.1f;

	float maxHeight = 30f;
	float minHeight = 0.1f;

	Vector2 p1;
	Vector2 p2;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        if (GameManager.GameIsOver){
            this.enabled = false;
            return;
        }

    	if(Input.GetKey(KeyCode.LeftShift)){
    		speed = 0.06f;
    		zoomSpeed = 20f;
    	}
    	else{
    		speed = 0.035f;
    		zoomSpeed = 10f;
    	}

    	float hsp = transform.position.y * speed * Input.GetAxis("Horizontal");
    	float vsp = transform.position.y * speed * Input.GetAxis("Vertical");
    	float scrollSp = transform.position.y * -zoomSpeed * Input.GetAxis("Mouse ScrollWheel");

    	if ((transform.position.y >= maxHeight ) && (scrollSp > 0)){
    		scrollSp = 0;
    	}
    	else if ((transform.position.y <= minHeight) && (scrollSp < 0)){
    		scrollSp = 0;
    	}

		if ((transform.position.y + scrollSp) > maxHeight){
			scrollSp = maxHeight - transform.position.y ;
		}
		else if ((transform.position.y + scrollSp) < minHeight){
			scrollSp = minHeight - transform.position.y;
		}


    	Vector3 verticalMove = new Vector3(0, scrollSp, 0);
    	Vector3 lateralMove = hsp * transform.right;
    	Vector3 forwardMove = transform.forward;
    	forwardMove.y = 0;
    	forwardMove.Normalize();
    	forwardMove *= vsp;   

    	Vector3 move = verticalMove + lateralMove + forwardMove;

    	transform.position += move;    

		getCameraRotation(); 
    }

	void getCameraRotation(){
		if (Input.GetMouseButtonDown(2)){
			p1 = Input.mousePosition;
		}

		if(Input.GetMouseButton(2)){
			p2 = Input.mousePosition;

			float dx = (p2-p1).x * rotationSpeed;
			float dy = (p2-p1).y * rotationSpeed;

			transform.rotation *= Quaternion.Euler(new Vector3(0,dx,0));
			transform.GetChild(0).transform.rotation *= Quaternion.Euler(new Vector3(-dy, 0 ,0 ));

			p1 = p2;
		}
	}
}
