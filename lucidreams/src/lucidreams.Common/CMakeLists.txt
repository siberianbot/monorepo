cmake_minimum_required(VERSION 3.19)

set(LUCIDREAMS_COMMON_PUBLIC "${CMAKE_CURRENT_LIST_DIR}/Public")

add_library(
        "lucidreams.Common" INTERFACE
)

target_include_directories(
        "lucidreams.Common" INTERFACE
        ${LUCIDREAMS_COMMON_PUBLIC}
)