list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/Main.cpp")

add_subdirectory("Common")
add_subdirectory("Engine")
add_subdirectory("EntitySystem")
add_subdirectory("Extern")
add_subdirectory("Rendering")
add_subdirectory("Utils")

set(SRC ${SRC} PARENT_SCOPE)