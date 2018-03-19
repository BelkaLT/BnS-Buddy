▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
▀▄▀▄                                             Endless                                              ▄▀▄▀
░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒
▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓


Disclaimer: 
+If game is rendered unstartable, you are the only one responsible. Therefore using this tool, you agree to the "risks".

> You can always use the Original NCSoft Launcher to restore files to Original and start the game


Credits:
+ Miyako - Inspired by his/her BnS-Ark Tool!
+ Endless aka Kogaru - Recoded from scratch and improved!
+ ronny1982 - For bnsdat tool 
+ LokiReborn - For porting bnsdat to C# and token generation


Requirements:
+ .Net Framework 4.5 (not client profile)
+ MetroFramework.dll (included in download)

> A brain.


Change Log:

Version 5.8.9.5
+ Added: Popup for missing MetroFramework.dll file
+ Added: Auto-resize for email in login form
+ Added: Single-Instance only check
+ Added: Disabled auto-login by default if MultiClient is turned on
+ Added: 5 Seconds delay between clicks for refresh of user count to prevent spam and hang
+ Reworked: Changed the forget button to an X
+ Reworked: Fetching on AppStart would hang form for a couple of seconds
+ Fixed Bug: Changing remember me on login form would not sync with settings tab
+ Fixed Bug: Changed ip for TW server due to inaccurate ping
+ Fixed Bug: Fetching while having a slow connection to end-point for user online count would freeze the form
+ Fixed Bug: Unsecurely Fetched the user online count
+ Fixed Bug: Having Selected Japanese server would switch back to NA/EU if it was installed
+ Fixed Bug: Tooltip for Custom Client Name would be wrong
+ Fixed Bug: When BnS Buddy would be offline, it would try to fetch the count and have an overlapping html code
+ Fixed Bug: Wanting to login would wipe constantly the registry of the credentials [needs testing]
+ Fixed Bug: After wiping credential would cause crash

Version 5.8.9.4
+ Added: Timer to say if connection is being slow during login
+ Added: Custom exe name for Client
+ Added: User count online
+ Added: Color dropdown for BnS Buddy's design
+ Added: Portuguese support
+ Added: Sorting to Addons
+ Added: Sorting to Splashes
+ Added: Remember last used server
+ Added: Preview Button in Splash Changer
+ Added: Context Menu to BnS Buddy Notification Icon When Minimized
+ Reworked: Ping method for na/eu
+ Reworked: Mod manager now moves mods to subfolders for better organisation
+ Reworked: Multiple Game Installation Resetting
+ Reworked: Changing Server would load different installed paths
+ Reworked: Changed addons location
+ Reworked: Repositioned the Bitness selection for the game Client & Changed the Default Path configuration
+ Reworked: Bitness selection for addons is automatically selected along with the bitness selected of the current client
+ Fixed Bug: Matching prefix for emails before @ would create duplicate entries of the same name
+ Fixed Bug: Sometimes pressing tooltip on xml edit tab would not work
+ Fixed Bug: Did not allow login after maintenance is over on same session
+ Fixed Bug: Would not load korean paths
+ Fixed Bug: Custom mod path would not have backup path following
+ Fixed Bug: Creating random /mod folders on root drive
+ Fixed Bug: Restore button in settings didn't do anything
+ Fixed Bug: Maximize/Minimize button went batshit crazy and didn't follow his orders when resizing form
+ Fixed Bug: Remember Me did not toggle unless you signed in on login form
+ Fixed Bug: Emails starting with the same name will be overwritten on registry
+ Fixed Bug: Cleaning Mess when exiting, starting game and opening BnS Buddy would not clean
+ Fixed Bug: Removed the excessive flickering when BnS Buddy Refreshed the Mod Manager list
+ Fixed Bug: Fixed tooltips still appear after pressing compile/decompile
+ Fixed Bug: Disabled the compile/decompile when game is running which resulted in a permanent freeze
+ Fixed Bug: Pressing Compile button on dat editor when not decompiled would crash/freeze BnS Buddy
+ Fixed Bug: Applying a mod in mod manager while folder is empty and none other selected would freeze BnS Buddy
+ Fixed Bug: Splash Preview within BnS Buddy wasn't respecting image ratio
+ Fixed Bug: Buddy would not be killed if closed via taskbar
+ Fixed Bug: Status for clean or patched files would always stay patched if was previous true

Version 5.8.9.3
+ Reworked: Mod manager handling
+ Fixed Bug: Auto-login wouldn't let you connect to second account
+ Fixed Bug: Would not load korean paths (workaround)
+ Fixed Bug: Unknown error caused by unique fingerprint
+ Fixed Bug: Killing an unexisting process
+ Fixed Bug: Mod Manager renaming mod folders when not finished transferring
+ Fixed Bug: Keeping old updater not allowing to update
+ Fixed Bug: Loop of applying fix loading screen when files already pre-existed
+ Fixed Bug: Icmp servers from ncsoft would be unpingable, now pinging servers directly
+ Fixed Bug: Modifying cleanint and prtime if previously matching would modify both at the same time
 
Version 5.8.9.2
+ Added: Auto-login
+ Added: Logs during login process to make the login more understandable
+ Reworked: Client killer saves the last used client process id
+ Fixed Bug: Restoring/Reapplying loading screen fix was checked when not and did the opposite
+ Fixed Bug: When no server are available, unhandled exception occurs and crashes
+ Fixed Bug: When one account fails to login all other sessions closes
+ Fixed Bug: When decompiling a multiple folder mod via addon
 
Version 5.8.9.1
+ Reworked: Give access by default to MultiClient on Extra tab 
+ Fixed Bug: Was allowing twice the same acc login at the same time
+ Fixed Bug: Adding non-patch files to the list
+ Fixed Bug: Loading screen bug caused by bns buddy
+ Fixed Bug: Memory cleaner was intrusive to game process in it's cleaning
+ Fixed Bug: Could not show IGP estimation if GCD estimation wasn't on
+ Fixed Bug: When no process are listed as running, tried to set to an unexisting process 

Version 5.8.9.0
+ Added: Start 2nd instance of game Client with multiclient
+ Added: Remember unique key
+ Added: Forget account in Login Form For selected one
+ Added: Support for umap files in Mod Manager
+ Added: Toggles for GCD and INGAME estimations
+ Reworked: Extra tab for 'hidden' features was incomplete
+ Reworked: Relocated Memory cleaner when game starts
+ Fixed Bug: Could not enter custom patch name when creating addon
+ Fixed Bug: The colors for Launcher tab
+ Fixed Bug: Removed "Could not Start Client.exe!" even after it started
+ Fixed Bug: Could not kill Client (Access Denied even with admin rights) globally called Client
+ Fixed Bug: Forgot to add Korean Test Server support Paths
+ Fixed Bug: Error decrypting key via registry for login
+ Fixed Bug: Couldn't properly choose for Live or Test server
+ Fixed Bug: White clickable lines appeared in about tab

Version 5.8.8.6
+ Added: Signature check
+ Added: Server validation to fetch online build number
+ Added: Estimated GCD time response
+ Added: Estimated InGame time response
+ Added: Korean Test Server Registry Path
+ Reworked: Completely reworked Fix Loading Screen & Backup check for it
+ Fixed Bug: Trying to login when maintenance was occuring lead to error
+ Fixed Bug: Korean Test server appid was replaced with proper one
+ Fixed Bug: Login form would error out if Registry could not be read
+ Fixed Bug: Color wether ping was good or not was not changing
+ Fixed Bug: Password would take more than 16 characters wich prevents users to login if password was originally longer than 16 chars
+ Fixed Bug: Tab selector would go out of bounds for too many items
+ Fixed Bug: Pinging wrong adress for na
+ Fixed Bug: Signature of BnS Buddy re-added due to a dependency build issue

