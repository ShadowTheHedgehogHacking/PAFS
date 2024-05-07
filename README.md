# PAFS
Simple AFS patcher (CLI util) - replace via filename matching (.adx files only)

* The AFS and folder containing .adx replacements must be the same name.
* The .adx replacements can NOT be in subdirectories (e.g. `\PJS\mysubfolder\something.adx`) only `\PJS\something.adx` is valid

<img src="https://raw.githubusercontent.com/ShadowTheHedgehogHacking/PAFS/main/res/01.jpg" align="center" />


To build single file for platform of your choice:

`dotnet publish PAFS.sln -c Release -r win-x64`
`dotnet publish PAFS.sln -c Release -r linux-x64`
