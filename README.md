# Keyword Tools
These are the simplest tools available for reporting on the keywords in a given scene and then removing them.
They're pretty barebones, and will just turn keywords off without much nuance. USE AT YOUR OWN RISK!

### Usage
1. On the menu, go to Window->Keyword Tools->Reporter.
2. See the text file report in your text editor of choice.
   * To read it again, just open "Assets/Keyword Tools/Report.txt".
3. From the "Scene Keywords" at the top, copy all the keywords you want to remove.
4. Open up the file "Assets/Keyword Tools/Editor/KeywordTools.cs".
5. Paste the keywords into the array "keywordsToRemove", and save the file.
6. On the menu, go to Window->Keyword Tools->Obliterater.
7. Press Ctrl+S to save the changes to all the materials in your scene.