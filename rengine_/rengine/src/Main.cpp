///
/// "rengine" - a game engine
/// Developed by Siberian Inhabitants Ltd.
///
/// Engine developer team:
///     siberianbot
///

#include "Engine/Engine.hpp"

int main(int argc, char **argv)
{
    rengine::Engine::instance()->run({argc, argv});
}
