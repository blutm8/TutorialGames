using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text text;
    
    private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1,
                         lock_1, corridor_0, stairs_0, floor, closet_door, corridor_1,
                         stairs_1, in_closet, stairs_2, corridor_2, corridor_3, courtyard};
	private States myState;

    void Start ()
    {
		myState = States.cell;
	}
	
	void Update ()
    {
		print (myState);
		if      (myState == States.cell)        {state_cell ();} 
		else if (myState == States.sheets_0)    {state_sheets_0 ();}
        else if (myState == States.lock_0)      {state_lock_0();}
        else if (myState == States.mirror)      {state_mirror();}
        else if (myState == States.cell_mirror) {state_cell_mirror();}
        else if (myState == States.sheets_1)    {state_sheets_1();}
        else if (myState == States.lock_1)      {state_lock_1();}
        else if (myState == States.corridor_0)  {state_corridor_0();}
        else if (myState == States.closet_door) {state_closet_door();}
        else if (myState == States.floor)       {state_floor();}
        else if (myState == States.stairs_0)    {state_stairs_0();}
        else if (myState == States.corridor_1)  {state_corridor_1();}
        else if (myState == States.stairs_1)    {state_stairs_1();}
        else if (myState == States.in_closet)   {state_in_closet();}
        else if (myState == States.corridor_2)  {state_corridor_2();}
        else if (myState == States.stairs_2)    {state_stairs_2();}
        else if (myState == States.corridor_3)  {state_corridor_3();}
        else if (myState == States.courtyard)   {state_courtyard();}
	}

    #region States Handler

    void state_cell ()
    {
        text.text = "You are in a prison cell, and you want to escape. There are " +
                    "some dirty sheets on the bed, a mirror on the wall, and the door " +
                    "is locked from the outside.\n\n" +
                    "Press S to view Sheets, M to view Mirror and L to view Lock";

        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.sheets_0;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.lock_0;
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            myState = States.mirror;
        }
    }
    void state_sheets_0()
    {
        text.text = "You can't believe you sleep in these things. Surely it's " +
                    "time somebody changed them. The pleasures of prison life " +
                    "I guess!\n\n" +
                    "Press R to Return to roaming your cell";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell;
        }
    }
    void state_lock_0()
    {
        text.text = "This is one of those button locks. You have no idea what the " +
                    "combination is. You wish you could somehow see where the dirty " +
                    "fingerprints were, maybe that would help.\n\n" +
                    "Press R to Return to roaming your cell";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell;
        }
    }
    void state_mirror ()
    {
        text.text = "The dirty old mirror on the wall seems loose.\n\n" + 
                    "Press T to take the mirror or R to Return to roaming your cell";
        if(Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            myState = States.cell_mirror;
        }
    }
    void state_cell_mirror ()
    {
        text.text = "You are still in your cell, and you STILL want to escape! There are " +
                    "some dirty sheets on the bed, a mark where the mirror was, " +
                    "and that pesky door is still there, and firmly locked!\n\n" +
                    "Press S to view Sheets, or L to view Lock";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.sheets_1;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.lock_1;
        }
    }
    void state_sheets_1()
    {
        text.text = "Holding a mirror in your hand doesn't make the sheets look " +
                    "any better.\n\n" +
                    "Press R to Return to roaming your cell";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell_mirror;
        }
    }
    void state_lock_1()
    {
        text.text = "You carefully put the mirror through the bars, and turn it round " +
                    "so you can see the lock. You can just make out fingerprints around " +
                    "the buttons. You press the dirty buttons, and hear a click.\n\n" +
                    "Press O to Open, or R to Return to your cell";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell_mirror;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            myState = States.corridor_0;
        }
    }
    void state_corridor_0()
    {
        text.text = "You made it, you are FREE! At least out of the cell. You are now in a corridor and the only thing you see are more cell doors. " +
                    "Standing in the corridor won't help you, especially when the guard comes back on her patrolling. You need to hurry! " +
                    "Hasty you look around and see stairs, a closet and something shimmering on the floor.\n\n" +
                    "Press S to go to the stairs, or C to inspect the closet, or F to inspect the floor";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.stairs_0;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            myState = States.closet_door;
        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            myState = States.floor;
        }   
    }
    void state_stairs_0()
    {
        text.text = "The stairs only lead down. That's a problem because you will definitely run into the guard. You need a disguise first.\n\n" +
                    "Press R to turn back.";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.corridor_0;
        }
    }
    void state_closet_door()
    {
        text.text = "You walk up to the closet. As you try to open the closet door you notice it's locked. You need something to pry it open or lockpick it.\n\n" +
                    "Press R to turn back.";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.corridor_0;
        }
    }
    void state_floor()
    {
        text.text = "As you walk up to the shimmering object you see a hairpin laying on the ground.\n\n" +
                    "Press H to take the hairpin, or press R to turn back";
        if (Input.GetKeyDown(KeyCode.H))
        {
            myState = States.corridor_1;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.corridor_0;
        }
    }
    void state_corridor_1()
    {
        text.text = "With a hairpin in your hand you still stand in the corridor and the guard may appear any moment. Again you think about running down the stairs. " +
                    "But still it's too dangerous... there must be another way out of here.\n\n" +
                    "Press S to go to the stairs, or C to inspect the closet";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.stairs_1;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            myState = States.in_closet;
        }
    }
    void state_stairs_1()
    {
        text.text = "Nothing changed so far. Still not sure what's waiting for you down there except the patrolling guard\n\n" +
                    "Press R to turn back";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.corridor_1;
        }
    }
    void state_in_closet()
    {
        text.text = "Using the hairpin you found you try to lockpick the door. After a moment of fiddeling around you manage to unlock the closet. " +
                    "As you open the door you see various items: Rags, broom, boxes, clothes.\n\n" +
                    "Press C to take the clothes, or press R to turn back";
        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.corridor_2;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            myState = States.corridor_3;
        }
    }
    void state_corridor_2()
    {
        text.text = "There you are, out of ideas. The only thing you can do now is to run down the stairs.\n\n" +
                    "Press S to run down the stairs, or press R to go back to the closet";
        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.stairs_2;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.in_closet;
        }
    }
    void state_stairs_2()
    {
        text.text = "You are out of time and start rushing to the stairs. Unfortunately the guard is walking up the stairs to finish her patrol route. As she noticed the ruckus upstairs she yells " +
                    "in her walkietalkie for backup and starts running. When she faces you she draws her taser and shoots a load of 10.000V into you. As you are jerking on the ground you realise that your attempt to escape stops here and that your time has come...\n\n" +
                    "Press N to start a new game";
        if (Input.GetKeyDown(KeyCode.N))
        {
            Start();
        }

    }
    void state_corridor_3()
    {
        text.text = "You put on the overall which has the name tag 'Janitor'. Now you have a disguise and can escape.\n\n" +
                    "Press W to walk down the stairs, or C to start cleaning";
        if (Input.GetKeyDown(KeyCode.W))
        {
            myState = States.stairs_2;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            myState = States.courtyard;
        }
    }
    void state_courtyard()
    {
        text.text = "You take the broom out of the closet and close the door. Just when you started to clean the floor, the guard comes around the corner from upstairs and looks at you. For a moment she stares at you, clearly wondering who you are. " +
                    "Than she makes a face like she remembers something and greets you. She walks up to you and says 'Hey, you are early today.'. Not waiting for an answer she passes you, look around and turns back to moving to the stairs." +
                    "After a moment she disappears downstairs again. That's the moment when you put back the broom and follow her downstairs. Fortunately no one seems to mind you when you head through the complex to the exit." +
                    "You made it, you are finally FREE!";
    }
    #endregion
}