Version 5.8.8.5
+ Added: Maintenance Check(handler)
+ Added: Korean Test server option
+ Added: Interval(repeat) for autoclean
+ Rework: Fix Loading Screen now properly removes even if one of them is missing, same for restoring
+ Fixed Bug: Mod Manager tab buttons not working after game killed/closed
+ Fixed Bug: Boost Process would not auto start
+ Fixed Bug: Memory Cleaner would not auto clean

Version 5.8.8.0
+ Removed: Forgot a popup while updating settings.ini
+ Fixed Bug: Setting Custom Mod Folder Would be blank in settings.ini 

Version 5.8.7.9
+ Added: Priority boost when focusing BnS Game Process
+ Removed: Removed the popups after updating Buddy for changes made to settings.ini
+ Fixed Bug: Starting BnS Buddy with game killer check on would prevent it from working

Version 5.8.7.7
+ Fixed Bug: Refreshing addons would only remove 1-2 from the list instead of all modified items

Version 5.8.7.6
+ Reworked: Applying addons now has option for bitness
+ Fixed Bug: Fix Server Selection for NA/EU resulting an unhandled exception

Version 5.8.7.5
+ Fixed Bug: Check settings.ini if updated was broken due to invalid settings name
+ Fixed Bug: Collision with MXM(Add an extra check for mxm registry and in NCLauncher.ini)
+ Fixed Bug: Addons would still compile a multiple pattern patch
+ Fixed Bug: Not being connected to the internet would prevent buddy from attempting to sign in again(play button grayed out)

Version 5.8.7.4
+ Added: Create addon function
+ Added: Login for Taiwan and Korean now supported
+ Added: Warning when restoring files in dat editor
+ Added: Remember me function for language path used if multiple
+ Removed: Backup feature for addons
+ Reworked: Restore button in launcher tab edits and restores the option to default
+ Reworked: Undo Selected Addon instead of restore files
+ Reworked: Recompile addons that mods were applied to (and reverting)
+ Reworked: Cleaning of the editing folder used by buddy replacing new files with old ones
+ Fixed Bug: When not choosing a language would ask for path instead and loop
+ Fixed Bug: Bad path formats would lead to user documents
+ Fixed Bug: Wrong arguments for other clients
+ Fixed Bug: Don't proceed unpacking if file does not exist(if tamepered)
+ Fixed Bug: Don't proceed patching an unexisting file within config files
+ Fixed Bug: Annoying popup that says what language you selected
+ Fixed Bug: French localisation server automatic selecter
+ Fixed Bug: Registry subkey did not exist thus causing errors when memorizing user credentials

Version 5.8.7.3
+ Fixed Bug: Compiling the same xml multiple times
+ Fixed Bug: Remember last signed in user
+ Fixed Bug: Untick addons after done patching/compiling
+ Fixed Bug: Closing Login form returns to Buddy
+ Fixed Bug: Restore in launcher tab not finding path if backup did not exist
+ Fixed Bug: Login Form won't remember previous entered login if a second user was forgotten


Version 5.8.7.2
+ Fixed Bug: Description Text for Addons overflowed out of app.
+ Fixed Bug: Users not remembered caused by old version of buddy
+ Fixed Bug: Files not clearing upon exit in login form
+ Fixed Bug: Addons tab not working(not decompiling or compiling)
+ Fixed Bug: Server setting not recognized when reading nclauncher.ini
+ Fixed Bug: Addons Triggered without wanting it to

Version 5.8.7.1
+ Added: Auto Memory Cleaner at game start and Memory Cleaner Button
+ Added: Multiple Account Remember me
+ Fixed Bug: Packet Buffer empty due to lost connection crashes BnS Buddy
+ Fixed Bug: Restoring addons automatically on startup prevented users to open game
+ Fixed Bug: Backup and restore for addons weren't implemented properly
+ Fixed Bug: Applying any addons would hang app.
+ Fixed Bug: Fixed popup in Login form weren't proper style
+ Fixed Bug: Password encryption weren't enough suffisticated 
+ Fixed Bug: Ok button on help window for login wasn't positioned properly

