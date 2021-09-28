cmake_minimum_required(VERSION 3.19)

project("lucidreams")
set(CMAKE_CXX_STANDARD 20)

add_definitions(
        -DUNICODE
        -D_UNICODE
)

add_subdirectory("lucidreams.Common")
add_subdirectory("lucidreams.System")
add_subdirectory("lucidreams.System.Win32")
add_subdirectory("lucidreams.Engine.RunRoutine.MainOnly")