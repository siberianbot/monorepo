cmake_minimum_required(VERSION 3.19)

set(LUCIDREAMS_SYSTEM_PUBLIC "${CMAKE_CURRENT_LIST_DIR}/Public")

add_library(
        "lucidreams.System" INTERFACE
)

target_include_directories(
        "lucidreams.System" INTERFACE
        ${LUCIDREAMS_SYSTEM_PUBLIC}
)

target_link_libraries(
        "lucidreams.System" INTERFACE
        "lucidreams.Common"
)