Version 5.8.7 (TESTING PHASE)
+ Server: Unblocked all countries that could not download BnS Buddy, online version check and updater 
+ Added: Custom paths for mods (General use) 
+ Added: Automatic restore of config/config64 if modded to skip error at client start 
+ Added: Game Process Killer after started 
+ Added: Addons (Patches the mods you want automatically after every launch) 
+ Added: Routines to determine wich Lang path you are actually using if multiple are found 
+ Added: Process Priority dropdown in settings page 3 
+ Added: Japan Support 
+ Added: Korean Support 
+ Fixed Bug: Kept asking wich client version you wanted to run if the paths were found by default at start
+ Fixed Bug: The first ping is now in background worker instead of main thread, preventing freeze at start
+ Fixed Bug: When game won't start and dies. A popup will ask to verify your ip.
+ Fixed Bug: Forms in tabs won't fit and goes out of bounds
+ Fixed Bug: Form won't change when tab is changed
+ Reworked: Changed ip to check your game ping correctly (na & eu)
+ Reworked: Login Form

Version 5.8.5
+ Fixed Bug: Setted Default Client wouldn't switch back to 32bit

Version 5.8
+ Removed: Static paths to Language
+ Removed: Static paths to Client.exe
+ Added: Recursive check for Language
+ Added: Recursive check for Client.exe (32bit & 64Bit)
+ Added: Option to change from 32bit to 64bit in settings
+ Added: Saving of Client choice as default launcher
+ Reworked: Using of path to Client.exe

> You can now change the default client in settings page 2

Version 5.7
+ Removed: Integrated Updater
+ Added: External Updater/Downloader
+ Reworked: Settings.ini handling not overwriting current settings after update
+ Reworked: Change Text in Settings for easier understanding of wich is wich of Client/Game paths

> You can now use the Updater-Downloader to download BnS Buddy

Version 5.6
+ Removed: Static checks for Server/Lang
+ Removed: bnsdat tool (.exe) from project
+ Added: Support for 64bit Client and Config files
+ Added: Recursive checks for Server/Lang
+ Added Selector to choose default installation
+ Added: Default installation path if user has multiple BnS installed
+ Added: integrated functions to extract/compile .dat files
+ Fixed Bug: Wrong window sizes causes items to go out-of-bounds
+ Fixed Bug: Fix crashing of Tool when .dat is already decompiled
+ Fixed Bug: Fix crashing issues at startup due to lack of catches and nulled arguements being called 
+ Fixed bug: Fix button not being able to restore after first patch
+ Reworked: Every Popups to use the theme
+ Reworked: Dat handling to support 64 and 32

Version 5.5
+ Removed: Useless message box when saving xml in dat editor
+ Added: catches for [un/re]packing dat files during startup for debugging
+ Rework: Automatic Updater
+ Rework: Catching the exited popup to avoid crash
+ Fixed Bug: Crash caused by bnsdat at start in CheckConfigBackup
+ Fixed Bug: Saving custom client path would read as gamepath instead
+ Fixed Bug: Tab would start in different location than stated
+ Reworked every closing function for the app

Version 5.4
+ Removed: Custom .dat files from Dat Editor
+ Removed: Presetted .dat files from combobox in Dat Editor
+ Added: Recursive dat files adder and finder in Dat Editor
+ Added: First time use setting
+ Added: Taiwan server support
+ Reworked: Finding game path and setting path values, now recursive
+ Reworked: Dat Editors functions, fully recursive
+ Reworked: Recursive cleanup after restarting tool and after usage
+ Reworked: Restoring modded config files recursively
+ Fixed Bug: Tools boxes goes out of bound when switching tabs
+ Fixed Bug: Saving custom paths in settings adds itself in settings.ini multiple times even if it exists
+ Fixed Bug: Reading custom paths in settings returns the function used instead of actual value
+ Fixed Bug: When Update Check is "off" the status check in launcher tab overlaps the Box on the right
+ Fixed Bug: Admin check function wasnt being called by proper method
+ Fixed Bug: Closing the pop-up for choosing directory of game or launcher would crash the app
+ Fixed Bug: Topmost bug, form stays ontop of everything

