extends Node2D


# Called when the node enters the scene tree for the first time.
func _ready():
		pass

func dialog(timeline):
	print(timeline)
	Dialogic.start(timeline)
	get_viewport().set_input_as_handled()
	return 


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

func _on_area_2d_kravon_body_entered(body):
	pass # Replace with function body.
