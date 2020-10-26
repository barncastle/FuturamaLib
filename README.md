# FuturamaLib

A library for reading most of the formats found in the PS2 and Xbox [Futurama game](https://en.wikipedia.org/wiki/Futurama_(video_game)).

##### Supported formats:

- **FNT** - the `.fnt` files are used by the game to map each ASCII character to an offset and dimension within a font spritesheet.
- **Img** - the `.img` archives contain all game assets. Unlike the normal format, these start with a "directory" section that is currently unsupported by the main game extractors so a custom implementation was added. The **FileExtractor** project is a wrapper around this implementation to provide a standalone program to extract assets.
- **LDB** - the `.ldb` files are language databases used by the game to load text in a specific locale. There is an option to export these as flattened CSVs for easier reading. 
- **NIF/UCF** - the `.nif` and `.ucf` files are **NetImmerse File** format files which is a generic file container format. They are mostly commonly used for meshes notably in Bethesda game. The developers of the game have customised this format quite heavily to allow storing a variety of additional information from lookup tables to metadata for the above formats. All custom modifications are implemented in the reader albeit some names of fields and structs are unknown and some of the custom types are raw blobs (this is how the game reads them).
- **VAG** - the `.vag` files are standard PS2 compressed audio files, this was just added for the sake of completeness. There is an option to export these to WAV.



##### Unsupported Formats:

- **FUL** - Futurama Language scripts.
- **DBG** - Debug symbols for the above scripts.

