# SJPCheck
SJPCheck is a program created to quickly get word definitions from Polish online dictionary (sjp.pl).
# Built With:
1. C#
  * Winforms
2. Web Scraping

# Usage
Default hotkey to bring up the application is set to ALT+Q. To change it, change RegisterHotkey() on line 27 in the Form1.cs file.
```cs
 		// register the alt + Q combination as hot key.
	    hook.RegisterHotKey(SJPCheck.ModifierKeys.Alt, Keys.Q);
```

# Author
Jan Radłowski

# Screenshots
<img src="http://i.imgur.com/SnvslmW.png" alt="query result">

