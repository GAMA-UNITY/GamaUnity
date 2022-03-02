# UI Material

## Button Raised

- Button

```
Create_Button_Raised(string prefabName, GameObject parent, string buttonId, Vector3 position, float height, float length, string text, int actionCode, float size, int state)
```

## Checkbox
- Checkbox

```
GameObject Create_Checkbox(string prefabName, GameObject parent, string checkBoxId, Vector3 position, float height, float length, string text_on, string text_off, int actionCode, float size, int state)
```

## Dialogbox
- Dialogbox

```
GameObject Create_DialogBox_Normal(string prefabName, GameObject parent, string dialogBoxId, Vector3 position, float height, float length, string dialog_title, string dialog_content, string yes_text, string no_text, int actionCode, float size, int state)
```

## Divider 
- Divider_Dark

```
GameObject Create_Divider_Dark(string prefabName, GameObject parent, string dividerId, Vector3 position, float height, float width, int size, int state)
```

## Round Button Raised
- Round_Button_Raised

```
Create_Round_Button_Raised("Round_Button_Raised", MainPanel, "buttonRound1", new Vector3(459, -186, 0),10f, 10f, "ihm/I_urbanise_adapte", 14, 1, 1);
```

## Slider with label

- Slider with label

```
GameObject Create_Slider_label_value(string prefabName, GameObject parent, string sliderId, Vector3 position, float heighh, float width, string slider_label, int actionCode, int size, int state)
```

## Switch with label
- Switch with label

```
GameObject Create_Switch(string prefabName, GameObject parent, string switchId, Vector3 position, float height, float width, string switch_text_on, string switch_text_off, int actionCode, int size, int state)
```


## Text

- Text

```
GameObject Create_Text(string prefabName, GameObject parent, string textId, Vector3 position, float height, float width, string text_content, int actionCode, int size, int state)
```


## TextInput

- TextInput
- Le contenu est encoyé à chaque déselection de composant. 
		
```
GameObject Create_TextInput(string prefabName, GameObject parent, string textInputId, Vector3 position, float height, float width, string text_content, int actionCode, int size, int state)
```
