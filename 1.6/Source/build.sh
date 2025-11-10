#!/bin/bash

set -e

case "$1" in
    debug|'')
        dotnet build --configuration Debug
        cp -a bin/Debug/net472/RoomFoodDistancePatch.{dll,pdb} ../Assemblies
        ;;
    release)
        dotnet build --configuration Release
        cp -a bin/Release/net472/RoomFoodDistancePatch.dll ../Assemblies
        rm -f ../Assemblies/RoomFoodDistancePatch.pdb
        ;;
    *)
        echo "Usage: $(basename "$0") [debug|release]"
        false
        ;;
esac
