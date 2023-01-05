# DeleteJavaCheck
**JavaCheck.jar** is a Java file shipped with the Minecraft launcher. This isn't problematic for most, but those that prefer to use newer versions of Java, or mods that are incapable with older versions of Java, can't modify their profiles to use the version that isn't defaulted for that Java version.  
Thankfully, it's easy to bypass this by deleting this file, but is reinstalled after every update, so in the long run, this could be a useful application, especially for those rocking the beta launcher.  
For those curious, the JavaCheck.java is:
```java
public class JavaCheck {
   private static final String[] keys = new String[]{"java.version"};

   public static void main(String[] var0) {
      byte var1 = 0;
      String[] var2 = keys;
      int var3 = var2.length;

      for(int var4 = 0; var4 < var3; ++var4) {
         String var5 = var2[var4];
         String var6 = System.getProperty(var5);
         if (var6 != null) {
            System.out.println(var5 + "=" + var6);
         } else {
            var1 = 1;
         }
      }

      System.exit(var1);
   }
}
```

# Requirements
This application was written in .NET 6.0. Please ensure you have that installed before running

# Instructions
## Downloading
Download the .zip file found in the latest release, and extract it somewhere memorable. This app will only run with manual execution, so you'll be required to run it after every update.

## Modifying location.txt
Add the directory of where the launcher is installed. Microsoft Store will have their location already in the file, so copy and paste into Line 7, replacing `[USERNAME]` with your name.  
For the old launcher location, I'm unaware of where the default location is, but I'll update the documentation once I have a response.

## Execution
Run `DeleteJavaCheck.exe`, and if there's no issues, the file should be deleted  
Note: This program won't say what the errors are (I'm working on this), but there are some problems that may occur:
- Having a backslash (\) at the end of the directory listed in location.txt
- Not having admin rights
- Not having the `\game` folder be the target directory
- The file may already be deleted.  

Another thing to note is that this file will most likely be permanently deleted, so remember to run the right version of Java on newer installations

# Future updates
- Will scan both launchers automatically, provided that they are in the default location

# Updating
This doesn't have an auto updater, but there will be an update at the end of every week, so until that's implemented, check back here every once in a while.  
Most updates won't be QOL (Quality of Life) updates, but mainly just error handling or improving the code, so it's not important to be on the latest release
