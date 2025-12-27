# OnPlayerJoin
Custom Join/Leave message for TShock Terraria servers

## Installation
1. Download the `Anticrash.dll` file.
2. Put the `.dll` file inside of `/ServerPlugins/`
3. Stop and rerun the server.

## Versions
[OnPlayerJoin v1.0.0](https://github.com/ItzMelton/OnPlayerJoin)    

# Instructions
## Configs
`Enabled`: Enables or disables the plugin.

`EnableJoinMessage`: Enable the custom join message, true or false.       
`EnableLeaveMessage`: Enable the custom leave message, true or false.        

`Join`: Custom join message.        
`Left`: Custom leave message.          

### Format

|   Format    |   Information    |
|---------|:-------:|
| {0}     |  PlayerName    |

## Default Config Setting                       
Location: `TShock/PlayerJoin.json`                        
You may customize these settings to your preference.                         
```json
{
    "Enable": true,
    "JoinSettings": {
        "EnableJoinMessage": true,
        "EnableLeaveMessage": true,
        "Join": "{0} has joined the server!"
        "Left": "{0} has left the server!"
    }
    "HelpFormat": {
        "{0}": "PlayerName"
    }
}
```
