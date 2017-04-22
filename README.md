# HUEston
A small GUI for accessing Philips HUE Lamps under any Windows environment.

![alt text][logo]

[logo]: http://maio290.de/hueston_2.PNG "HUEston Mainform"

## Functions

* Setup and pairing with your HUE Bridge
* Autodetection of your HUE Bridge by using Philips nupnp service
* You can control your lamps by room or by the individual lamp
* Presets with config-reader (Writer & Preset Creator is still to come)

## Presets

* The preset file is called "presets.cfg" - every preset has four lines:

|    Line   | Variable | Example / Format |                               Explanation                                |
|:-------------:|:--------:|:---------------:|:-------------------------------------------------------------------------:|
|  1  |   ID  |     1: / Int32     | The primary key of the preset (simple auto increment) |
|  2  |   Name  |    name:Colour Loop / string    |   The name of your preset  |
|    3   |   Sleep(duration) in ms  |      sleep:500 / Int32     |         The sleepduration after each iteration (if it's not a loop) or after each cycle (if loop)        |
| 4 |   Commands  |     commands:turnOn:3&#124;loop&#124;campfire:3&#124;sleep:100 / String      |                          The list of the commands for the preset - the structure is the following: function:arg1,arg2,...|function2:arg1|loop|function3:arg1                         |

* Current commands for presets (basically all functions from HUEFunctions.cs acquired by reflection):

|     Command     	|                       Arguments                      	|                                                     Explanation                                                    	| Limited Range                                      	| Target   	|
|:---------------:	|:----------------------------------------------------:	|:------------------------------------------------------------------------------------------------------------------:	|----------------------------------------------------	|----------	|
|       loop      	|                           -                          	|                                 Loops the presets commands after the loop statement                                	|                          -                         	| Commands 	|
|      sleep      	|                       int sleep                      	|                              Sleeps the execution of the preset by sleep milliseconds                              	|                    sleep: [0-∞[                    	| Commands 	|
|      turnOn     	|                        int ID                        	|                                        Turns the light with the given ID on                                        	|                          -                         	|   Bulb   	|
|     turnOff     	|                        int ID                        	|                                        Turns the light with the given ID off                                       	|                          -                         	|   Bulb   	|
|      briUP      	|                        int ID                        	|                                   Increases the brightness of the given ID by 50                                   	|                          -                         	|   Bulb   	|
|     briDown     	|                        int ID                        	|                                   Decreases the brightness of the given ID by 50                                   	|                          -                         	|   Bulb   	|
|      setXY      	|              int ID, double X, double Y              	|                                     Sets the colour of the given ID to x and y                                     	|           Yes (but not a "common" limit)           	|   Bulb   	|
|      setCT      	|                    int ID, int CT                    	|                                  Sets the color temperature of the given ID to CT                                  	|                    CT: [153-500]                   	|   Bulb   	|
|      setHUE     	|                    int ID, int HUE                   	|                                       Sets the colour of the given ID to HUE                                       	|                    HUE:[0-65280]                   	|   Bulb   	|
|      setBRI     	|                    int ID, int BRI                   	|                                     Sets the brightness of the given ID to BRI.                                    	|                     BRI:[0-254]                    	|   Bulb   	|
|     setAlert    	|                        int ID                        	|                                            Flashes the given ID one time                                           	|                          -                         	|   Bulb   	|
|     pulsate     	|                   int ID, int sleep                  	|                                  Sets the brightness of the given ID from 1 - 254                                  	|                    sleep: [0-∞[                    	|   Bulb   	|
|     campfire    	|                        int ID                        	|                                          Imitates a campfire (when looped)                                         	|                          -                         	|   Bulb   	|
|   setRandomHUE  	|                        int ID                        	|                              Changes the HUE value of the given ID to a random number                              	|                          -                         	|   Bulb   	|
|   setRandomBRI  	|               int ID, int min, int max               	|                             Changes the brightness of the given ID to a random number.                             	|                  min, max: [0-254]                 	|   Bulb   	|
|     fadeBRI     	|       int ID, int stepsize, int start, int end       	| Fades the brightness of the given ID from start to end by reducing or increasing it's value by stepsize each cycle 	| stepsize: [1-254] start, end: [0-254] sleep: [0-∞[ 	|   Bulb   	|
|    GRPturnOn    	|                        int gid                       	|                                        Turns the group with the given GID on                                       	|                          -                         	|   Group  	|
|    GRPturnOff   	|                        int gid                       	|                                       Turns the group with the given GID off                                       	|                          -                         	|   Group  	|
|     GRPbriUP    	|                        int gid                       	|                                   Increases the brightness of the given GID by 50                                  	|                          -                         	|   Group  	|
|    GRPbriDown   	|                        int gid                       	|                                   Decreases the brightness of the given GID by 50                                  	|                          -                         	|   Group  	|
|    GRPhueInc    	|                        int gid                       	|                                  Increases the HUE value of the given GID by 1500                                  	|                          -                         	|   Group  	|
| GRPhueIncManual 	|                   int gid, int hue                   	|                                   Increases the HUE Value of the given GID by HUE                                  	|                   HUE: [0-65280]                   	|   Group  	|
|    GRPhueDec    	|                        int gid                       	|                                  Decreases the HUE value of the given GID by 1500                                  	|                          -                         	|   Group  	|
|    GRPsatInc    	|                        int gid                       	|                                   Increases the saturation of the given GID by 50                                  	|                          -                         	|   Group  	|
|    GRPsatDec    	|                        int gid                       	|                                   Decreases the saturation of the given GID by 50                                  	|                          -                         	|   Group  	|
|    GRPsetHue    	|                   int gid, int hue                   	|                                     Sets the HUE value of the given GID to HUE                                     	|                   HUE: [0-65280]                   	|   Group  	|
|     GRPsetCT    	|                    int gid, int ct                   	|                                 Sets the colour temperature of the given GID to CT                                 	|                    CT: [153-500]                   	|   Group  	|
|     GRPsetXY    	|              int gid,double X, double Y              	|                                     Sets the colour of the given GID to x and y                                    	|           Yes (but not a "common" limit)           	|   Group  	|
|    GRPbriSet    	|                   int gid, int bri                   	|                                     Sets the brightness of the given GID to BRI                                    	|                    BRI: [0-254]                    	|   Group  	|
|    GRPpulsate   	|                  int gid, int sleep                  	|                                 Sets the brightness of the given GID from 1 to 254                                 	|                    sleep: [0-∞[                    	|   Group  	|
| GRPsetRandomHUE 	|                        int gid                       	|                               Sets the HUE value of the given GID to a random number                               	|                          -                         	|   Group  	|
| GRPsetRandomBRI 	|               int gid, int min, int max              	|                     Sets the brightness of the given GID to a random number between min and max                    	|                  min,max: [0-254]                  	|   Group  	|
|    GRPfadeBRI   	| int gid, int sleep, int stepsize, int start, int end 	| Fades the brightness of the given GID from start to endby reducing or increasing it's value by stepsize each cycle 	| stepsize: [1-254] start, end: [0-254] sleep: [0-∞[ 	|   Group  	|

### Example Preset

>9:

> name:Campfire

> sleep:0

> commands:turnOn:3|loop|campfire:3|sleep:100

## Things to come
* Preset-Builder
* Nicer GUI (hopefully)
* Cleaner Code

## Issues or untested Things

Since I don't own any old HUE hardware (newest Bridge and RGB Lamps only) I can't tell if there will be any bug with older bridges or lamps. However, if you're using the same hardware as I do, you should be fine. Feel free to report any bug.
