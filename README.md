# Cirrus Studio Basic Revit Addin

Basic Revit addin boilerplate code used for Revit addin development.
The code builds a .NET Framework class library which can be loaded into Revit.
As frontend the application uses Windows Presentation Foundation framework with MVVM pattern.

## Build
1. Clone the solution from the main branch.
2. Build the solution with Configuration set to Debug. Built assemblies should be located in the `Assemblies.Debug` folder.
3. Copy the `CirrusAddin.addin` file to `C:\ProgramData\Autodesk\Revit\Addins\<REVIT_VERSION>` folder.
4. Open the `CirrusAddin.addin` file and change <Assembly> tag to point to the `CirrusAddin.dll` file located in the `Assemblies.Debug` folder.
5. Start coding your new addin! 🚀
  
## Project structure
- **CirrusAddin**
  
  Entrypoint for the addin application. The `Main` class is the starting point of the application initialization when Revit starts.
- **CirrusAddin.Core**
  
  The project where business logic resides. Every class which makes changes to Revit files or gets data from Revit files is stored in this project. The ViewModels contain the backend logic for the UI operations in the plugin.
- **CirrusAddin.UI**
  
  Project containing UI views and controls in `.xaml` files. Also, classes that create Revit related UI contols like buttons or tabs are stored here.

 ## Recent contributors
- Karol Jędruszek (karol.jedruszek@viatechnik.com) 👺

Please contact these people if you have questions about the code or this project in general. They will be more than happy to help you out! :+1:
