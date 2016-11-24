#pragma strict

function Start () {
}

function Update () {
	transform.Rotate(0,0,0.9 * Time.deltaTime);
}