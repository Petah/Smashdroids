#pragma strict

private var turnSpeed : float;
var turnAcceleleration : float;
var turnSpeedMax : float;
private var turnSpeedMin : float;
var strafeSpeed : float;
var prefabBullet : Transform;
var shootForce : float;
var thrust : float = 0.1;
private var tilt : float = 0;

function Start () {
	turnSpeedMin = turnSpeedMax * -1;
}

function FixedUpdate () {
	var left : boolean = Input.GetKey("left");
	var right : boolean = Input.GetKey("right");
	var turnRevert : boolean;
	if (left && right) {
		turnRevert = true;
	} else if (left) {
		turnRevert = false;
		turnSpeed += turnAcceleleration;
		if (turnSpeed < 0) {
		    turnSpeed = 0;
		}
	} else if (right) {
		turnRevert = false;
		turnSpeed -= turnAcceleleration;
		if (turnSpeed > 0) {
		    turnSpeed = 0;
		}
	} else {
		turnRevert = true;
	}
	
	if (turnRevert) {
		if (tilt > 0) {
			tilt -= turnAcceleleration;
		} else if (tilt < 0) {
			tilt += turnAcceleleration;
		}
		turnSpeed *= 0.5;
	} else {
		turnSpeed = Mathf.Clamp(turnSpeed, turnSpeedMin, turnSpeedMax);
		tilt = Mathf.Clamp(tilt + turnSpeed, turnSpeedMin, turnSpeedMax);
	}
	if (Mathf.Abs(tilt) < 0.01) {
		tilt = 0;
	}
	this.transform.rotation = Quaternion.Euler(-90 + (-200 * tilt), 90, -90);
	
	
	if (Input.GetKey(KeyCode.Space)) {
		var instanceBullet = Instantiate(prefabBullet, transform.position, Quaternion.identity);
		instanceBullet.rigidbody.AddForce(Vector3.forward * shootForce);
	}
	
	this.transform.position.z += thrust;
	this.transform.position.x -= tilt * strafeSpeed;
}
