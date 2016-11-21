#pragma strict

function Start () {
}

function Update () {
	transform.Rotate(0,0,0.33 * Time.deltaTime);
}