#pragma strict

var target : Transform;
var xDistance : float;
var yDistance : float;
var zDistance : float;

function Start () {
}

function Update () {
    transform.position.x = target.position.x - xDistance;
    transform.position.y = target.position.y - yDistance;
	transform.position.z = target.position.z - zDistance;
}
