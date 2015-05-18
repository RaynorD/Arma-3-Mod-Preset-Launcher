# Arma 3 Mod Preset Launcher
An intuitive, fully featured launcher for Arma 3

**Changelog**

v1.2.3 - In development
- Added: -malloc parameter (lists any dlls in Arma 3/Dlls)
- Added: -name parameter (Select profile)
- Added: Option to run Battleye (On by default, Fixes "battleye is not running" issue)
- Removed: Option to run via command to steam client, as it no longer works
- Fixed: Listviews now handle horizontal resizing better
- Fixed: Adjusted wording of some tooltips to be clearer
- Changed: List views no longer show full path of modfolders (An item's full path can be viewed by holding the mouse over that item)

v1.2.2 - 2014-10-26
- Added: Now searches one level down for modfolders in folders (Arma 3\@Mods\@JSRS), so you can declutter your Arma directory (Note: top folder must start with @)
- Added: Alternate mod locations: mods can now be loaded from other locations, like other drives. (infinite number of locations)
	* Note: Because I didn't design the program to do this from the beginning, it will show the full path in the list views when using the above features, so I suggest very short paths like: Arma 3\@Mods\(mods) or F:\Arma3\(mods) if on a separate drive
- Added: Option to run Arma3.exe directly, in case of Steam issues (shortcuts also save with this option) (NOTE: This is not intended to, and does not, allow pirated games to be launched)
- Added: Options menu with the above features
- Added: Will now remember previously active preset
- Added: Explanatory tooltips for all the parameters
- Fixed: Can now only have one instance open at once
- Removed some unused references and resources
- Updated help dialogs

v1.2.1 - 2014-02-26
- Added: -window, -noLogs, -noFilePatching parameters
- Added: Launcher action on game launch (nothing, minimize, or close)
- Added: Horizontal resizing for both dialogs 
- Added: Launcher position and sizes are now saved (intelligently checks and resets if off screen, in case resolution changed etc.)
- Added: Gray hightlight in the mod list if mod is in current preset
- Added: Red hightlight for mods in the active preset but not in the A3 directory (deleted/name changed), and warning in status bar
- Added: Relevant mod coloring for groups dialog (gray and red)
- Added: Shiny new About and Usage dialogs
- Fixed: Possible crash when creating new group
- Fixed: Modfolders with spaces in their name no longer break the command line
- Fixed: Drive letter is now capitalized (didn't cause problems, just bugged me)
- Fixed: Lots of semi-edge case fixes/improvements

v1.1 - 2014-02-14
- Implemented groups: Basically sub-presets. See Help > Usage for details
- Now installed using the standard windows installer, instead of ClickOnce. The executable will now be stored in program files like every other normal program.
- Added -exThreads parameter
- Both main and group dialogs can be vertically resized
- Minor UI fixes and squashed bugs
- v1.1.1: Load order tweak - if a mod that's already part of an active group is manually added somewhere else in the current preset, it will load there instead of as part of the group.
- v1.1.2: Hotfix for crash when deleting all mods from a preset. Also fixed a bug in highlighting mods.

v1.0 - 2014-02-03 - Initial Release
