using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Commands : MonoBehaviour, IPointerClickHandler
{
    public int maxCommands;
    private List<CommandItem> _commands = new();
    public GameObject text;
    public GameObject commandList;
    private List<GameObject> commandListItems = new();
    
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        const string CommandButtonTag = "CommandButton";
        var commandButton = eventData.pointerCurrentRaycast.gameObject.transform;
        while (commandButton != null && !commandButton.gameObject.CompareTag(CommandButtonTag))
            commandButton = commandButton.transform.parent;

        if (commandButton != null)
        {
            Debug.Log("Command btn clicked!!!");
            var commandButtonState = commandButton.GetComponent<CommandButton>();

            if (_commands.Count < maxCommands)
            {
                _commands.Add(new CommandItem 
                {
                    Name = commandButtonState.name,
                    Type = commandButtonState.commandType,
                    Move = commandButtonState.move
                });


                var item = Instantiate(text, commandList.transform);
                
                var t = item.GetComponentInChildren<TextMeshPro>();
                // var trans = item.GetComponentInChildren<RectTransform>();
                t.text = commandButtonState.name;
                
                commandListItems.Add(item);
            }
        }
    }

    private class CommandItem
    {
        public string Name { get; set; }
        public CommandType Type { get; set; }
        public Move Move { get; set; }
    }
}
