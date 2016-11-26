#pragma strict

function Start () {
}

function Update () {
	transform.Rotate(0,0,3.9 * Time.deltaTime);
}