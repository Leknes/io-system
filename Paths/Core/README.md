# Path Representation
 
This library grants a way of representing paths as classes which makes the represented files or directories more easily accessable
as well as minimizing memory overhead for saving paths, when multiple paths are inside of a represented directory path.

Furthermore, paths can be represented as directories using the `DirectoryPath` class, or as files using the `FilePath` class. 
Also the system is based on a decorater pattern which makes paths much easier to modify with low memory allocation. For example the `ExtensionPath` class might be used, to add an extension to a file path,
without requiring it in the `FilePath` instance itself.
