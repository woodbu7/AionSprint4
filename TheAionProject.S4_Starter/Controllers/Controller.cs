using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Traveler _gameTraveler;
        private Universe _gameUniverse;
        private SpaceTimeLocation _currentLocation;
        private bool _playingGame;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gameTraveler = new Traveler();
            _gameUniverse = new Universe();
            _gameConsoleView = new ConsoleView(_gameTraveler, _gameUniverse);
            _playingGame = true;

            //
            // add initial items to the traveler's inventory
            //
            _gameTraveler.Inventory.Add(_gameUniverse.GetGameObjectById(8) as TravelerObject);
            _gameTraveler.Inventory.Add(_gameUniverse.GetGameObjectById(9) as TravelerObject);

            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            TravelerAction travelerActionChoice = TravelerAction.None;
            int npcId = 0;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Mission Intro", Text.MissionIntro(), ActionMenu.MissionIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission traveler
            // 
            InitializeMission();

            //
            // prepare game play screen
            //
            _currentLocation = _gameUniverse.GetSpaceTimeLocationById(_gameTraveler.SpaceTimeLocationID);
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");

            //
            // game loop
            //
            while (_playingGame)
            {
                //
                // process all flags, events, and stats
                //
                UpdateGameStatus();

                //
                // get next game action from player
                //
                travelerActionChoice = GetNextTravelerAction();


                //
                // choose an action based on the player's menu choice
                //
                switch (travelerActionChoice)
                {
                    case TravelerAction.None:
                        break;

                    case TravelerAction.TravelerInfo:
                        _gameConsoleView.DisplayTravelerInfo();
                        break;

                    case TravelerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;

                    case TravelerAction.Travel:
                        TravelAction();
                        break;

                    case TravelerAction.TravelerLocationsVisited:
                        _gameConsoleView.DisplayLocationsVisited();
                        break;

                    case TravelerAction.LookAt:
                        LookAtAction();
                        break;

                    case TravelerAction.PickUp:
                        PickUpAction();
                        break;

                    case TravelerAction.PutDown:
                        PutDownAction();
                        break;

                    case TravelerAction.TalkTo:
                        npcId = TalkToAction();
                        break;

                    case TravelerAction.Inventory:
                        _gameConsoleView.DisplayInventory();
                        break;

                    case TravelerAction.ListSpaceTimeLocations:
                        _gameConsoleView.DisplayListOfSpaceTimeLocations();
                        break;

                    case TravelerAction.ListGameObjects:
                        _gameConsoleView.DisplayListOfAllGameObjects();
                        break;

                    case TravelerAction.ListNonPlayerCharacters:
                        _gameConsoleView.DisplayListOfAllNpcObjects();
                        break;

                    case TravelerAction.AdminMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
                        break;

                    case TravelerAction.ReturnToMainMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;

                    case TravelerAction.TravelerMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.TravelerMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Traveler Menu", "Select an operation from the menu", ActionMenu.TravelerMenu, "");
                        break;

                    case TravelerAction.ObjectMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.ObjectMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Object Menu", "Select an operation from the menu", ActionMenu.ObjectMenu, "");
                        break;

                    case TravelerAction.NonplayerCharacterMenu:
                        _gameConsoleView.DisplayGamePlayScreen("NPC Menu", "Select an operation from the menu", ActionMenu.NpcMenu, "");
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
                        break;

                    case TravelerAction.Fight:
                        AttackAction(npcId);
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                            break;
                    case TravelerAction.EscapeToMainMenu:
                        ctionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;

                    case TravelerAction.Exit:
                        _playingGame = false;
                        break;

                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// display the correct menu/sub-menu and get the next traveler action
        /// </summary>
        /// <returns>traveler action</returns>
        private TravelerAction GetNextTravelerAction()
        {
            TravelerAction travelerActionChoice = TravelerAction.None;

            switch (ActionMenu.currentMenu)
            {
                case ActionMenu.CurrentMenu.MainMenu:
                    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                    break;

                case ActionMenu.CurrentMenu.ObjectMenu:
                    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.ObjectMenu);
                    break;

                case ActionMenu.CurrentMenu.NpcMenu:
                    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.NpcMenu);
                    break;

                case ActionMenu.CurrentMenu.TravelerMenu:
                    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.TravelerMenu);
                    break;

                case ActionMenu.CurrentMenu.AdminMenu:
                    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                    break;

                case ActionMenu.CurrentMenu.AttackMenu:
                    travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AttackMenu);
                    break;

                default:
                    break;
            }

            return travelerActionChoice;
        }

        /// <summary>
        /// process the Travel action
        /// </summary>
        private void TravelAction()
        {
            //
            // get new location choice and update the current location property
            //                        
            _gameTraveler.SpaceTimeLocationID = _gameConsoleView.DisplayGetNextSpaceTimeLocation();
            _currentLocation = _gameUniverse.GetSpaceTimeLocationById(_gameTraveler.SpaceTimeLocationID);

            //
            // display the new space-time location info
            //
            _gameConsoleView.DisplayCurrentLocationInfo();
        }

        /// <summary>
        /// process the Look At action
        /// </summary>
        private void LookAtAction()
        {
            //
            // display a list of game objects in space-time location and get a player choice
            //
            int gameObjectToLookAtId = _gameConsoleView.DisplayGetGameObjectToLookAt();

            //
            // display game object info
            //
            if (gameObjectToLookAtId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(gameObjectToLookAtId);

                //
                // display information for the object chosen
                //
                _gameConsoleView.DisplayGameObjectInfo(gameObject);
            }
        }


        /// <summary>
        /// process the Pick Up action
        /// </summary>
        private void PickUpAction()
        {
            //
            // display a list of traveler objects in space-time location and get a player choice
            //
            int travelerObjectToPickUpId = _gameConsoleView.DisplayGetTravelerObjectToPickUp();

            //
            // add the traveler object to traveler's inventory
            //
            if (travelerObjectToPickUpId != 0)
            {
                //
                // get the game object from the universe
                //
                TravelerObject travelerObject = _gameUniverse.GetGameObjectById(travelerObjectToPickUpId) as TravelerObject;

                //
                // note: traveler object is added to list and the space-time location is set to 0
                //
                _gameTraveler.Inventory.Add(travelerObject);
                travelerObject.SpaceTimeLocationId = 0;

                //
                // display confirmation message
                //
                _gameConsoleView.DisplayConfirmTravelerObjectAddedToInventory(travelerObject);
            }
        }

        /// <summary>
        /// process the Put Down action
        /// </summary>
        private void PutDownAction()
        {
            //
            // display a list of traveler objects in inventory and get a player choice
            //
            int inventoryObjectToPutDownId = _gameConsoleView.DisplayGetInventoryObjectToPutDown();

            //
            // get the game object from the universe
            //
            TravelerObject travelerObject = _gameUniverse.GetGameObjectById(inventoryObjectToPutDownId) as TravelerObject;

            //
            // remove the object from inventory and set the space-time location to the current value
            //
            _gameTraveler.Inventory.Remove(travelerObject);
            travelerObject.SpaceTimeLocationId = _gameTraveler.SpaceTimeLocationID;

            //
            // display confirmation message
            //
            _gameConsoleView.DisplayConfirmTravelerObjectRemovedFromInventory(travelerObject);

        }

        /// <summary>
        /// initialize the player info
        /// </summary>
        private void InitializeMission()
        {
            Traveler traveler = _gameConsoleView.GetInitialTravelerInfo();

            _gameTraveler.Name = traveler.Name;
            _gameTraveler.Age = traveler.Age;
            _gameTraveler.Race = traveler.Race;
            _gameTraveler.SpaceTimeLocationID = 1;

            _gameTraveler.ExperiencePoints = 0;
            _gameTraveler.Health = 100;
            _gameTraveler.Lives = 3;
        }

        /// <summary>
        /// part of the game loop and used to update many elements of the game and game play
        /// </summary>
        private void UpdateGameStatus()
        {
            if (!_gameTraveler.HasVisited(_currentLocation.SpaceTimeLocationID))
            {
                //
                // add new location to the list of visited locations if this is a first visit
                //
                _gameTraveler.SpaceTimeLocationsVisited.Add(_currentLocation.SpaceTimeLocationID);

                //
                // update experience points for visiting locations
                //
                _gameTraveler.ExperiencePoints += _currentLocation.ExperiencePoints;
            }
        }

        private int TalkToAction()
        {
            int enemyId = 0;
            int npcToTalkToId = _gameConsoleView.DisplayGetNpcToTalkTo();

            if (npcToTalkToId != 0)
            {
                Npc npc = _gameUniverse.GetNpcById(npcToTalkToId);
                if (npc is Civilian)
                {
                    Civilian civilian = npc as Civilian;
                    _gameTraveler.ExperiencePoints += civilian.ExperiencePoints;
                    _gameTraveler.Health += civilian.HealthPoints;

                    if (civilian.HasKey)
                    {
                        foreach (SpaceTimeLocation location in _gameUniverse.SpaceTimeLocations)
                        {
                            if (!location.Accessible)
                            {
                                location.Accessible = true;
                            }
                        }
                    }

                    _gameConsoleView.DisplayTalkTo(npc);
                }
                else if (npc is Enemy)
                {
                    Enemy enemy = npc as Enemy;
                    ActionMenu.currentMenu = ActionMenu.CurrentMenu.AttackMenu;
                    _gameConsoleView.DisplayTalkToEnemy(enemy);
                    enemyId = enemy.Id;
                }

                
            }

            return enemyId;
        }

        private void AttackAction(int enemyId)
        {
            bool defeated;

            Npc npc = _gameUniverse.GetNpcById(enemyId);
            if (npc is Enemy)
            {
                Enemy enemy = npc as Enemy;
                if (enemy.PointsNeededToDefeat >= _gameTraveler.ExperiencePoints)
                {
                    defeated = true;
                    _gameTraveler.Lives -= 1;
                }
                else
                {
                    defeated = false;
                    _gameTraveler.ExperiencePoints += enemy.ExperiencePoints;
                }

                _gameConsoleView.DisplayAttack(enemy, defeated);
            }

        }

        #endregion
    }
}
