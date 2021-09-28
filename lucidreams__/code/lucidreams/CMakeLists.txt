cmake_minimum_required(VERSION 3.17)

project(lucidreams)

set(CMAKE_CXX_STANDARD 20)
set(SRC)

add_definitions(-DUNICODE)
add_definitions(-D_UNICODE)
add_definitions(-DVK_USE_PLATFORM_WIN32_KHR)

find_package(Vulkan)
include_directories(${Vulkan_INCLUDE_DIRS})

include_directories("include")
add_subdirectory("src")

add_executable(lucidreams WIN32 ${SRC})