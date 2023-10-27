extends Node2D


# Called when the node enters the scene tree for the first time.
func _ready():
	var cs = load("res://essential/scenes/gui/UI.cs")
	var csnode = cs.new()
	#Dialogic.signal_event.connect(csnode._on_dialogic_signal)

func dialog(timeline):
	print(timeline)
	Dialogic.start(timeline)
	get_viewport().set_input_as_handled()
	return 
	
func setNecklace():
	Dialogic.VAR.haveFoundEleanorNecklace = "true"
	return
func setBuildStatue():
	Dialogic.VAR.BuildingAStatueComplete = "true"
	return
func setManaAmbriosa():
	Dialogic.VAR.ManaAmbrosiaComplete = "true"
	return
func saveDialogic():
	Dialogic.Save.save("save_slot")
	return
func loadDialogic():
	print("Loaded")
	Dialogic.Save.load("save_slot")
	Dialogic.end_timeline()
 

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass

func _on_area_2d_kravon_body_entered(body):
	pass # Replace with function body.
