cmake_minimum_required(VERSION 3.19)

project("lucidreams.Environment.Win32")

set(CMAKE_CXX_STANDARD 20)
set(src)

add_definitions(-DUNICODE)
add_definitions(-D_UNICODE)

include_directories("include")
add_subdirectory("src")

add_library("lucidreams.Environment.Win32" STATIC ${SRC})
