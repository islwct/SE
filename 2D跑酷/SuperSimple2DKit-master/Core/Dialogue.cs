using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*这个脚本将每个对话存储在一个公共字典中。*/

public class Dialogue : MonoBehaviour
{

    public Dictionary<string, string[]> dialogue = new Dictionary<string, string[]>();

    void Start()
    {
        //Door
        dialogue.Add("LockedDoorA", new string[] {
            "Here's a door ",
            "It looks like there's a keyhole!"
        });


        dialogue.Add("LockedDoorB", new string[] {
            "Use your key"
        });

        //NPC
        dialogue.Add("CharacterA", new string[] {
            "Hi!",
            "I'm in the game npcA",
            "I'll give you something nice if you give me 80 gold pieces",
            "Click the left mouse button can release the attack, defeat the enemy can drop gold!！",
            "You can ask me a question",
            "...Like you just did! And I'll just answer your question.",
            "I don't know ha ha ",
            "Go on with your adventure!"
        });

        dialogue.Add("CharacterAChoice1", new string[] {
            "",
            "",
            "Go find the gold coins！",
        });

        dialogue.Add("CharacterAChoice2", new string[] {
            "",
            "",
            "What else can you do?"
        });

        dialogue.Add("CharacterB", new string[] {
            "You did find 80 gold coins!",
            "Thank you for the gold coins",
            "I'm gonna give you a new power!",
            "You can now use a drop attack when you are in the air!"
        });
    }
}