> Donation: Added lovely community members

Version 5.3
+ Added: New updater(updates by itself)
+ Added: Option to turn off auto-updater
+ Fixed Bug: minimizing to tray not working
+ Fixed Bug: installing a mod in Mod Manager when the file is unique cant be uninstalled
+ Fixed Bug: when removing loading screen, one upk may remain if another doesnt exist
+ Fixed Bug: restoring files were only moved if its backup existed in mod manager
+ Fixed Bug: restoring settings to default did not remove variables and wasnt set off
+ Fixed Bug: listbox for splash changer errors out when empty
+ Fixed Bug: error handling when splash changes when empty
+ Fixed Bug: installing/uninstalling would be done all at same time and confuses tool

> Unhid the dll for the tool because people could not see it when the tool needed it to run

- Version 5.2.5
+ Fixed Bug: old required files that are no longer required were preventing tool to launch because they werent deleted before removing that folder

- Version 5.2
+ Fixed Bug: bnsdat.exe preventing tool to launch
+ Fixed Bug: update download would give empty file due to no User Agent
+ Fixed Bug: applying patch in dat editor when file does not exist crashes app
+ Fixed Bug: could only mod one at a time and could not restore using Mod Manager
+ Added: Application loading form
+ Added: Custom input file for Dat Editor 
+ Added: Scroll between values for rate of ping(ms)
+ Added: Kill background workers based on settings(off=kill/on=start)
+ Added: Save trackbar(ms) value to settings.ini automatically
+ Modified: Mod Manager 3.0
+ Modified: About Tab

> Known bugs with Dat editor with custom files not unpacking.

Version 5.1
+ Fixed Bug: Dat Editors size would randomly resize itself smaller
+ Fixed Bug: Weird white boxes in settings tab
+ Added: Save custom arguements

Version 5.0
+ Fixed Bug: List box for Splash Changer had the wrong colors on start
- Removed: Use all available cores arguement from the game start
- Removed: Checking backup of config.dat
+ Added: 32-bit compatibility registry values to find Launcher and Game Paths
+ Added: Automatic config.dat patcher
+ Added: Toggle for using Use All Available Cores Arguement
+ Added: Extra Settings (page 2)

> The 32-bit reg check is untested, plz report any errors

Version 4.6
+ Fixed Bug: Wrong startup default tab
+ Fixed Bug: Maximize button shown upon startup (in wrong tab)

Version 4.5
+ Fixed Bug: No use-agent for getting newest version
+ New Mod Manager (2.0)

> Mod Manager 2.0 is in BETA! Report any errors

Version 4.2
+ Completed Dat Editor(BETA)
+ Fixed Bug: Hanged app caused by Ping running as mainworker and not background
+ Fixed Bug: Config.dat Checks were comparing to original(old), now compares to modded instead
+ Fixed Bug: Pings were resulting in errors and crashing app when offline

> Dat Editor is in BETA stage, may result in errors

Version 4.1
+ Partial Touch-up of the .dat editor
+ Fixed Bug: Settings not properly reverting.
+ Fixed Bug: Check config.dat after updates wasnt properly implemented
+ Fixed Bug: Update causing config.dat being invalid for Client.exe
+ Fixed Bug: Check Tab routine not running because form is not initialized
+ Fixed Bug: Login to NCSoft repeating itself after successful login
+ Fixed Bug: Update Check for tool causing unknown errors when not connecting

> NCSoft login travel time reduced
 
Version 4.0
+ Added proper logs to Mod Manager
+ Added settings tabs
+ Started .dat editor (incomplete)

> Relocated the Settings.ini for the app

Version 3.7
+ Changed App Icon to distinguish between game
+ Added new Donators to the donate tab 

> Did some fixes on the Login to NCSoft, wich will not be published as of yet

