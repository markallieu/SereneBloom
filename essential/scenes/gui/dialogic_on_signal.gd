extends Node


# Called when the node enters the scene tree for the first time.
var ui
func _ready():
	ui = get_parent()
	Dialogic.signal_event.connect(dialogic_signal)
	pass # Replace with function body.

func dialogic_signal(argument:String):
	ui.call("_on_dialogic_signal",argument)

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
