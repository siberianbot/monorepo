list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/DynamicLibraryManager.cpp")
list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/DynamicLibraryManager.hpp")
list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/IDynamicLibraryProxy.cpp")
list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/IDynamicLibraryProxy.hpp")
list(APPEND SRC "${CMAKE_CURRENT_LIST_DIR}/Main.Win32.cpp")

add_subdirectory("Win32")

set(SRC ${SRC} PARENT_SCOPE)