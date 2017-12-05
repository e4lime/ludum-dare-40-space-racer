# ~~Space-Racer~~
# Brick Racer
## Summary
Brick Racer!
Reach the end of the race track as fast as possible without dying. The more health you have the slower your speed will be. Hit gray blocks to lose health and hit green ones to gain health. 
In order to gain a good time, you need to keep your health as low as possible without dying.

A: Move left
D: Move right
M: Mute sound

v2:
The more health you have the slower you move, lower the faster. 
100 total health
Obstacles drain health, some drain 1 


BUGG:
Health stops spawning sometimes

## GDD
* Endless space racer on 3 lanes.
* The more lives you have the less points you get over time
* The more points you get the harder it gets
* Goal is to stay alive and gain as many points as possible
* Obstacles removes lives
* Game over when health reaches 0
* It should be rewarding to stay close to 1 health
* Bonus (if time): Avoid bugs! More bugs you get the harder it gets, a bug can be ship starts spinning, controls flips, camera changes fov etc 

### Controls
Two types of controls:
Snappy:
* Hold left to snap to left lane
* Hold right to snap to right lane
* Release keys to snap to middle line

Easy:
* Press left to snap to a lane to the left
* Press right to snap to a lane to the right

### Outlines
![Gameplay](/notes/gameplay-outline_01.png "Gameplay")


## TODO
- [x] 3 lanes
- [x] endless
- [x] bent world shader

- [x] ship forward movement
- [x] ship horizontal movement, left moves left a lane and vice versa
- [x] health

- [ ] main menu
- [x] obstacles
- [x] obstacle spawner
- [x] health objects
- [x] health spawner
- [ ] start countdown or some sequence
- [x] Camera follow ship

### Optional
- [ ] online highscore

### Sounds
- [ ] Hit decrease obstacle
- [ ] Hit increase obstacle
- [ ] Goal


### Skip
- [ ] score 
- [ ] snap to world (... forgot what I meant here)

Optional
- [ ] pause menu
- [ ] bugs
- [ ] more health = more bugs
- [ ] slow motion when hitting bugs
- [ ] Jump
- [ ] Second control, hold left for left lane and right for right lane

## IMPORTANT Checklist
### In the beginning

#### Per User
- [ ] \(Optional) Move content in "GameEngine Data" to your Unity installation to override default C# script

#### Per Team 
- [x] Change /unity-project-folder/ name
- [x] Decide folder structure (!_Game_ByAssetType vs !_Game_ByEntity) Rename to !_Game, delete unwanted one   
- [ ] Decide what thirdparty libraries to use      
- [ ] Update .gitignore in /unity-project-folder/ to include or exlude third party libraries. Prefix with ! to flip folders
- [ ] Don't commit PAID libraries if going open source     
- [x] Set Company name in "Project Settings > Player Settings" to team name   
- [x] Set Product name in "Project Settings > Player Settings" to project name   
- [x] Decide Time Settings (Default timestep is 0.02, project is set to 0.04)    
- [x] Decide script structures (Update default c# monobehaviour-script if needed)
- [x] If you're using a newer unity version, check if .gitignore is still valid; 
 
### At the end

#### Per Team Before Final build
- [ ] Backup project     
- [ ] Set final Company name in "Project Settings > Player Settings"     
- [ ] Set final Product name in "Project Settings > Player Settings"      
- [ ] Remove paid tools      
- [ ] Double check paid tools from commit history if going public    
- [ ] Remove placeholders       
- [ ] Add Unity version used to the readme
- [ ] Add Third party tools versions to the readme
- [ ] WebGL: Remove exceptions handling

### Optimization Checklist
- [ ] Remove empty Update methods
- [ ] Cache components
- [ ] Profile
- [ ] Merge meshes    
- [ ] Texture atlases    
- [ ] Share materials
--------

## List of Thirdparty Libraries and tools
TODO: Remove unused 

### DOTween Pro
An Animation and tweening library.   
PAID  
https://www.assetstore.unity3d.com/en/#!/content/32416   
Or Use the Free version (below)  

* Demigiant/DOTweenPro
* Resources/DOTweenSettings.asset

### DOTween
An Animation and tweening library.  
Free   
https://www.assetstore.unity3d.com/en/#!/content/27676    
Or use the paid version (above)  

* Demigiant/DOTween
* Resources/DOTweenSettings.asset

### ProBuilder Basic
3D Level tool.   
Free    
https://www.assetstore.unity3d.com/en/#!/content/11919    

* ProCore/ProBuilder


### Unity Toolbag
Scripting Tools   
Free   
https://github.com/nickgravelyn/UnityToolbag     
Omitted: SimpleSpriteAnimation, SortingLayer, SyncSolution    
 
* UnityToolbag-master/CacheBehaviour
* UnityToolbag-master/Dispatcher
* UnityToolbag-master/Future
* UnityToolbag-master/SnapToSurface
* UnityToolbag-master/StandardPaths
* UnityToolbag-master/UnityConstants

###  Consolation
View console ingame    
Free    
https://github.com/mminer/consolation    

* consolation-master/