Version 3.6
+ Fixed Bug: Splash Changer not putting the selected splash
+ Fixed Bug: Values not written when auto-saved functions where set when last run
+ Fixed Bug: Did not compare config.dat after updates
+ Workaround: Completely reworked mod managers paths and usage(again)
+ Future: Coded an internal login to NCSoft ( for *maybe* a near future )
+ Security: Signed application for windowss trust issues

> To also avoid Strictor triggers i removed the admin flag on app, you have to add run-as admin

Version 3.5
+ Bug Fix: App Window does not properly restore after Client.exe closed 
+ Change the text when Mods folder in mod manager is empty
+ Spinning progress bar not showing in Mod Manager while working
+ Found an alternative method for using the mods in mod manager

> Mod Manager conflicting cross-threading issue fixed

Version 3.4
+ Fixed Bug: Mod & Undo both available in Mod Manager
+ Added Routine to check if game is running or not to restore app
+ Added Donators tab
+ Added ToolTips

> Tooltips available on each button to help understand what they do

Version 3.3
+ Fixed Bug: Conflicting routine for RegionID
+ Reworked: Routines for the checkboxes(unattended & no texture streaming)
+ Fixed Bug: Patch!/Play! button text not changing properly

> Removed Routines when launching game(faster process)

Version 3.2
+ Fixed Bug: Application would hang(tick having too many stages)
+ Fixed Bug: RegionID & LanguageID would share their values
+ Added: Status of settings(showing values before launch)
+ Added: Donation button(for those who appreciate my work) 
+ Reworked the close/minimize buttons at top

> Properly sets RegionID and languageID values.

Version 3.1
+ Fully Redesigned
+ Reworked some routines
+ Tool Draggable
+ Server Usage Detection System
+ Save Last Used Settings

> Fully resonsive design(requires MetroFramework.dll)

Version 3.0
+ Added Splash Screen Changer!
+ Fixed logs appearing double in Mod Manager
+ Reworked the Restore button for config.dat

> Splash screen changer might have bugs, report them right away!

Version 2.7
+ Fixed the focus of the app(always in background)
+ Fixed the statuses in Mod Manager
+ Fixed the No loading screen after an update

> Now properly checks if the backup already exists after an update

Version 2.6
+ Logs in Mod Manager can not be erased.
+ Statuses at bottom of Mod Manager now tells you if your game has modded files or not properly.

> You can still copy the logs

Version 2.5
+ Added Mod Manager

> Added logs to Mod Manager

> Fixed verification of files

> Added settings for json

> Undo/Mod [Rework]

> Added shortcut to Mod Folder

> Added Refresh if mods folder changed

> Beta release for Mod Manager(tested and worked on my computer[NO WARNING WHILE LAUNCHING GAME!])

Version 2.0
+ Killing game process if already running(tool boot crash fix)
+ Grabs path thru registry(installation path)
+ Dialog to find path if path in registry does not exist(installed in another dir)
+ Fixed automatic game language detector(wrong default values fix)

> Added extra logs for more information

Version 1.5
+ Lowered .Net Framework requirements to 3.5 instead of 4.5.2

> For compatibility issues

Version 1.4
+ Fixed Patch!/Play! buttons text
+ Added intergrated version checker!

> You can use the same Download link to download the latest version

Version 1.3
+ Fixed Logs
+ Intergrated config.dat in tool(no longer relies on internet)
+ Tool no longer requires /patch path and config.dat inside of it

> Logs can be paused if you click on it

Version 1.2
+ Added Logs to app

> Tells successes and fails

Version 1.1
+ Patches the config.dat with Miyakos config.dat!
+ Added restore button for config.dat

> Backup kept for restore in /backup/config.dat at the Original config.dats location

Version 1.0
+ Greatly optimized the code compared to BnS-Ark
+ Added Launch! (Start the game)
+ Added Ping (green,orange,red) [red = unplayable | orange = barely playable | green = perfect gameplay]
+ Added Option to select language of game
+ Added Option to select game server based on your country

> No Loading Screen button toggle
