`lucidreams` - a game engine
============================

Project structure
-----------------

- `artifacts` - artifacts;
- `build` - building scenarios for PowerShell;
- `docs` - documentation: design, manuals, etc;
- `proof-of-concept` - proof-of-concepts;
- `redist` - redistributable packages: .NET, Vulkan, etc;
- `src` - engine source code:
  - **note:** all modules have own `readme.md` with module description;
  - `../<module name>/Public` - public part of module (headers);
  - `../<module name>/Internal` - internal part of module (own headers, source code, etc);
- `toolchain` - things required to build.

Obsolete items
--------------

- `projects` - actual source code:
  - `Engine` - engine source code;
  - `Scripting` - scripting host source code;