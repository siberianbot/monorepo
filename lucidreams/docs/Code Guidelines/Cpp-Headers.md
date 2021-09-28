Code Guidelines - CPP
===============================

Naming
------

- Use `LUCIDREAMS` as prefix of the `#define` name;
    - `LUCIDREAMS_TYPES_HPP`;
    - `LUCIDREAMS_VERSION_MAJOR`.

Use include guards
------------------

- `#define` name should be named according to relative path to file for public files:
  - `lucidreams.Common/Public/lucidreams/Types.hpp` = `LUCIDREAMS_TYPES_HPP`;
  - `lucidreams.Common/Public/lucidreams/Constants.hpp` = `LUCIDREAMS_CONSTANTS_HPP`;
- `#define` for internal headers is same:
  - `lucidreams.System.Win32/Internal/lucidreams/System/Win32LibraryProxy.hpp` = `LUCIDREAMS_SYSTEM_WIN32LIBRARYPROXY_HPP`;

```c++
#ifndef LUCIDREAMS_TYPES_HPP
#define LUCIDREAMS_TYPES_HPP

// some code

#endif //LUCIDREAMS_COMMON_TYPES_HPP
```