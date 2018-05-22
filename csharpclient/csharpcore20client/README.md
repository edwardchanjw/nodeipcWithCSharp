##How to reproduce Core 2.0 Project from scratch


1. dotnet new console
2. Copy the code from Program.cs to the Initialized/Generated Program.cs
3. dotnet run

That it.

Extra: Release Exe in Windows 10 (Tested only on Windows 10).

dotnet publish --configuration Release --runtime win10-x64

Theory it should work on Mac OSX and Linux by changing --runtime
Related: https://docs.microsoft.com/en-us/dotnet/core/rid-catalog
