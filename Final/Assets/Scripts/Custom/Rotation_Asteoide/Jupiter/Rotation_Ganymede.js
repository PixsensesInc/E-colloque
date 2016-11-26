#pragma strict

function Start () {
}

function Update () {
	transform.Rotate(0,0,1.5 * Time.deltaTime);
}