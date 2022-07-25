# File Converter GUI

**Author: Sidartha Prastya**

This is a GUI for converting encoded (base64) file (input) -> csv -> pdf file (output).
GUI is created using .NET Windows Form (Visual Studio 2022)

There are 2 projects:

## CSV to PDF

Containing C++ functions to decode the txt file and convert it to PDF.
This file is compiled into Dynamic Link Library to be called by File Converter GUI.

## File Converter

Containing C# program (.NET Windows Form) for user interaction.
This GUI will request inputs:
- Encoded file's path
- Decoded file's name
- Decoded file's folder path