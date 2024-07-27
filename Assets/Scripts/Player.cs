public static class Player
{
    static int ToolHeld = -1;

    public static void GiveTool(int tool){
        ToolHeld = tool;
    }

    public static void RemoveTool(){
        ToolHeld = -1;
    }

    public static int WhatTool(){
        return ToolHeld;
    }
}