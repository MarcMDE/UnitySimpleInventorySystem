# Unity Simple Inventory System

## Author
* Marc Montagut Llauradó
* marcmde95@gmail.com

## Details
* Unity version: 2021.3.7f1 (LTS).
* Development time: ~10 hours.

## UI
* TOP bar: Add items and increase time counter.
* Inventory panel (right-bottom corner): Inventory UI showing the items stored in the inventory and allowing to interact with them.
* Each inventory panel slot shows the items monetary/gold value (yellow color), weight (white) and duration (purple). 

## UI Controls
* MouseLeftClick - Add item or increase time (top buttons) or activate an item in the inventory (if possible).
* MouseRightClick - Sell an item in the inventory (if possible).
* MouseMiddleClick - Drop (remove) an item in the inventory. 
* Mouse hover - Show the details of an item in the inventory.
* I - Show/Hide inventory.

## Implementation details
* The inventory slots are created when the game starts, the number of slots (and max weight) can be changed from the _Inventory_ script attached to the _Player_ object. 
* The game items _Item_ (scriptable objects) can be created using the _Create/Items_ menu option in the project tab. 
* The inventory UI and Actions managers (sell, drop, activate) point to the _Inventory_ system. 
* Once a game _Item_ is stored in the _Inventory_, it is encapsulated in a _InventoryItem_ which contains the duration and value.
* Despite that not every item needs a duration and a value, I decided to implement it as virtual methods to avoid the excessive types parsing.  

## Unity Project relevant folders under /Assets
/Items: Game items definition.


/Scripts: The developed scripts.

## Note that...
* I started the project with an older Unity version, and some of the UI elements are not using the "new" TextMesh UI elements. 
* The controls UI elements have been implemented in a quicker and least ideal way than the rest of the project elements, since their only prupose is to test the inventory system.
