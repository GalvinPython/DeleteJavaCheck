# DeleteJavaCheck
**JavaCheck.jar** is a Java file shipped with the Minecraft launcher. This isn't problematic for most, but those that prefer to use newer versions of Java, or mods that are incapable with older versions of Java, can't modify their profiles to use the version that isn't defaulted for that Java version.  
Thankfully, it's easy to bypass this by deleting this file, but is reinstalled after every update, so in the long run, this could be a useful application, especially for those rocking the beta launcher.

# Requirements
This application was written in .NET 6.0. Please ensure you have that installed before running

# Instructions
## Downloading
Download the .zip file found in the latest release, and extract it somewhere memorable. This app will only run with manual execution, so you'll be required to run it after every update.

## Modifying location.txt
Add the directory of where the launcher is installed. Microsoft Store will have their location already in the file, so copy and paste into Line 7, replacing `[USERNAME]` with your name.

## Execution
Run `DeleteJavaCheck.exe`, and if there's no issues, the file should be deleted  
Note: This program won't say what the errors are (I'm working on this), but there are some problems that may occur:
- Having a backslash (\) at the end of the directory listed in location.txt
- Not having admin rights
- Not having the `\game` folder be the target directory
- The file may already be deleted.  

Another thing to note is that this file will most likely be permanently deleted, so remember to run the right version of Java on newer installations

# Future updates
- Improved error handling (1.0.0.3)
- Will scan both launchers automatically, provided that they are in the default location (1.0.1)
  - A text file will be provided to those who have their launcher in another location
