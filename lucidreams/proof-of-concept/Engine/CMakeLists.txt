cmake_minimum_required(VERSION 3.19)

project(lucidreams)

set(CMAKE_CXX_STANDARD 20)
set(src)

add_definitions(-DUNICODE)
add_definitions(-D_UNICODE)

include_directories("include")
add_subdirectory("src")

add_executable(lucidreams ${SRC})