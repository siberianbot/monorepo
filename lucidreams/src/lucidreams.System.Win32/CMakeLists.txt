cmake_minimum_required(VERSION 3.19)

set(LUCIDREAMS_SYSTEM_WIN32_INTERNAL "${CMAKE_CURRENT_LIST_DIR}/Internal")

add_library(
        "lucidreams.System.Win32" STATIC
        "${LUCIDREAMS_SYSTEM_WIN32_INTERNAL}/System/Win32LibraryProxy.cpp"
        "${LUCIDREAMS_SYSTEM_WIN32_INTERNAL}/System/Win32LibraryProxy.hpp"
        "${LUCIDREAMS_SYSTEM_WIN32_INTERNAL}/System/Win32LibraryProxyFactory.cpp"
        "${LUCIDREAMS_SYSTEM_WIN32_INTERNAL}/System/Win32LibraryProxyFactory.hpp"
)

target_link_libraries(
        "lucidreams.System.Win32" PUBLIC
        "lucidreams.System"
)
