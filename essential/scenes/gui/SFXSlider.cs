using Godot;
using System;

public partial class SFXSlider : HSlider
{
	// Called when the node enters the scene tree for the first time.
	private int busIndex;
	public override void _Ready()
	{
		busIndex = AudioServer.GetBusIndex("SFX");	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_value_changed(float value){
		AudioServer.SetBusVolumeDb(busIndex, 20 * Mathf.Log(value));
	}
}
