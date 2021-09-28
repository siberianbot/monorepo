cmake_minimum_required(VERSION 3.19)

set(LUCIDREAMS_ENGINE_RUNROUTINE_MAINONLY_INTERNAL "${CMAKE_CURRENT_LIST_DIR}/Internal")

add_executable(
        "lucidreams.Engine.RunRoutine.MainOnly"
        "${LUCIDREAMS_ENGINE_RUNROUTINE_MAINONLY_INTERNAL}/Main.cpp"
)

target_link_libraries(
        "lucidreams.Engine.RunRoutine.MainOnly" PUBLIC
        "lucidreams.Common"
        "lucidreams.System.Win32"
)