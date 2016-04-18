using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogHandler : MonoBehaviour {

    public static bool IN_DIALOG = false;
    public static DialogHandler instance = null;

    DialogLine[] dialog;
    DialogPanel dialogPanel;
    Text skipObj;

    int dialogCounter = 0;
    int lineCounter = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        dialogPanel = GetComponent<DialogPanel>();
        skipObj = transform.GetChild(2).GetComponent<Text>();
    }

	// Update is called once per frame
	void Update () {
        // Press Space
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("FireSword")) && IN_DIALOG) {
            if (dialogPanel.Skip()) {
                // text is done: next one!
                NextDialog();
            }
        }

        ShowSkip(!dialogPanel.isTyping() && IN_DIALOG);
	}

    void NextDialog()
    {
        // Fetch the data you need for the first thing
        DialogAudio audio;
        Sprite sprite;
        DialogSprites.instance.getStuff(dialog[dialogCounter].charString, out sprite, out audio);

        // Is there a next line?
        if (lineCounter < dialog[dialogCounter].line.Length) {
            // next line
            dialogPanel.StartTalk(audio, sprite, dialog[dialogCounter].line[lineCounter]);
        }
        else {
            lineCounter = 0;
            dialogCounter++;

            // next dialog
            if (dialogCounter < dialog.Length) {
                // Fetch again
                DialogSprites.instance.getStuff(dialog[dialogCounter].charString, out sprite, out audio);

                // line of the new dialog
                dialogPanel.StartTalk(audio, sprite, dialog[dialogCounter].line[lineCounter]);
            }
            // Dialog over!
            else {
                dialogPanel.ShowPanel(false);
                IN_DIALOG = false;
                Time.timeScale = 1f;
            }
        }

        // enable next line
        lineCounter++;
    }

    void ShowSkip(bool b)
    {
        skipObj.enabled = b;
    }

    public void StartDialog(DialogLine[] d)
    {
        if (IN_DIALOG)
            return;

        dialog = d;
        IN_DIALOG = true;
        Time.timeScale = 0f;
        dialogCounter = 0;
        lineCounter = 0;
        NextDialog();
    }
}

public class DialogLine
{
    public string charString;
    public string[] line;

    public DialogLine(string s, string[] t){
        charString = s;
        line = t;
    }
}

public class Dialogs
{
    public static DialogLine[] firstDialogDuckAndKirby = new DialogLine[]{
        new DialogLine(DialogSprites.sorcererString, new string[]{"Willkommen, kleine Ente!"}),
        new DialogLine(DialogSprites.duckString, new string[]{
            "Sei gegruesst, grosser Entenzauberer. Ich hoffe du hast mich eingeladen, um mir im Kampf gegen das verquackte Brot zu helfen!",
            "Denn ich plane es zu zerschnabeln, bis nur noch Mehlstaub von ihm uebrig ist!",
            "Verwehen wird es in alle Winde, bis sich kein Wesen mehr an es zu erinnern vermag!"}),
        new DialogLine(DialogSprites.sorcererString, new string[]{
            "Ich verstehe deinen Zorn. Auch ich hege einen Groll gegen das Mutterbrot..",
            "und werde dir daher meine unterstuetzende Zauberkraft mit auf den Weg geben. "}),
    };

    public static DialogLine[] secondDialogDuckAndKirby = new DialogLine[]{
        new DialogLine(DialogSprites.sorcererString, new string[]{
            "Mit all meiner Macht vermag ich dir..",
            "die Staerke des Schwertes, die Schnelligkeit des Pfeiles und die Standhaftigkeit des Schildes einzuverleiben."
        }),
    };

    public static DialogLine[] bradPittDialog = new DialogLine[]{
        new DialogLine(DialogSprites.bradString, new string[]{
            "Hi!",
            "Ich bin...",
            "Bread Pitt.",
            "HAHAHA HAHAH AHAHHA AHAHAHAH AAHHAHAHAH HAHAHA HAHAHA HAHAH AHAHHA AHAHAHAH AAHHAHAHAH HAHAHA HAHAHA HAHAH AHAHHA AHAHAHAH AAHHAHAHAH",
            "..."
        })
    };

    public static DialogLine[] breadDialog = new DialogLine[]{
        new DialogLine(DialogSprites.breadString, new string[]{
            "Ente gut, alles gut. The End!"
        })
    };
}